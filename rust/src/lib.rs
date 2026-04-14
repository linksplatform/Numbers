//! # platform_num
//!
//! Numeric traits for the [Links Platform](https://github.com/linksplatform).
//!
//! This crate provides a set of marker and conversion traits that abstract
//! over Rust's primitive integer types. They are used throughout the Links
//! Platform ecosystem to write generic code that works with any integer
//! type while preserving type safety.
//!
//! ## Traits
//!
//! | Trait | Description |
//! |-------|-------------|
//! | [`Number`] | Base numeric trait — any `PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive` |
//! | [`SignedNumber`] | Extends [`Number`] with signed operations (`Signed + FromPrimitive`) |
//! | [`ToSigned`] | Converts an unsigned type to its signed counterpart (e.g. `u32` → `i32`) |
//! | [`MaxValue`] | Provides a `MAX` associated constant for every primitive integer type |
//! | [`WrappingArithmetic`] | Composite trait for wrapping arithmetic — bundles `WrappingAdd`, `WrappingSub`, `WrappingMul`, `WrappingNeg`, `WrappingShl`, `WrappingShr` |
//! | [`LinkReference`] | Composite trait for link identifiers — unsigned, hashable, displayable, thread-safe, with wrapping arithmetic and `TryFrom`/`TryInto` for all integer types |
//!
//! ## Re-exported `num-traits`
//!
//! All `num-traits` traits that appear in this crate's supertraits are
//! re-exported so that downstream crates can use them without adding
//! `num-traits` as a direct dependency:
//!
//! | Re-export | Used in |
//! |-----------|---------|
//! | [`PrimInt`] | [`Number`] |
//! | [`AsPrimitive`] | [`Number`] |
//! | [`ToPrimitive`] | [`Number`] |
//! | [`FromPrimitive`] | [`SignedNumber`], [`LinkReference`] |
//! | [`Signed`] | [`SignedNumber`] |
//! | [`Unsigned`] | [`LinkReference`] |
//! | [`WrappingAdd`], [`WrappingSub`], [`WrappingMul`], [`WrappingNeg`], [`WrappingShl`], [`WrappingShr`] | [`WrappingArithmetic`] |
//!
//! ## Example
//!
//! ```
//! use platform_num::{LinkReference, MaxValue, Number, SignedNumber, ToSigned};
//!
//! fn max_link<T: LinkReference>() -> T {
//!     T::MAX
//! }
//!
//! assert_eq!(max_link::<u32>(), u32::MAX);
//! ```

mod imp;
pub mod math;

pub use imp::{LinkReference, MaxValue, Number, SignedNumber, ToSigned, WrappingArithmetic};

pub use num_traits::ops::wrapping::{
    WrappingAdd, WrappingMul, WrappingNeg, WrappingShl, WrappingShr, WrappingSub,
};
pub use num_traits::{AsPrimitive, FromPrimitive, PrimInt, Signed, ToPrimitive, Unsigned};
