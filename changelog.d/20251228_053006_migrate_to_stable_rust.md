---
bump: minor
---

### Changed
- Migrated from nightly Rust (nightly-2022-08-22) to stable Rust toolchain
- Updated Rust edition from 2018 to 2021
- Updated `num-traits` dependency from 0.2.14 to 0.2.19
- Set minimum Rust version (MSRV) to 1.70

### Removed
- **BREAKING**: Removed `Step` trait bound from `LinkType` trait
  - The `std::iter::Step` trait remains unstable in Rust (tracking issue #42168)
  - Types implementing `LinkType` no longer need to implement `Step`
  - This is required for stable Rust compatibility
- Removed `#![feature(step_trait)]` and `#![feature(trait_alias)]` feature flags
