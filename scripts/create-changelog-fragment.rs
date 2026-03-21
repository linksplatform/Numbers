#!/usr/bin/env rust-script
//! Create a changelog fragment for manual release PR
//!
//! This script creates a changelog fragment with the appropriate
//! category based on the bump type.
//!
//! Usage: rust-script scripts/create-changelog-fragment.rs --bump-type <type> [--description <desc>]
//!
//! ```cargo
//! [dependencies]
//! chrono = "0.4"
//! ```

use std::env;
use std::fs;
use std::path::Path;
use std::process::exit;
use chrono::Utc;

fn get_arg(name: &str) -> Option<String> {
    let args: Vec<String> = env::args().collect();
    let flag = format!("--{}", name);

    if let Some(idx) = args.iter().position(|a| a == &flag) {
        return args.get(idx + 1).cloned();
    }

    let env_name = name.to_uppercase().replace('-', "_");
    env::var(&env_name).ok().filter(|s| !s.is_empty())
}

fn get_category(bump_type: &str) -> &'static str {
    match bump_type {
        "major" => "### Breaking Changes",
        "minor" => "### Added",
        "patch" => "### Fixed",
        _ => "### Changed",
    }
}

fn generate_timestamp() -> String {
    Utc::now().format("%Y%m%d%H%M%S").to_string()
}

fn main() {
    let bump_type = get_arg("bump-type").unwrap_or_else(|| "patch".to_string());
    let description = get_arg("description");

    if !["major", "minor", "patch"].contains(&bump_type.as_str()) {
        eprintln!("Invalid bump type: {}. Must be major, minor, or patch.", bump_type);
        exit(1);
    }

    let changelog_dir = "changelog.d";
    let timestamp = generate_timestamp();
    let fragment_file = format!("{}/{}-manual-{}.md", changelog_dir, timestamp, bump_type);

    let category = get_category(&bump_type);

    let description_text = description.unwrap_or_else(|| format!("Manual {} release", bump_type));
    let fragment_content = format!(
        "---\nbump: {}\n---\n\n{}\n\n- {}\n",
        bump_type, category, description_text
    );

    let dir_path = Path::new(changelog_dir);
    if !dir_path.exists() {
        if let Err(e) = fs::create_dir_all(dir_path) {
            eprintln!("Error creating directory {}: {}", changelog_dir, e);
            exit(1);
        }
    }

    if let Err(e) = fs::write(&fragment_file, &fragment_content) {
        eprintln!("Error writing fragment file: {}", e);
        exit(1);
    }

    println!("Created changelog fragment: {}", fragment_file);
    println!();
    println!("Content:");
    println!("{}", fragment_content);
}
