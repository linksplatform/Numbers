---
bump: minor
---

### Added
- `TryFrom<T>` and `TryInto<T>` bounds (with `Error: Debug`) for all 12 integer types on `LinkReference`
- `from_byte(n: u8) -> Self` default method on `LinkReference` for creating small constants from `u8` values
- `Sized` bound on `LinkReference`
