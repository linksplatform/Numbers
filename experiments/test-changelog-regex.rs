#!/usr/bin/env rust-script
//! Test the fixed changelog regex pattern
//!
//! ```cargo
//! [dependencies]
//! regex = "1"
//! ```

use regex::Regex;

fn get_changelog_for_version(content: &str, version: &str) -> String {
    let escaped_version = regex::escape(version);
    let pattern = format!(r"(?s)## \[{}\][^\n]*\n(.*?)(?:\n## \[|$)", escaped_version);
    let re = Regex::new(&pattern).unwrap();

    if let Some(caps) = re.captures(content) {
        caps.get(1).unwrap().as_str().trim().to_string()
    } else {
        format!("Release v{}", version)
    }
}

fn main() {
    let changelog = r#"# Changelog

## [0.3.0] - 2026-03-22

### Added
- Feature A
- Feature B

### Fixed
- Bug C

## [0.2.1] - 2025-12-28

### Fixed
- Bug D

## [0.2.0] - 2025-11-01

### Added
- Initial release
"#;

    println!("=== Testing version 0.3.0 ===");
    let result = get_changelog_for_version(changelog, "0.3.0");
    println!("{}", result);
    assert!(result.contains("Feature A"), "Should contain Feature A");
    assert!(result.contains("Bug C"), "Should contain Bug C");
    assert!(!result.contains("Bug D"), "Should NOT contain Bug D from 0.2.1");
    println!("✓ PASS: 0.3.0 section parsed correctly");

    println!("\n=== Testing version 0.2.1 ===");
    let result = get_changelog_for_version(changelog, "0.2.1");
    println!("{}", result);
    assert!(result.contains("Bug D"), "Should contain Bug D");
    assert!(!result.contains("Feature A"), "Should NOT contain Feature A from 0.3.0");
    println!("✓ PASS: 0.2.1 section parsed correctly");

    println!("\n=== Testing version not found ===");
    let result = get_changelog_for_version(changelog, "9.9.9");
    println!("{}", result);
    assert_eq!(result, "Release v9.9.9");
    println!("✓ PASS: fallback to 'Release v9.9.9' when version not found");

    println!("\n=== All tests passed! ===");
}
