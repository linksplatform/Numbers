# Case Study: Issue #132 — CI/CD Missing Version Bump from Template

## Summary

The CI/CD pipeline in linksplatform/Numbers was failing at the "Auto Release" step
because it had diverged from the best practices established in the
[rust-ai-driven-development-pipeline-template](https://github.com/link-foundation/rust-ai-driven-development-pipeline-template).

## Timeline

- **2026-03-21T22:29:19Z**: CI/CD run [23390203130](https://github.com/linksplatform/Numbers/actions/runs/23390203130) triggered on push to main
- **2026-03-21T22:30:51Z**: "Auto Release" job failed at "Publish to Crates.io" step (job [68043615120](https://github.com/linksplatform/Numbers/actions/runs/23390203130/job/68043615120))
- All other jobs (lint, test, coverage, build) passed successfully

## Root Cause Analysis

### Primary Failure: Missing `CARGO_REGISTRY_TOKEN` Secret

The publish step used inline bash that hard-failed (`exit 1`) when no token was configured:

```bash
if [ -n "$CARGO_REGISTRY_TOKEN" ]; then
  cargo publish --token "$CARGO_REGISTRY_TOKEN"
else
  echo "::error::CARGO_REGISTRY_TOKEN or CARGO_TOKEN secret is not configured."
  exit 1  # <-- Hard failure, no graceful handling
fi
```

The template's `publish-crate.rs` script handles this more gracefully:
- Warns when no token is set but still attempts publish
- Handles "already exists" responses without failing
- Provides clear diagnostic messages for auth failures
- Uses `--allow-dirty` flag for CI contexts

### Secondary Issues: Divergence from Template

Comparing the Numbers repo's CI/CD with the template revealed multiple gaps:

| Feature | Numbers (Before) | Template | Impact |
|---------|-----------------|----------|--------|
| Script language | Node.js (.mjs) | Rust (.rs) | Dependency on Node.js runtime + unpkg.com |
| Change detection | Path filters only | `detect-code-changes.rs` | No smart job skipping |
| Version check | None | `check-version-modification.rs` | Manual version edits could break pipeline |
| Release check | Git tags | Crates.io API | Tags don't mean package published |
| Publish script | Inline bash | `publish-crate.rs` | No graceful error handling |
| Clippy | Not run | `cargo clippy --all-targets` | Missing lint coverage |
| Doc tests | Not run | `cargo test --doc` | Missing doc test coverage |
| Package check | Not run | `cargo package --list` | No package verification |
| Changelog check | Directory-based | PR-diff-based | False positives from leftover fragments |
| Changelog PR mode | Not available | `changelog-pr` | No manual changelog PR workflow |
| Job conditions | Simple `if` | `always() && !cancelled()` | Jobs could be skipped incorrectly |

## Solution

### Changes Made

1. **Migrated all scripts from Node.js (.mjs) to Rust (.rs)**
   - Eliminates runtime dependency on Node.js and external package fetching
   - All scripts use `rust-script` for execution
   - Scripts auto-detect single-language vs multi-language repo structure

2. **Added missing scripts from template**
   - `publish-crate.rs` — Graceful crates.io publishing
   - `check-release-needed.rs` — Checks crates.io instead of git tags
   - `check-version-modification.rs` — Prevents manual version edits
   - `detect-code-changes.rs` — Smart change detection
   - `git-config.rs` — Git user configuration
   - `get-version.rs` — Version extraction for CI outputs
   - `rust-paths.rs` — Multi-language path detection
   - `check-changelog-fragment.rs` — PR-diff-aware validation
   - `create-changelog-fragment.rs` — Manual changelog fragment creation

3. **Updated workflow (`rust.yml`)**
   - Added `detect-changes` job
   - Added `version-check` job
   - Added `changelog-pr` release mode
   - Added Clippy, doc tests, and package verification
   - Proper `always() && !cancelled()` job conditions
   - Replaced inline bash with Rust scripts

## Lessons Learned

1. **Check crates.io, not git tags**: Git tags can exist without the package being published. The source of truth for Rust packages is crates.io.
2. **Graceful publish handling**: The publish step should handle "already exists" and auth failures gracefully instead of hard-failing.
3. **Smart change detection**: Running all CI jobs for every change is wasteful. Detect what changed and skip unnecessary jobs.
4. **PR-diff changelog checks**: Checking for fragments in the directory can give false positives when leftover fragments from previous releases exist. Check the PR diff instead.

## Data Files

- `ci-logs/ci-run-23390203130.log.gz` — Full CI/CD run log from the failing run
