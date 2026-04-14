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
//! | [`LinkReference`] | Composite trait for link identifiers — unsigned, hashable, displayable, thread-safe, with `TryFrom`/`TryInto` for all integer types |
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

pub use imp::{LinkReference, MaxValue, Number, SignedNumber, ToSigned};
