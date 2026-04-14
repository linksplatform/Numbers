use std::fmt::{Debug, Display};
use std::hash::Hash;

use num_traits::ops::wrapping::{
    WrappingAdd, WrappingMul, WrappingNeg, WrappingShl, WrappingShr, WrappingSub,
};
use num_traits::{AsPrimitive, FromPrimitive, PrimInt, Signed, ToPrimitive, Unsigned};

/// A base numeric trait combining `PrimInt`, `Default`, `Debug`,
/// `AsPrimitive<usize>`, and `ToPrimitive`.
///
/// Implemented for all primitive integer types.
///
/// # Examples
///
/// ```
/// use platform_num::Number;
/// use num_traits::AsPrimitive;
///
/// fn to_usize<T: Number>(val: T) -> usize {
///     val.as_()
/// }
///
/// assert_eq!(to_usize(42u32), 42usize);
/// ```
pub trait Number: PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive {}

impl<All: PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive> Number for All {}

/// A signed numeric trait extending [`Number`] with signed operations.
///
/// Implemented for all signed primitive integer types.
///
/// # Examples
///
/// ```
/// use platform_num::SignedNumber;
///
/// fn get_abs<T: SignedNumber>(val: T) -> T {
///     val.abs()
/// }
///
/// assert_eq!(get_abs(-5i32), 5i32);
/// ```
pub trait SignedNumber: Number + Signed + FromPrimitive {}

impl<All: Number + Signed + FromPrimitive> SignedNumber for All {}

/// Converts a numeric type to its signed counterpart.
///
/// Maps each unsigned type to the corresponding signed type
/// (e.g. `u32` → `i32`). Signed types map to themselves.
///
/// # Examples
///
/// ```
/// use platform_num::ToSigned;
///
/// let unsigned_val: u32 = 42;
/// let signed_val: i32 = unsigned_val.to_signed();
/// assert_eq!(signed_val, 42i32);
/// ```
pub trait ToSigned {
    /// The signed type that corresponds to `Self`.
    type Type: Number + Signed;

    /// Converts `self` to the corresponding signed type via `as` cast.
    fn to_signed(&self) -> Self::Type;
}

macro_rules! signed_type_impl {
    ($U:ty, $S:ty) => {
        impl ToSigned for $U {
            type Type = $S;

            fn to_signed(&self) -> Self::Type {
                *self as Self::Type
            }
        }
    };
}

signed_type_impl!(i8, i8);
signed_type_impl!(u8, i8);
signed_type_impl!(i16, i16);
signed_type_impl!(u16, i16);
signed_type_impl!(i32, i32);
signed_type_impl!(u32, i32);
signed_type_impl!(i64, i64);
signed_type_impl!(u64, i64);
signed_type_impl!(i128, i128);
signed_type_impl!(u128, i128);
signed_type_impl!(isize, isize);
signed_type_impl!(usize, isize);

/// Provides the maximum value for a numeric type as an associated constant.
///
/// Implemented for all primitive integer types.
///
/// # Examples
///
/// ```
/// use platform_num::MaxValue;
///
/// assert_eq!(<u64 as MaxValue>::MAX, u64::MAX);
/// ```
pub trait MaxValue {
    /// The maximum value of this type.
    const MAX: Self;
}

/// Applies a macro to each primitive integer type.
///
/// This helper macro invokes `$macro!(type)` for every primitive integer type:
/// `i8`, `u8`, `i16`, `u16`, `i32`, `u32`, `i64`, `u64`, `i128`, `u128`,
/// `isize`, `usize`.
macro_rules! for_each_integer_type {
    ($macro:ident) => {
        $macro!(i8);
        $macro!(u8);
        $macro!(i16);
        $macro!(u16);
        $macro!(i32);
        $macro!(u32);
        $macro!(i64);
        $macro!(u64);
        $macro!(i128);
        $macro!(u128);
        $macro!(isize);
        $macro!(usize);
    };
}

macro_rules! max_value_impl {
    ($T:ty) => {
        impl MaxValue for $T {
            const MAX: Self = <$T>::MAX;
        }
    };
}

for_each_integer_type!(max_value_impl);

/// A composite trait for wrapping arithmetic operations.
///
/// Combines all wrapping arithmetic traits from `num-traits`:
/// [`WrappingAdd`], [`WrappingSub`], [`WrappingMul`],
/// [`WrappingNeg`], [`WrappingShl`], and [`WrappingShr`].
///
/// Implemented for all primitive integer types.
///
/// # Examples
///
/// ```
/// use platform_num::WrappingArithmetic;
///
/// fn wrapping_increment<T: WrappingArithmetic>(a: &T, b: &T) -> T {
///     a.wrapping_add(b)
/// }
///
/// assert_eq!(wrapping_increment(&u8::MAX, &1u8), 0u8);
/// ```
pub trait WrappingArithmetic:
    WrappingAdd + WrappingSub + WrappingMul + WrappingNeg + WrappingShl + WrappingShr
{
}

impl<All: WrappingAdd + WrappingSub + WrappingMul + WrappingNeg + WrappingShl + WrappingShr>
    WrappingArithmetic for All
{
}

/// A composite trait for types that can be used as link identifiers.
///
/// Combines [`Number`], `Unsigned`, [`ToSigned`], [`MaxValue`],
/// [`WrappingArithmetic`], `FromPrimitive`,
/// `TryFrom`/`TryInto` for all integer types,
/// `Debug`, `Display`, `Hash`, `Send`, `Sync`, and `'static`.
///
/// Implemented for `u8`, `u16`, `u32`, `u64`, `u128`, and `usize`.
///
/// # Design note
///
/// Supertraits are listed explicitly rather than via type aliases,
/// because some IDEs do not fully resolve trait aliases for
/// autocompletion and go-to-definition.
///
/// # Examples
///
/// ```
/// use platform_num::LinkReference;
///
/// fn create_link<T: LinkReference>(source: T, target: T) -> (T, T) {
///     (source, target)
/// }
///
/// let link = create_link(1u64, 2u64);
/// assert_eq!(link, (1u64, 2u64));
/// ```
#[rustfmt::skip]
pub trait LinkReference:
Sized
+ Number
+ Unsigned
+ ToSigned
+ MaxValue
+ WrappingArithmetic
+ FromPrimitive
+ TryFrom<i8, Error: Debug>
+ TryFrom<u8, Error: Debug>
+ TryFrom<i16, Error: Debug>
+ TryFrom<u16, Error: Debug>
+ TryFrom<i32, Error: Debug>
+ TryFrom<u32, Error: Debug>
+ TryFrom<i64, Error: Debug>
+ TryFrom<u64, Error: Debug>
+ TryFrom<i128, Error: Debug>
+ TryFrom<u128, Error: Debug>
+ TryFrom<isize, Error: Debug>
+ TryFrom<usize, Error: Debug>
+ TryInto<i8, Error: Debug>
+ TryInto<u8, Error: Debug>
+ TryInto<i16, Error: Debug>
+ TryInto<u16, Error: Debug>
+ TryInto<i32, Error: Debug>
+ TryInto<u32, Error: Debug>
+ TryInto<i64, Error: Debug>
+ TryInto<u64, Error: Debug>
+ TryInto<i128, Error: Debug>
+ TryInto<u128, Error: Debug>
+ TryInto<isize, Error: Debug>
+ TryInto<usize, Error: Debug>
+ Debug
+ Display
+ Hash
+ Send
+ Sync
+ 'static
{
    /// Creates a value of this type from a `u8`, panicking on overflow.
    fn from_byte(n: u8) -> Self {
        Self::try_from(n).unwrap_or_else(|e| {
            panic!("LinkReference::from_byte({n}) failed: {e:?}")
        })
    }
}

#[rustfmt::skip]
impl<
    All: Sized
    + Number
    + Unsigned
    + ToSigned
    + MaxValue
    + WrappingArithmetic
    + FromPrimitive
    + TryFrom<i8, Error: Debug>
    + TryFrom<u8, Error: Debug>
    + TryFrom<i16, Error: Debug>
    + TryFrom<u16, Error: Debug>
    + TryFrom<i32, Error: Debug>
    + TryFrom<u32, Error: Debug>
    + TryFrom<i64, Error: Debug>
    + TryFrom<u64, Error: Debug>
    + TryFrom<i128, Error: Debug>
    + TryFrom<u128, Error: Debug>
    + TryFrom<isize, Error: Debug>
    + TryFrom<usize, Error: Debug>
    + TryInto<i8, Error: Debug>
    + TryInto<u8, Error: Debug>
    + TryInto<i16, Error: Debug>
    + TryInto<u16, Error: Debug>
    + TryInto<i32, Error: Debug>
    + TryInto<u32, Error: Debug>
    + TryInto<i64, Error: Debug>
    + TryInto<u64, Error: Debug>
    + TryInto<i128, Error: Debug>
    + TryInto<u128, Error: Debug>
    + TryInto<isize, Error: Debug>
    + TryInto<usize, Error: Debug>
    + Debug
    + Display
    + Hash
    + Send
    + Sync
    + 'static,
> LinkReference for All {}
