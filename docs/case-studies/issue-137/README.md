# Case Study: Issue #137 — GitHub Release Failed (v0.3.0)

## Overview

- **Issue:** [#137](https://github.com/linksplatform/Numbers/issues/137)
- **Failing Run:** [23400025602](https://github.com/linksplatform/Numbers/actions/runs/23400025602)
- **Date:** 2026-03-22
- **Status:** Root cause identified and fixed in PR [#138](https://github.com/linksplatform/Numbers/pull/138).
- **Symptom:** Git tag `v0.3.0` was created and crate was published to crates.io, but the GitHub release object was never created. The version in `Cargo.toml` (`0.3.0`) and the GitHub "Latest" release (`v0.2.1`) are out of sync.

---

## Timeline / Sequence of Events

1. **2026-03-22 ~08:08 UTC** — PR #136 merged, fixing CI/CD failures from issue #135.
2. **2026-03-22 ~09:23 UTC** — Push to `main` triggers the "Auto Release" job in the Rust CI/CD pipeline.
3. **09:23–09:24 UTC** — All preceding steps succeed:
   - Detect Changes ✓
   - Lint and Format Check ✓
   - Tests (ubuntu, windows, macOS) ✓
   - Code Coverage ✓
   - Build Package ✓
   - Changelog collected and processed ✓
   - Version bumped from `0.2.x` → `0.3.0` ✓
   - `v0.3.0` Git tag created ✓
   - Crate published to crates.io ✓
4. **09:25:08 UTC** — "Create GitHub Release" step **PANICS** with exit code 101.
5. **Result:** GitHub release `v0.3.0` never created. GitHub shows `v0.2.1` as the latest release.

---

## Root Cause Analysis

### The Failing Step

The CI workflow runs (see `rust.yml`, "Create GitHub Release" step):

```bash
rust-script scripts/create-github-release.rs \
  --release-version "${{ steps.current_version.outputs.version }}" \
  --repository "${{ github.repository }}"
```

### Exact Error (from CI log `run-23400025602.log`)

```
2026-03-22T09:25:08.6365777Z Creating GitHub release for v0.3.0...
2026-03-22T09:25:08.6367525Z thread 'main' (5089) panicked at
    /home/runner/work/Numbers/Numbers/scripts/create-github-release.rs:47:35:
2026-03-22T09:25:08.6374178Z regex parse error:
    (?s)## \[0\.3\.0\].*?\n(.*?)(?=\n## \[|$)
2026-03-22T09:25:08.6374987Z error: look-around, including look-ahead and look-behind, is not supported
2026-03-22T09:25:08.6384819Z ##[error]Process completed with exit code 101.
```

### Buggy Code

In `scripts/create-github-release.rs`, lines 45–47:

```rust
let escaped_version = regex::escape(version);
let pattern = format!(r"(?s)## \[{}\].*?\n(.*?)(?=\n## \[|$)", escaped_version);
let re = Regex::new(&pattern).unwrap();
```

The pattern uses a **positive lookahead assertion** `(?=\n## \[|$)` to locate the end of a changelog section without consuming the next section's header.

### Why This Fails

Rust's [`regex`](https://docs.rs/regex) crate deliberately **does not support look-around** (lookahead or lookbehind). This is an explicit design decision: the crate guarantees linear-time matching by restricting the regex engine to finite-state automata. Lookaheads require backtracking and are incompatible with this guarantee.

From the [`regex` crate documentation](https://docs.rs/regex/latest/regex/#syntax):

> Look-around, including look-ahead and look-behind, is not supported.

The script compiled successfully during development only if it was tested with a regex that didn't trigger the `.unwrap()` panic (e.g., the pattern was never exercised, or it was developed/tested with a different regex engine such as the `fancy-regex` crate).

### Why It Wasn't Caught Earlier

1. **No unit tests for `create-github-release.rs`** — The script was never run against a real CHANGELOG.md in a test environment before the first actual release.
2. **`Regex::new(...).unwrap()` panics at runtime** — The regex is compiled at runtime, not compile time. No compile-time error occurs.
3. **The script is only exercised during an actual release** — It's not invoked during PRs, lint, or test jobs. The first time it ran was the v0.3.0 release attempt.

---

## Fix

Replace the unsupported lookahead `(?=\n## \[|$)` with a standard non-capturing group `(?:\n## \[|$)`.

**Before (broken):**
```rust
let pattern = format!(r"(?s)## \[{}\].*?\n(.*?)(?=\n## \[|$)", escaped_version);
```

**After (fixed):**
```rust
// Use a pattern without lookahead (not supported by the `regex` crate).
// Match the section header and capture everything until the next section or end of string.
let pattern = format!(r"(?s)## \[{}\][^\n]*\n(.*?)(?:\n## \[|$)", escaped_version);
```

**Changes:**
1. `.*?` after the version header → `[^\n]*` (more precisely matches the rest of the header line, e.g., ` - 2026-03-22`).
2. `(?=\n## \[|$)` (lookahead) → `(?:\n## \[|$)` (non-capturing group).

The non-capturing group consumes the `\n## [` delimiter, but since the captured group `(.*?)` stops before it and `.trim()` is called on the result, the release notes body is still extracted correctly.

**Verified via experiment** (`experiments/test-changelog-regex.rs`):
- v0.3.0 section extracted correctly, not including v0.2.1 content ✓
- v0.2.1 section extracted correctly, not including v0.3.0 content ✓
- Missing version returns fallback `"Release v9.9.9"` ✓

---

## Workaround

Since the v0.3.0 Git tag and crates.io publication already succeeded, the GitHub release was created manually:

```bash
gh release create v0.3.0 \
  --repo linksplatform/Numbers \
  --title "v0.3.0" \
  --notes "$(sed -n '/^## \[0\.3\.0\]/,/^## \[/{ /^## \[0\.3\.0\]/d; /^## \[/d; p }' CHANGELOG.md)"
```

---

## Possible Solutions (Research)

### Option 1: Fix the regex pattern (implemented)

Replace lookahead with a non-capturing group (as done in this fix). Minimal change, no new dependencies.

### Option 2: Use `fancy-regex` crate

The [`fancy-regex`](https://crates.io/crates/fancy-regex) crate is a drop-in superset of the `regex` crate that supports lookaheads and lookbehinds at the cost of potentially exponential worst-case time.

```toml
[dependencies]
fancy-regex = "0.13"
```

```rust
use fancy_regex::Regex;
let pattern = format!(r"(?s)## \[{}\].*?\n(.*?)(?=\n## \[|$)", escaped_version);
```

This would allow using the original pattern without change, but adds a new dependency.

### Option 3: Parse changelog without regex

Split the changelog content by `\n## [` and find the matching section by prefix. This is simpler and avoids any regex pitfalls:

```rust
fn get_changelog_for_version(content: &str, version: &str) -> String {
    let header = format!("## [{}]", version);
    let sections: Vec<&str> = content.split("\n## [").collect();
    for section in &sections {
        if section.starts_with(&header[3..]) { // skip leading "## "
            return section
                .splitn(2, '\n')
                .nth(1)
                .unwrap_or("")
                .trim()
                .to_string();
        }
    }
    format!("Release v{}", version)
}
```

### Option 4: Use existing tooling (`git-cliff`, `github-changelog-generator`, etc.)

Projects like [`git-cliff`](https://github.com/orhun/git-cliff) and [`release-plz`](https://github.com/MarcoIeni/release-plz) provide battle-tested changelog and release management. Adopting such a tool would replace custom scripts with maintained community solutions.

---

## Related Issues

- [#135](https://github.com/linksplatform/Numbers/issues/135) — Previous CI/CD failures (unused import, Mono not found) — fixed in PR #136
- [#127](https://github.com/linksplatform/Numbers/issues/127) — Missing `cargo publish` step — fixed in PR #128
- [#132](https://github.com/linksplatform/Numbers/issues/132) — Migration of CI/CD scripts to Rust — fixed in PR #133

---

## Artifacts

- **CI Logs:** [`ci-logs/run-23400025602.log`](ci-logs/run-23400025602.log)
- **Experiment Script:** [`../../experiments/test-changelog-regex.rs`](../../experiments/test-changelog-regex.rs)
- **Fixed Script:** [`../../scripts/create-github-release.rs`](../../scripts/create-github-release.rs)
