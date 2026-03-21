# Case Study: Issue #127 - No New Rust Version Released at Manual Release

## Summary

A manual release triggered via `workflow_dispatch` on 2026-03-21 completed successfully
(all CI jobs passed, GitHub Release was created) but **no new version was published to
crates.io**. The pipeline appeared to succeed, masking the fact that the most critical
release step — publishing to crates.io — was entirely absent from the workflow.

## Timeline of Events

| Time (UTC)           | Event                                                              |
|---------------------|--------------------------------------------------------------------|
| 2026-03-21 11:27:55 | Manual workflow_dispatch triggered with `bump_type: patch`, `description: "Test release"` |
| 2026-03-21 11:28:14 | CI run [23378672204](https://github.com/linksplatform/Numbers/actions/runs/23378672204) starts |
| 2026-03-21 11:28:16 | Manual Release job checks out `main` at commit `c2dfaf7` |
| 2026-03-21 11:28:22 | Changelog fragments collected for version `0.2.0` (2 fragments deleted) |
| 2026-03-21 11:28:22 | `version-and-commit.mjs` runs with `--bump-type "patch"` |
| 2026-03-21 11:28:27 | Script determines new version would be `0.2.1`, but tag `v0.2.1` already exists |
| 2026-03-21 11:28:27 | Outputs: `already_released=true`, `new_version=0.2.1` |
| 2026-03-21 11:28:38 | `cargo build --release` succeeds (building `platform-num v0.2.0`) |
| 2026-03-21 11:28:40 | GitHub Release `v0.2.1` created successfully |
| 2026-03-21 11:28:41 | **Pipeline completes with SUCCESS status** |

**Result**: GitHub Release exists for `v0.2.1`, but crates.io still only has two ancient
alpha versions (`0.1.0-aplha.0` from 2022-04-07 and `0.1.0-aplha.1` from 2022-06-28).

## Root Cause Analysis

### Primary Root Cause: Missing `cargo publish` Step

The `rust.yml` workflow has **no `cargo publish` step** in either the `auto-release` or
`manual-release` jobs. Comparing against the
[template](https://github.com/link-foundation/rust-ai-driven-development-pipeline-template):

**Template has (in both auto-release and manual-release jobs):**
```yaml
- name: Publish to Crates.io
  if: steps.check.outputs.should_release == 'true'
  id: publish-crate
  env:
    CARGO_TOKEN: ${{ secrets.CARGO_TOKEN }}
  run: rust-script scripts/publish-crate.rs
```

**Numbers repo (`rust.yml`):** This step is completely absent. The workflow goes directly
from `Build release` to `Create GitHub Release`, skipping the actual crate publication.

### Secondary Issue: Version Already Tagged

When the manual release ran, tag `v0.2.1` already existed from a previous release attempt.
The `version-and-commit.mjs` script detected this and set `already_released=true`, which
caused the build and GitHub Release steps to proceed (they check for
`version_committed == 'true' || already_released == 'true'`), but the version in
`Cargo.toml` was never bumped from `0.2.0`.

This means the GitHub Release for `v0.2.1` was created but the actual code on `main`
still has `version = "0.2.0"` in `Cargo.toml`.

### Tertiary Issue: Deprecated `set-output` Warning

The `version-and-commit.mjs` script (line 64) uses `::set-output` syntax which is
deprecated. While the script also correctly writes to `GITHUB_OUTPUT` file (line 61),
the deprecated log line triggers CI warnings.

### Additional Finding: No `CARGO_TOKEN` Secret Configuration

The template references `CARGO_REGISTRY_TOKEN` or `CARGO_TOKEN` secrets. These may not
be configured in the Numbers repository, which would cause `cargo publish` to fail even
after the step is added. This needs to be verified by a repository administrator.

## Impact

- **crates.io**: No stable version of `platform-num` has ever been published. Users
  cannot `cargo add platform-num` to get a stable release.
- **GitHub Releases**: A `v0.2.1` release was created on GitHub but does not correspond
  to any published crate version.
- **Changelog fragments**: The 2 changelog fragments were deleted during this run,
  losing their content from the `changelog.d/` directory.

## Differences Between Numbers CI/CD and Template Best Practices

| Feature | Template | Numbers | Status |
|---------|----------|---------|--------|
| `cargo publish` to crates.io | Yes (`publish-crate.rs`) | **Missing** | Critical |
| `CARGO_TOKEN` / `CARGO_REGISTRY_TOKEN` env | Configured | **Not referenced** | Critical |
| `RUSTFLAGS: -Dwarnings` | Yes | Missing | Recommended |
| Change detection (skip CI for docs-only) | Yes (`detect-code-changes.rs`) | No (path filters only) | Nice-to-have |
| Version protection check | Yes (`check-version-modification.rs`) | No | Nice-to-have |
| Clippy linting | Yes | No | Recommended |
| `changelog-pr` release mode | Yes | No | Nice-to-have |
| Scripts in Rust (`rust-script`) | Yes | Node.js (`.mjs`) | Neutral |
| Deprecated `set-output` usage | None | Present in `version-and-commit.mjs` | Minor |

## Proposed Fix

1. **Add `cargo publish` step** to both `auto-release` and `manual-release` jobs in
   `rust.yml`, positioned after `Build release` and before `Create GitHub Release`.
2. **Add `CARGO_REGISTRY_TOKEN` environment variable** support (using the same pattern
   as the template).
3. **Remove deprecated `set-output`** log line from `version-and-commit.mjs`.
4. **Repository administrator action required**: Configure `CARGO_TOKEN` or
   `CARGO_REGISTRY_TOKEN` secret in the repository settings with a valid crates.io
   API token.

## Files Referenced

- `.github/workflows/rust.yml` — CI/CD pipeline (missing `cargo publish`)
- `scripts/version-and-commit.mjs` — Version bump script (deprecated `set-output`)
- `rust/Cargo.toml` — Package metadata (version `0.2.0`)
- CI run logs: Available via [GitHub Actions run 23378672204](https://github.com/linksplatform/Numbers/actions/runs/23378672204)

## References

- Issue: https://github.com/linksplatform/Numbers/issues/127
- Failed CI run: https://github.com/linksplatform/Numbers/actions/runs/23378672204
- Template: https://github.com/link-foundation/rust-ai-driven-development-pipeline-template
- crates.io page: https://crates.io/crates/platform-num/versions
