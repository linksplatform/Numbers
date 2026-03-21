#!/usr/bin/env rust-script
//! Create GitHub Release from CHANGELOG.md
//!
//! Usage: rust-script scripts/create-github-release.rs --release-version <version> --repository <repository>
//!
//! ```cargo
//! [dependencies]
//! regex = "1"
//! serde = { version = "1", features = ["derive"] }
//! serde_json = "1"
//! ```

use std::env;
use std::fs;
use std::io::Write;
use std::path::Path;
use std::process::{Command, Stdio, exit};
use regex::Regex;
use serde::Serialize;

fn get_arg(name: &str) -> Option<String> {
    let args: Vec<String> = env::args().collect();
    let flag = format!("--{}", name);

    if let Some(idx) = args.iter().position(|a| a == &flag) {
        return args.get(idx + 1).cloned();
    }

    let env_name = name.to_uppercase().replace('-', "_");
    env::var(&env_name).ok().filter(|s| !s.is_empty())
}

fn get_changelog_for_version(version: &str) -> String {
    let changelog_path = "CHANGELOG.md";

    if !Path::new(changelog_path).exists() {
        return format!("Release v{}", version);
    }

    let content = match fs::read_to_string(changelog_path) {
        Ok(c) => c,
        Err(_) => return format!("Release v{}", version),
    };

    let escaped_version = regex::escape(version);
    let pattern = format!(r"(?s)## \[{}\].*?\n(.*?)(?=\n## \[|$)", escaped_version);
    let re = Regex::new(&pattern).unwrap();

    if let Some(caps) = re.captures(&content) {
        caps.get(1).unwrap().as_str().trim().to_string()
    } else {
        format!("Release v{}", version)
    }
}

#[derive(Serialize)]
struct ReleasePayload {
    tag_name: String,
    name: String,
    body: String,
}

fn main() {
    let version = match get_arg("release-version") {
        Some(v) => v,
        None => {
            eprintln!("Error: Missing required argument --release-version");
            eprintln!("Usage: rust-script scripts/create-github-release.rs --release-version <version> --repository <repository>");
            exit(1);
        }
    };

    let repository = match get_arg("repository") {
        Some(r) => r,
        None => {
            eprintln!("Error: Missing required argument --repository");
            eprintln!("Usage: rust-script scripts/create-github-release.rs --release-version <version> --repository <repository>");
            exit(1);
        }
    };

    let tag_prefix = get_arg("tag-prefix").unwrap_or_else(|| "v".to_string());
    let crates_io_url = get_arg("crates-io-url");

    let tag = format!("{}{}", tag_prefix, version);
    println!("Creating GitHub release for {}...", tag);

    let mut release_notes = get_changelog_for_version(&version);

    if let Some(url) = crates_io_url {
        release_notes = format!("{}\n\n{}", url, release_notes);
    }

    let payload = ReleasePayload {
        tag_name: tag.clone(),
        name: format!("{}{}", tag_prefix, version),
        body: release_notes,
    };

    let payload_json = serde_json::to_string(&payload).expect("Failed to serialize payload");

    let mut child = Command::new("gh")
        .args([
            "api",
            &format!("repos/{}/releases", repository),
            "-X",
            "POST",
            "--input",
            "-",
        ])
        .stdin(Stdio::piped())
        .stdout(Stdio::piped())
        .stderr(Stdio::piped())
        .spawn()
        .expect("Failed to execute gh command");

    if let Some(ref mut stdin) = child.stdin {
        stdin.write_all(payload_json.as_bytes()).expect("Failed to write to stdin");
    }

    let output = child.wait_with_output().expect("Failed to wait on gh command");

    if output.status.success() {
        println!("Created GitHub release: {}", tag);
    } else {
        let stderr = String::from_utf8_lossy(&output.stderr);
        if stderr.contains("already exists") {
            println!("Release {} already exists, skipping", tag);
        } else {
            eprintln!("Error creating release: {}", stderr);
            exit(1);
        }
    }
}
