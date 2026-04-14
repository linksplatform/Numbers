---
bump: patch
---

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0
