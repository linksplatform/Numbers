# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

<!-- changelog-insert-here -->






## [0.8.0] - 2026-04-14

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0

### Changed
- Rename Rust traits to use full English words: `Num` → `Number`, `SignNum` → `SignedNumber`, `LinkType` → `LinkReference`
- Add documentation comments to all public traits with examples

### Changed
- Upgrade Rust edition from 2021 to 2024 (stable since Rust 1.85)
- Bump MSRV from 1.70 to 1.85 (required for edition 2024)
- Move tests from `src/imp.rs` to `tests/traits.rs` as proper integration tests

### Fixed
- Fix CONTRIBUTING.md incorrectly stating "nightly toolchain" (project uses stable)
- Fix README.md showing outdated install version `0.4` instead of `0.5`
- Regenerate Cargo.lock to match current version (0.5.0)

### Added
- Implement `for_each_integer_type!` macro (resolves TODO)
- Document IDE alias design decision for `LinkReference` trait (resolves TODO)
- Add 8 new integration tests (total: 75 integration + 6 doc tests)
- Add crate-level documentation in `lib.rs`
- Add automated rustdoc deployment to GitHub Pages after release
- Add case study documentation for issue #142 audit findings

### Added
- `TryFrom<T>` and `TryInto<T>` bounds (with `Error: Debug`) for all 12 integer types on `LinkReference`
- `from_byte(n: u8) -> Self` default method on `LinkReference` for creating small constants from `u8` values
- `Sized` bound on `LinkReference`
- Explicit `u128` support as a `LinkReference` type (enables referencing very large link address spaces)

### Added
- `WrappingArithmetic` composite trait bundling `WrappingAdd`, `WrappingSub`, `WrappingMul`, `WrappingNeg`, `WrappingShl`, `WrappingShr` from `num-traits`
- `WrappingArithmetic` as a supertrait of `LinkReference`, enabling downstream crates to use wrapping arithmetic with `T: LinkReference` without additional `+ WrappingAdd` bounds

## [0.7.0] - 2026-04-14

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0

### Changed
- Rename Rust traits to use full English words: `Num` → `Number`, `SignNum` → `SignedNumber`, `LinkType` → `LinkReference`
- Add documentation comments to all public traits with examples

### Changed
- Upgrade Rust edition from 2021 to 2024 (stable since Rust 1.85)
- Bump MSRV from 1.70 to 1.85 (required for edition 2024)
- Move tests from `src/imp.rs` to `tests/traits.rs` as proper integration tests

### Fixed
- Fix CONTRIBUTING.md incorrectly stating "nightly toolchain" (project uses stable)
- Fix README.md showing outdated install version `0.4` instead of `0.5`
- Regenerate Cargo.lock to match current version (0.5.0)

### Added
- Implement `for_each_integer_type!` macro (resolves TODO)
- Document IDE alias design decision for `LinkReference` trait (resolves TODO)
- Add 8 new integration tests (total: 75 integration + 6 doc tests)
- Add crate-level documentation in `lib.rs`
- Add automated rustdoc deployment to GitHub Pages after release
- Add case study documentation for issue #142 audit findings

### Added
- `TryFrom<T>` and `TryInto<T>` bounds (with `Error: Debug`) for all 12 integer types on `LinkReference`
- `from_byte(n: u8) -> Self` default method on `LinkReference` for creating small constants from `u8` values
- `Sized` bound on `LinkReference`
- Explicit `u128` support as a `LinkReference` type (enables referencing very large link address spaces)

## [0.6.0] - 2026-04-11

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0

### Changed
- Rename Rust traits to use full English words: `Num` → `Number`, `SignNum` → `SignedNumber`, `LinkType` → `LinkReference`
- Add documentation comments to all public traits with examples

### Changed
- Upgrade Rust edition from 2021 to 2024 (stable since Rust 1.85)
- Bump MSRV from 1.70 to 1.85 (required for edition 2024)
- Move tests from `src/imp.rs` to `tests/traits.rs` as proper integration tests

### Fixed
- Fix CONTRIBUTING.md incorrectly stating "nightly toolchain" (project uses stable)
- Fix README.md showing outdated install version `0.4` instead of `0.5`
- Regenerate Cargo.lock to match current version (0.5.0)

### Added
- Implement `for_each_integer_type!` macro (resolves TODO)
- Document IDE alias design decision for `LinkReference` trait (resolves TODO)
- Add 8 new integration tests (total: 75 integration + 6 doc tests)
- Add crate-level documentation in `lib.rs`
- Add automated rustdoc deployment to GitHub Pages after release
- Add case study documentation for issue #142 audit findings

## [0.5.0] - 2026-03-23

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0

### Changed
- Rename Rust traits to use full English words: `Num` → `Number`, `SignNum` → `SignedNumber`, `LinkType` → `LinkReference`
- Add documentation comments to all public traits with examples

## [0.4.0] - 2026-03-22

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning

### Fixed

- Fixed panic in `scripts/create-github-release.rs` caused by unsupported regex lookahead assertion `(?=...)` in Rust's `regex` crate, which prevented GitHub release creation for v0.3.0

## [0.3.0] - 2026-03-22

### Added
- 100% test coverage for all Rust code (67 tests total)
- Comprehensive unit tests for all traits: `Num`, `SignNum`, `ToSigned`, `MaxValue`, `LinkType`
- Edge case tests for unsigned to signed conversion (wrapping behavior)
- Integration tests for combined trait usage
- CI/CD pipeline with GitHub Actions for automated testing, linting, and releases
- Code coverage reporting with cargo-llvm-cov
- Changelog fragment system for automated version management
- Contributing guidelines with development workflow documentation
- Pre-commit hooks configuration for code quality checks

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

### Fixed

- Corrected license declaration in `rust/Cargo.toml` from `LGPL-3.0` to `Unlicense` (public domain)
- Updated license description in `CONTRIBUTING.md` from `LGPL-3.0` to `Unlicense (public domain)`

### Changed

- Added Unlicense badge to all README files (root, Rust, C#, C++)
- Added License section to all README files explaining the Unlicense and its advantages over LGPL

### Fixed
- Added missing `cargo publish` step to CI/CD pipeline, fixing issue where releases
  were created on GitHub but never published to crates.io (#127)
- Fixed deprecated `::set-output` command in `version-and-commit.mjs`
- Added `RUSTFLAGS: -Dwarnings` to CI/CD pipeline for stricter compilation checks

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

### Added

- Rust-specific README.md with detailed description,
  usage examples, and crate badges
- C# language-specific README.md with namespace docs,
  installation, and usage examples
- C++ language-specific README.md with Conan
  installation and usage info

### Changed

- Root README.md now uses a badge table for all
  language versions (C#, C++, Rust)
- Replaced Gitpod badge with GitHub Codespaces badge
- Updated Cargo.toml readme field to point to
  Rust-specific README.md

### Fixed

- Rust crate on crates.io was displaying generic root
  README instead of Rust-specific documentation

### Fixed

- Removed unused `std::process::exit` import from `scripts/get-bump-type.rs` that caused a compiler warning