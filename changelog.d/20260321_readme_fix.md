---
bump: patch
---

### Added
- Rust-specific README.md with detailed description, usage examples, and crate badges
- C# language-specific README.md with namespace docs, installation, and usage examples
- C++ language-specific README.md with Conan installation and usage info

### Changed
- Root README.md now uses a badge table for all language versions (C#, C++, Rust), following the Interfaces repo style
- Replaced Gitpod badge with GitHub Codespaces badge in root README.md
- Updated Cargo.toml readme field to point to Rust-specific README.md instead of root README.md

### Fixed
- Rust crate on crates.io was displaying the generic root README.md instead of Rust-specific documentation
