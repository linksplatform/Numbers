#!/usr/bin/env rust-script
//! Rust package path detection utility
//!
//! Automatically detects the Rust package root for both:
//! - Single-language repositories (Cargo.toml in root)
//! - Multi-language repositories (Cargo.toml in rust/ subfolder)
//!
//! This utility follows best practices for multi-language monorepo support,
//! allowing scripts to work seamlessly in both repository structures.
//!
//! Usage (as library - import functions from this module):
//!   The functions are used by other scripts in this directory.
//!
//! Configuration options (in order of priority):
//!   1. Explicit parameter passed to functions
//!   2. CLI argument: --rust-root <path>
//!   3. Environment variable: RUST_ROOT
//!   4. Auto-detection: Check ./Cargo.toml first, then ./rust/Cargo.toml

use std::env;
use std::path::{Path, PathBuf};

/// Detect Rust package root directory
pub fn get_rust_root(explicit_root: Option<&str>, verbose: bool) -> Result<String, String> {
    if let Some(root) = explicit_root {
        if verbose {
            eprintln!("Using explicitly configured Rust root: {}", root);
        }
        return Ok(root.to_string());
    }

    let args: Vec<String> = env::args().collect();
    if let Some(idx) = args.iter().position(|a| a == "--rust-root") {
        if let Some(root) = args.get(idx + 1) {
            if verbose {
                eprintln!("Using CLI configured Rust root: {}", root);
            }
            return Ok(root.clone());
        }
    }

    if let Ok(root) = env::var("RUST_ROOT") {
        if !root.is_empty() {
            if verbose {
                eprintln!("Using environment configured Rust root: {}", root);
            }
            return Ok(root);
        }
    }

    if Path::new("./Cargo.toml").exists() {
        if verbose {
            eprintln!("Detected single-language repository (Cargo.toml in root)");
        }
        return Ok(".".to_string());
    }

    if Path::new("./rust/Cargo.toml").exists() {
        if verbose {
            eprintln!("Detected multi-language repository (Cargo.toml in rust/)");
        }
        return Ok("rust".to_string());
    }

    Err(
        "Could not find Cargo.toml in expected locations.\n\
        Searched in:\n  \
        - ./Cargo.toml (single-language repository)\n  \
        - ./rust/Cargo.toml (multi-language repository)\n\n\
        To fix this, either:\n  \
        1. Run the script from the repository root\n  \
        2. Explicitly configure the Rust root using --rust-root option\n  \
        3. Set the RUST_ROOT environment variable"
            .to_string(),
    )
}

/// Get the path to Cargo.toml
pub fn get_cargo_toml_path(rust_root: &str) -> PathBuf {
    if rust_root == "." {
        PathBuf::from("./Cargo.toml")
    } else {
        PathBuf::from(rust_root).join("Cargo.toml")
    }
}

/// Get the path to Cargo.lock
pub fn get_cargo_lock_path(rust_root: &str) -> PathBuf {
    if rust_root == "." {
        PathBuf::from("./Cargo.lock")
    } else {
        PathBuf::from(rust_root).join("Cargo.lock")
    }
}

/// Get the path to changelog.d directory
pub fn get_changelog_dir(rust_root: &str) -> PathBuf {
    if rust_root == "." {
        PathBuf::from("./changelog.d")
    } else {
        PathBuf::from(rust_root).join("changelog.d")
    }
}

/// Get the path to CHANGELOG.md
pub fn get_changelog_path(rust_root: &str) -> PathBuf {
    if rust_root == "." {
        PathBuf::from("./CHANGELOG.md")
    } else {
        PathBuf::from(rust_root).join("CHANGELOG.md")
    }
}

/// Check if we need to change directory before running cargo commands
pub fn needs_cd(rust_root: &str) -> bool {
    rust_root != "."
}

/// Parse Rust root from CLI arguments
pub fn parse_rust_root_from_args() -> Option<String> {
    let args: Vec<String> = env::args().collect();
    if let Some(idx) = args.iter().position(|a| a == "--rust-root") {
        return args.get(idx + 1).cloned();
    }
    env::var("RUST_ROOT").ok().filter(|s| !s.is_empty())
}

fn main() {
    match get_rust_root(None, true) {
        Ok(root) => {
            println!("Rust root: {}", root);
            println!("Cargo.toml: {}", get_cargo_toml_path(&root).display());
            println!("Changelog dir: {}", get_changelog_dir(&root).display());
        }
        Err(e) => {
            eprintln!("Error: {}", e);
            std::process::exit(1);
        }
    }
}
