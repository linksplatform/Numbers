---
bump: minor
---

### Added
- `WrappingArithmetic` composite trait bundling `WrappingAdd`, `WrappingSub`, `WrappingMul`, `WrappingNeg`, `WrappingShl`, `WrappingShr` from `num-traits`
- `WrappingArithmetic` as a supertrait of `LinkReference`, enabling downstream crates to use wrapping arithmetic with `T: LinkReference` without additional `+ WrappingAdd` bounds
