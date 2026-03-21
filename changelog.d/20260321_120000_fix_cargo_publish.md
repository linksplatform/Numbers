---
bump: patch
---

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks
