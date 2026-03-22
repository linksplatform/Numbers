# Case Study: Issue #135 — CI/CD Failures in Rust and C# Pipelines

## Overview

- **Issue:** [#135](https://github.com/linksplatform/Numbers/issues/135)
- **Failing Runs:**
  - Rust: [23398717024](https://github.com/linksplatform/Numbers/actions/runs/23398717024)
  - C#: [23398717023](https://github.com/linksplatform/Numbers/actions/runs/23398717023)
- **Date:** 2026-03-22
- **Status:** Root causes identified and fixed.

---

## Timeline / Sequence of Events

1. Commit `bde6c03` was pushed to `main` (merge of PR #134).
2. Both the Rust CI/CD Pipeline and the C# workflow were triggered.
3. **Rust:** All jobs passed except **Auto Release** — the "Determine bump type from changelog fragments" step failed.
4. **C#:** All jobs passed except **pushNuGetPackageToGitHubPackageRegistry** — the `nuget source Add` command failed.

---

## Root Cause Analysis

### Rust CI Failure: Unused Import in get-bump-type.rs

**Primary Root Cause:**

In `scripts/get-bump-type.rs`, line 30 contained:

```rust
use std::process::exit;
```

This import is **never used** anywhere in the file. All other scripts that import `exit` do call it; only `get-bump-type.rs` does not.

**Why It Became a Fatal Error:**

The CI workflow (`rust.yml`, line 48) sets:

```yaml
env:
  RUSTFLAGS: -Dwarnings
```

The `-Dwarnings` flag promotes all Rust compiler warnings to errors. The `unused-imports` lint (normally a warning) became a compile error, preventing `rust-script` from building and running the script.

**Fix:** Remove the unused import from `scripts/get-bump-type.rs`.

### C# CI Failure: Mono Not Found on Ubuntu 24.04

**Primary Root Cause:**

The `pushNuGetPackageToGitHubPackageRegistry` job used `nuget/setup-nuget@v1` to install `nuget.exe`, then ran:

```yaml
nuget source Add -Name "GitHub" -Source "https://nuget.pkg.github.com/linksplatform/index.json" ...
nuget push **/*.nupkg -Source "GitHub" -SkipDuplicate
```

On Linux, `nuget.exe` is a .NET Framework executable that requires **Mono** to run. Ubuntu 24.04 GitHub-hosted runners **do not have Mono pre-installed**, resulting in:

```
/opt/hostedtoolcache/nuget.exe/7.3.0/x64/nuget: 2: mono: not found
##[error]Process completed with exit code 127.
```

**How Long This Has Been Broken:**

This same failure occurred in CI run [16390287640](https://github.com/linksplatform/Numbers/actions/runs/16390287640) on **2025-07-19**, confirming the issue has persisted for at least **8 months**.

**Fix:** Replace `nuget.exe` CLI commands with `dotnet nuget` commands, which are part of the .NET SDK already installed on the runner:

```yaml
# Before (requires Mono):
- uses: nuget/setup-nuget@v1
- run: |
    nuget source Add -Name "GitHub" -Source "..." -UserName ... -Password ...
    nuget push **/*.nupkg -Source "GitHub" -SkipDuplicate

# After (uses dotnet SDK directly):
- run: |
    dotnet nuget add source "..." --name "GitHub" --username ... --password ... --store-password-in-clear-text
    dotnet nuget push ./**/*.nupkg --source "GitHub" --skip-duplicate
```

### Additional Issues Fixed in C# Workflow

| Issue | Before | After | Why |
|-------|--------|-------|-----|
| Outdated checkout action | `actions/checkout@v1` | `actions/checkout@v4` | v1 is 5+ years old, missing security fixes and features |
| Outdated changed-files action | `tj-actions/changed-files@v21` | `tj-actions/changed-files@v46` | v21 is outdated, potential security/compatibility issues |
| Deprecated set-output syntax | `::set-output name=...::` | `>> "$GITHUB_OUTPUT"` | set-output was deprecated in Oct 2022, will be removed |
| Node.js 20 deprecation | `nuget/setup-nuget@v1` | Removed (not needed) | Node.js 20 actions deprecated, forced to Node.js 24 from June 2026 |

---

## Impact

### Rust
- Auto Release job blocked on every push to `main`.
- Automated versioning and crate publishing could not proceed.
- No production code or tests were affected — only the release automation script.

### C#
- GitHub Package Registry publishing has been broken since at least July 2025.
- NuGet.org publishing (`pusnToNuget` job) was **not affected** — it uses `dotnet nuget push` and continued to work.
- The failure did not block other C# CI jobs (test, release, NuGet.org publish all succeeded).

---

## CI Log Evidence

### Rust (run 23398717024)

From `ci-logs/rust-23398717024.log`:

```
error: unused import: `std::process::exit`
  --> /home/runner/work/Numbers/Numbers/scripts/get-bump-type.rs:30:5
   |
30 | use std::process::exit;
   |     ^^^^^^^^^^^^^^^^^^
   |
   = note: `-D unused-imports` implied by `-D warnings`

error: could not compile `get-bump-type_412c20687aa3a320be6ee72f` due to 1 previous error
error: Could not execute cargo
```

### C# (run 23398717023)

From `ci-logs/csharp-23398717023.log`:

```
Successfully created package '/home/runner/work/Numbers/Numbers/csharp/Platform.Numbers/bin/Release/Platform.Numbers.0.9.0.nupkg'.
Successfully created package '/home/runner/work/Numbers/Numbers/csharp/Platform.Numbers/bin/Release/Platform.Numbers.0.9.0.snupkg'.
/opt/hostedtoolcache/nuget.exe/7.3.0/x64/nuget: 2: mono: not found
##[error]Process completed with exit code 127.
```

---

## Additional Notes

### Node.js 20 Deprecation Warnings

Both workflows contained annotations about Node.js 20 actions being deprecated.
GitHub will force Node.js 24 by default starting **June 2nd, 2026**.
The C# workflow fix addresses this by removing the `nuget/setup-nuget@v1` dependency
and updating all actions to their latest versions.

### Possible Future Improvements

1. **Rust:** Consider adding a lint step that compiles all scripts to catch import issues earlier.
2. **C#:** Consider adding a PR-triggered CI check (currently C# workflow only runs on push to main).
3. **C#:** The `pusnToNuget` and `publiseRelease` job names contain typos — consider renaming for clarity in a future PR.
