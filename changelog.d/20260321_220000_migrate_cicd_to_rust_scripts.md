---
bump: minor
---

### Changed

- Migrated all CI/CD pipeline scripts from Node.js (.mjs) to Rust (.rs) using rust-script
- Updated workflow to use rust-script for all script execution, eliminating Node.js dependency

### Added

- Smart change detection job (`detect-code-changes.rs`) to skip unnecessary CI jobs
- Version modification check to prevent manual version edits in PRs
- Crates.io-based release check instead of git tag check (`check-release-needed.rs`)
- Graceful crates.io publish script with auth error handling (`publish-crate.rs`)
- Clippy lint check in CI pipeline
- Doc tests (`cargo test --doc`) in CI pipeline
- Package verification (`cargo package --list`) in CI build
- PR-diff-aware changelog fragment validation (`check-changelog-fragment.rs`)
- Changelog PR release mode for manual release workflow
- Multi-language repository path detection utility (`rust-paths.rs`)
- Case study documentation for issue #132

### Fixed

- CI/CD "Auto Release" failure caused by hard-failing on missing `CARGO_REGISTRY_TOKEN`
- Job dependency conditions now use `always() && !cancelled()` pattern for correct behavior
