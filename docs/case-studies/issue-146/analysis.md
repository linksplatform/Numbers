# Case Study: Issue #146 — Add WrappingAdd to LinkReference Trait Bounds

## Timeline / Sequence of Events

| Date | Event | Repository |
|------|-------|-----------|
| 2026-04-13 | doublets-rs#47 opened — quality audit requiring latest dependencies and trait unification | linksplatform/doublets-rs |
| 2026-04-14 | data-rs#16 opened — Replace funty dependency with platform-num (`LinkReference`) | linksplatform/data-rs |
| 2026-04-14 | data-rs#17 PR opened — Implements the replacement, discovers `WrappingAdd` gap | linksplatform/data-rs |
| 2026-04-14 | Numbers#146 opened — Request to add `WrappingAdd` to `LinkReference` trait bounds | linksplatform/Numbers |
| 2026-04-14 | Numbers#147 PR opened — Implementation of `WrappingArithmetic` composite trait | linksplatform/Numbers |

## Requirements from the Issue

### R1: Add wrapping arithmetic to `LinkReference` supertraits (Original request)
The original issue requested adding `WrappingAdd` from `num-traits` to `LinkReference` so downstream crates don't need explicit `+ WrappingAdd` bounds.

### R2: Better naming than `WrappingAdd` (From comment by @konard)
The maintainer disliked the name `WrappingAdd` and suggested something like `AdditionCapable`. They asked to check if similar traits already exist in `num-traits`.

### R3: Support similar operations for other arithmetic ops (From comment by @konard)
Not just `WrappingAdd` — all wrapping arithmetic operations normally supported by numeric types should be included.

### R4: Compile data and perform deep case study analysis (From comment by @konard)
Download all logs and data related to the issue, compile to `./docs/case-studies/issue-146` folder, reconstruct timeline, find root causes, propose solutions.

## Root Cause Analysis

### Root Cause 1: Trait ecosystem fragmentation
The Rust ecosystem has two competing unsigned integer trait crates:
- `funty` (provides `funty::Unsigned`)
- `num-traits` (provides `num_traits::Unsigned`)

`platform-data` used `funty::Unsigned` while `platform-num` (Numbers) used `num_traits::Unsigned`. These are **different traits from different crates**, even though they represent the same concept. This made it impossible to write unified `T: data::LinkType + trees::LinkType` bounds.

### Root Cause 2: Missing wrapping arithmetic in `PrimInt`
The `PrimInt` trait from `num-traits` (which is a supertrait of `Number`) provides **non-wrapping** arithmetic. The wrapping variants (`WrappingAdd`, `WrappingSub`, `WrappingMul`, `WrappingNeg`, `WrappingShl`, `WrappingShr`) are separate traits in `num_traits::ops::wrapping`. This means code that needs wrapping semantics (like `Hybrid` in `platform-data`) must add extra trait bounds.

### Root Cause 3: No composite wrapping trait in `num-traits`
Unlike `PrimInt` which bundles many non-wrapping operations, `num-traits` does **not** provide a composite trait that bundles all wrapping operations. Each wrapping operation is a separate trait, leading to verbose bounds like `T: WrappingAdd + WrappingSub + WrappingMul + WrappingNeg`.

## Solution Implemented

### Approach: Composite `WrappingArithmetic` trait

Created a new `WrappingArithmetic` composite trait in `platform-num` that bundles all six wrapping arithmetic traits from `num-traits`:

```rust
pub trait WrappingArithmetic:
    WrappingAdd + WrappingSub + WrappingMul + WrappingNeg + WrappingShl + WrappingShr
{}
```

With a blanket implementation for any type that implements all six traits.

Then added `WrappingArithmetic` as a supertrait of `LinkReference`.

### Why this approach

1. **Addresses naming concern**: `WrappingArithmetic` is descriptive and covers all operations, not just addition
2. **Broader than requested**: Includes all 6 wrapping traits, not just `WrappingAdd`
3. **Compatible addition**: All unsigned primitive integer types already implement all 6 wrapping traits
4. **Follows existing patterns**: Same composite trait pattern as `Number` (which bundles `PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive`)
5. **Preserves ecosystem naming**: Individual traits retain their `num-traits` names; the composite provides a convenient bundle

### Alternatives Considered

| Alternative | Pros | Cons |
|------------|------|------|
| Add only `WrappingAdd` | Minimal change | Doesn't address other wrapping ops; name issue remains |
| Add individual traits directly to `LinkReference` | No new trait needed | Longer trait definition; no reusable composite |
| Create `AdditionCapable` trait | Addresses naming | Too narrow; name implies only addition |
| Re-export `WrappingAdd` as a different name | Simple | Confusing; diverges from ecosystem naming |

## Impact on Downstream Crates

### `platform-data` (data-rs#17)
Currently the PR uses `T: LinkReference + WrappingAdd` everywhere. After this change is released as `platform-num` 0.8.0, `data-rs` can:
1. Remove the explicit `num-traits` dependency
2. Replace `T: LinkReference + WrappingAdd` with just `T: LinkReference`
3. All wrapping operations will be available through the `LinkReference` bound

### `doublets-rs`
Can use a single `T: LinkReference` bound for all numeric operations including wrapping arithmetic.

## Verification

- All 112 unit tests pass (96 existing + 16 new wrapping arithmetic tests)
- All 7 doc tests pass (including new `WrappingArithmetic` doctest)
- `cargo clippy --all-targets` reports zero warnings
- Verified that all 6 wrapping traits are implemented for `u8`, `u16`, `u32`, `u64`, `u128`, `usize`

## Related Issues and PRs

| Reference | Repository | Description |
|-----------|-----------|-------------|
| [#146](https://github.com/linksplatform/Numbers/issues/146) | Numbers | This issue — Add WrappingAdd to LinkReference |
| [#147](https://github.com/linksplatform/Numbers/pull/147) | Numbers | This PR — Implementation |
| [#16](https://github.com/linksplatform/data-rs/issues/16) | data-rs | Replace funty with platform-num |
| [#17](https://github.com/linksplatform/data-rs/pull/17) | data-rs | PR implementing funty replacement |
| [#47](https://github.com/linksplatform/doublets-rs/issues/47) | doublets-rs | Quality audit driving the unification |

## References

- [num-traits wrapping module documentation](https://docs.rs/num-traits/latest/num_traits/ops/wrapping/)
- [PrimInt trait documentation](https://docs.rs/num-traits/latest/num_traits/int/trait.PrimInt.html) — provides non-wrapping arithmetic
- [Rust RFC #1530](https://github.com/rust-lang/rfcs/issues/1530) — Discussion on WrappingAdd, WrappingSub, WrappingMul, WrappingDiv traits
