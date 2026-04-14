---
bump: minor
---

### Added
- `TryFrom<T>` and `TryInto<T>` bounds (with `Error: Debug`) for all 12 integer types on `LinkReference`
- `funty(n: u8) -> Self` default method on `LinkReference` for creating small constants from `u8` values
- `Sized` bound on `LinkReference`
