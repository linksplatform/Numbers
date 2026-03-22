# Case Study: Issue #135 — CI/CD Auto Release Failure

## Overview

- **Issue:** [#135](https://github.com/linksplatform/Numbers/issues/135)
- **Failing Run:** [23398717024](https://github.com/linksplatform/Numbers/actions/runs/23398717024)
- **Date:** 2026-03-22
- **Job:** Auto Release → "Determine bump type from changelog fragments"
- **Status:** Root cause identified and fixed.

---

## Timeline / Sequence of Events

1. Commit `bde6c03` was pushed to `main` (merge of PR #134).
2. The Rust CI/CD Pipeline was triggered.
3. All jobs passed except **Auto Release**.
4. The "Determine bump type from changelog fragments" step ran `rust-script scripts/get-bump-type.rs`.
5. The Rust compiler emitted a fatal error due to `RUSTFLAGS: -Dwarnings` treating unused imports as errors.
6. `rust-script` exited with code 1, failing the step and the entire Auto Release job.

---

## Root Cause Analysis

### Primary Root Cause

In `scripts/get-bump-type.rs`, line 30 contained:

```rust
use std::process::exit;
```

This import is **never used** anywhere in the file. All other scripts that import `exit` do call it; only `get-bump-type.rs` does not.

### Why It Became a Fatal Error

The CI workflow (`rust.yml`, line 48) sets:

```yaml
env:
  RUSTFLAGS: -Dwarnings
```

The `-Dwarnings` flag promotes all Rust compiler warnings to errors. The `unused-imports` lint (normally a warning) became a compile error, preventing `rust-script` from building and running the script.

### Why Other Scripts Were Not Affected

All other scripts that declare `use std::process::exit;` actually call `exit()`:

| Script | Uses `exit()`? |
|--------|----------------|
| `bump-version.rs` | Yes (5 calls) |
| `check-file-size.rs` | Yes (2 calls) |
| `check-release-needed.rs` | Yes (3 calls) |
| `collect-changelog.rs` | Yes (3 calls) |
| `create-changelog-fragment.rs` | Yes (3 calls) |
| `get-version.rs` | Yes (2 calls) |
| **`get-bump-type.rs`** | **No — dead import** |

### Why the Import Was Present

The `get-bump-type.rs` script was likely refactored at some point to use Rust's `std::process::exit()` for error handling, then changed to use `return` or `eprintln!` patterns instead, leaving the `use` statement behind without removing it.

---

## Impact

- Auto Release job blocked on every push to `main`.
- Automated versioning and crate publishing could not proceed.
- No production code or tests were affected — only the release automation script.

---

## Fix

Remove the unused import from `scripts/get-bump-type.rs`:

```diff
-use std::process::exit;
 use regex::Regex;
```

This is a one-line change. No functional behavior is altered.

---

## CI Log Evidence

From `ci-logs/run-23398717024-failed.log`:

```
error: unused import: `std::process::exit`
  --> /home/runner/work/Numbers/Numbers/scripts/get-bump-type.rs:30:5
   |
30 | use std::process::exit;
   |     ^^^^^^^^^^^^^^^^^^
   |
   = note: `-D unused-imports` implied by `-D warnings`
   = help: to override `-D warnings` add `#[allow(unused_imports)]`

error: could not compile `get-bump-type_412c20687aa3a320be6ee72f` due to 1 previous error
error: Could not execute cargo
```

---

## Additional Notes

### Node.js 20 Deprecation Warnings

The CI run also contained annotations about Node.js 20 actions being deprecated
(`actions/checkout@v4`, `actions/cache@v4`, `codecov/codecov-action@v4`).
These are warnings only and do not cause failures yet. GitHub will force Node.js 24
by default starting **June 2nd, 2026**. These should be addressed before that date.
Updating to the latest versions of those actions should resolve the warnings.

### Possible Future Improvement

Consider adding a lint step that runs `rust-script --check` or simply compiles
all scripts in CI to catch such issues earlier (before the Auto Release stage).
Alternatively, scripts could be wrapped in a Cargo workspace for better lint coverage.
