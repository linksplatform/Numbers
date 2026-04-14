[![Unlicense](https://img.shields.io/badge/license-Unlicense-blue.svg)](http://unlicense.org/)
[![Crates.io](https://img.shields.io/crates/v/platform-num?label=crates.io&style=flat)](https://crates.io/crates/platform-num)
[![Rust CI/CD Pipeline](https://github.com/linksplatform/Numbers/workflows/Rust%20CI%2FCD%20Pipeline/badge.svg)](https://github.com/linksplatform/Numbers/actions?workflow=Rust+CI%2FCD+Pipeline)
[![Docs.rs](https://docs.rs/platform-num/badge.svg)](https://docs.rs/platform-num)
[![Codecov](https://codecov.io/gh/linksplatform/Numbers/branch/main/graph/badge.svg)](https://codecov.io/gh/linksplatform/Numbers)

# [Numbers](https://github.com/linksplatform/Numbers) for Rust

LinksPlatform's `platform-num` crate — numeric traits and types
for the Links platform.

Crates.io package: [platform-num](https://crates.io/crates/platform-num)

## Overview

This crate provides a set of numeric traits used throughout the
LinksPlatform ecosystem:

- **`Number`** — A base trait combining `PrimInt`, `Default`, `Debug`,
  `AsPrimitive<usize>`, and `ToPrimitive`. Implemented for all
  primitive integer types.
- **`SignedNumber`** — Extends `Number` with signed number operations
  (`Signed`, `FromPrimitive`). Implemented for signed integer types.
- **`ToSigned`** — Converts unsigned types to their signed
  counterparts (e.g. `u32` → `i32`).
- **`MaxValue`** — Provides a `MAX` associated constant for all
  primitive integer types.
- **`LinkReference`** — A composite trait for types that can be used as
  link identifiers: `Number + Unsigned + ToSigned + MaxValue +
  FromPrimitive + Debug + Display + Hash + Send + Sync + 'static`.
  Implemented for `u8`, `u16`, `u32`, `u64`, and `usize`.

## Installation

Add to your `Cargo.toml`:

```toml
[dependencies]
platform-num = "0.5"
```

## Usage

### Using `LinkReference` as a generic constraint

```rust
use platform_num::LinkReference;

fn create_link<T: LinkReference>(source: T, target: T) -> (T, T) {
    (source, target)
}

let link = create_link(1u64, 2u64);
assert_eq!(link, (1u64, 2u64));
```

### Using `ToSigned` for type conversion

```rust
use platform_num::ToSigned;

let unsigned_val: u32 = 42;
let signed_val: i32 = unsigned_val.to_signed();
assert_eq!(signed_val, 42i32);
```

### Using `MaxValue`

```rust
use platform_num::MaxValue;

fn get_max<T: MaxValue>() -> T {
    T::MAX
}

assert_eq!(get_max::<u64>(), u64::MAX);
```

### Using `Number` for generic numeric operations

```rust
use platform_num::Number;
use num_traits::AsPrimitive;

fn to_usize<T: Number>(val: T) -> usize {
    val.as_()
}

assert_eq!(to_usize(42u32), 42usize);
```

## Depend on

- [num-traits](https://crates.io/crates/num-traits)

## Dependent libraries

- [platform-trees](https://crates.io/crates/platform-trees)
  ([trees-rs](https://github.com/linksplatform/trees-rs))
- [doublets](https://crates.io/crates/doublets)
  ([doublets-rs](https://github.com/linksplatform/doublets-rs))

## License

This crate is released to the **public domain** under the [Unlicense](http://unlicense.org/).

The Unlicense is the most permissive license available — it places no
restrictions whatsoever on users. You are free to copy, modify, publish,
use, compile, sell, or distribute this software for any purpose,
commercial or non-commercial, in any way you choose, with no conditions
attached.

Unlike LGPL, which forces users to redistribute modifications under the
same license and comply with specific obligations (linking restrictions,
source disclosure for modifications), the Unlicense imposes
**no obligations at all**. It is truly free as in freedom.
