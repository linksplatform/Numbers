use std::fmt::{Debug, Display};
use std::hash::Hash;

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

macro_rules! max_value_impl {
    ($T:ty) => {
        impl MaxValue for $T {
            const MAX: Self = <$T>::MAX;
        }
    };
}

max_value_impl!(i8);
max_value_impl!(u8);
max_value_impl!(i16);
max_value_impl!(u16);
max_value_impl!(i32);
max_value_impl!(u32);
max_value_impl!(i64);
max_value_impl!(u64);
max_value_impl!(i128);
max_value_impl!(u128);
max_value_impl!(isize);
max_value_impl!(usize);

/// A composite trait for types that can be used as link identifiers.
///
/// Combines [`Number`], `Unsigned`, [`ToSigned`], [`MaxValue`],
/// `FromPrimitive`, `Debug`, `Display`, `Hash`, `Send`, `Sync`,
/// and `'static`.
///
/// Implemented for `u8`, `u16`, `u32`, `u64`, and `usize`.
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
Number
+ Unsigned
+ ToSigned
+ MaxValue
+ FromPrimitive
+ Debug
+ Display
+ Hash
+ Send
+ Sync
+ 'static {}

#[rustfmt::skip]
impl<
    All: Number
    + Unsigned
    + ToSigned
    + MaxValue
    + FromPrimitive
    + Debug
    + Display
    + Hash
    + Send
    + Sync
    + 'static,
> LinkReference for All {}

#[cfg(test)]
mod tests {
    use super::*;

    // ==========================================
    // Tests for Number trait
    // ==========================================

    #[test]
    fn test_number_trait_for_i8() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0i8);
    }

    #[test]
    fn test_number_trait_for_u8() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0u8);
    }

    #[test]
    fn test_number_trait_for_i16() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0i16);
    }

    #[test]
    fn test_number_trait_for_u16() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0u16);
    }

    #[test]
    fn test_number_trait_for_i32() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0i32);
    }

    #[test]
    fn test_number_trait_for_u32() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0u32);
    }

    #[test]
    fn test_number_trait_for_i64() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0i64);
    }

    #[test]
    fn test_number_trait_for_u64() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0u64);
    }

    #[test]
    fn test_number_trait_for_i128() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0i128);
    }

    #[test]
    fn test_number_trait_for_u128() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0u128);
    }

    #[test]
    fn test_number_trait_for_isize() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0isize);
    }

    #[test]
    fn test_number_trait_for_usize() {
        fn assert_number<T: Number>(_val: T) {}
        assert_number(0usize);
    }

    // ==========================================
    // Tests for SignedNumber trait
    // ==========================================

    #[test]
    fn test_signed_number_trait_for_i8() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0i8);
    }

    #[test]
    fn test_signed_number_trait_for_i16() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0i16);
    }

    #[test]
    fn test_signed_number_trait_for_i32() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0i32);
    }

    #[test]
    fn test_signed_number_trait_for_i64() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0i64);
    }

    #[test]
    fn test_signed_number_trait_for_i128() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0i128);
    }

    #[test]
    fn test_signed_number_trait_for_isize() {
        fn assert_signed_number<T: SignedNumber>(_val: T) {}
        assert_signed_number(0isize);
    }

    // ==========================================
    // Tests for ToSigned trait
    // ==========================================

    #[test]
    fn test_to_signed_i8() {
        let val: i8 = 42;
        let signed: i8 = val.to_signed();
        assert_eq!(signed, 42i8);
    }

    #[test]
    fn test_to_signed_u8() {
        let val: u8 = 42;
        let signed: i8 = val.to_signed();
        assert_eq!(signed, 42i8);
    }

    #[test]
    fn test_to_signed_i16() {
        let val: i16 = 1000;
        let signed: i16 = val.to_signed();
        assert_eq!(signed, 1000i16);
    }

    #[test]
    fn test_to_signed_u16() {
        let val: u16 = 1000;
        let signed: i16 = val.to_signed();
        assert_eq!(signed, 1000i16);
    }

    #[test]
    fn test_to_signed_i32() {
        let val: i32 = 100000;
        let signed: i32 = val.to_signed();
        assert_eq!(signed, 100000i32);
    }

    #[test]
    fn test_to_signed_u32() {
        let val: u32 = 100000;
        let signed: i32 = val.to_signed();
        assert_eq!(signed, 100000i32);
    }

    #[test]
    fn test_to_signed_i64() {
        let val: i64 = 1000000000;
        let signed: i64 = val.to_signed();
        assert_eq!(signed, 1000000000i64);
    }

    #[test]
    fn test_to_signed_u64() {
        let val: u64 = 1000000000;
        let signed: i64 = val.to_signed();
        assert_eq!(signed, 1000000000i64);
    }

    #[test]
    fn test_to_signed_i128() {
        let val: i128 = 1000000000000000;
        let signed: i128 = val.to_signed();
        assert_eq!(signed, 1000000000000000i128);
    }

    #[test]
    fn test_to_signed_u128() {
        let val: u128 = 1000000000000000;
        let signed: i128 = val.to_signed();
        assert_eq!(signed, 1000000000000000i128);
    }

    #[test]
    fn test_to_signed_isize() {
        let val: isize = 12345;
        let signed: isize = val.to_signed();
        assert_eq!(signed, 12345isize);
    }

    #[test]
    fn test_to_signed_usize() {
        let val: usize = 12345;
        let signed: isize = val.to_signed();
        assert_eq!(signed, 12345isize);
    }

    #[test]
    fn test_to_signed_type_alias_i8() {
        fn check<T: ToSigned<Type = i8>>(_val: T) {}
        check(0i8);
        check(0u8);
    }

    #[test]
    fn test_to_signed_type_alias_i16() {
        fn check<T: ToSigned<Type = i16>>(_val: T) {}
        check(0i16);
        check(0u16);
    }

    #[test]
    fn test_to_signed_type_alias_i32() {
        fn check<T: ToSigned<Type = i32>>(_val: T) {}
        check(0i32);
        check(0u32);
    }

    #[test]
    fn test_to_signed_type_alias_i64() {
        fn check<T: ToSigned<Type = i64>>(_val: T) {}
        check(0i64);
        check(0u64);
    }

    #[test]
    fn test_to_signed_type_alias_i128() {
        fn check<T: ToSigned<Type = i128>>(_val: T) {}
        check(0i128);
        check(0u128);
    }

    #[test]
    fn test_to_signed_type_alias_isize() {
        fn check<T: ToSigned<Type = isize>>(_val: T) {}
        check(0isize);
        check(0usize);
    }

    // ==========================================
    // Tests for MaxValue trait
    // ==========================================

    #[test]
    fn test_max_value_i8() {
        assert_eq!(i8::MAX, <i8 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_u8() {
        assert_eq!(u8::MAX, <u8 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_i16() {
        assert_eq!(i16::MAX, <i16 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_u16() {
        assert_eq!(u16::MAX, <u16 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_i32() {
        assert_eq!(i32::MAX, <i32 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_u32() {
        assert_eq!(u32::MAX, <u32 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_i64() {
        assert_eq!(i64::MAX, <i64 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_u64() {
        assert_eq!(u64::MAX, <u64 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_i128() {
        assert_eq!(i128::MAX, <i128 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_u128() {
        assert_eq!(u128::MAX, <u128 as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_isize() {
        assert_eq!(isize::MAX, <isize as MaxValue>::MAX);
    }

    #[test]
    fn test_max_value_usize() {
        assert_eq!(usize::MAX, <usize as MaxValue>::MAX);
    }

    // ==========================================
    // Tests for LinkReference trait
    // ==========================================

    #[test]
    fn test_link_reference_for_u8() {
        fn assert_link_reference<T: LinkReference>(_val: T) {}
        assert_link_reference(0u8);
    }

    #[test]
    fn test_link_reference_for_u16() {
        fn assert_link_reference<T: LinkReference>(_val: T) {}
        assert_link_reference(0u16);
    }

    #[test]
    fn test_link_reference_for_u32() {
        fn assert_link_reference<T: LinkReference>(_val: T) {}
        assert_link_reference(0u32);
    }

    #[test]
    fn test_link_reference_for_u64() {
        fn assert_link_reference<T: LinkReference>(_val: T) {}
        assert_link_reference(0u64);
    }

    #[test]
    fn test_link_reference_for_usize() {
        fn assert_link_reference<T: LinkReference>(_val: T) {}
        assert_link_reference(0usize);
    }

    // ==========================================
    // Edge case tests for ToSigned
    // ==========================================

    #[test]
    fn test_to_signed_u8_max() {
        let val: u8 = u8::MAX;
        let signed: i8 = val.to_signed();
        assert_eq!(signed, -1i8); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_u16_max() {
        let val: u16 = u16::MAX;
        let signed: i16 = val.to_signed();
        assert_eq!(signed, -1i16); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_u32_max() {
        let val: u32 = u32::MAX;
        let signed: i32 = val.to_signed();
        assert_eq!(signed, -1i32); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_u64_max() {
        let val: u64 = u64::MAX;
        let signed: i64 = val.to_signed();
        assert_eq!(signed, -1i64); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_u128_max() {
        let val: u128 = u128::MAX;
        let signed: i128 = val.to_signed();
        assert_eq!(signed, -1i128); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_usize_max() {
        let val: usize = usize::MAX;
        let signed: isize = val.to_signed();
        assert_eq!(signed, -1isize); // Wrapping behavior
    }

    #[test]
    fn test_to_signed_zero() {
        assert_eq!(0u8.to_signed(), 0i8);
        assert_eq!(0u16.to_signed(), 0i16);
        assert_eq!(0u32.to_signed(), 0i32);
        assert_eq!(0u64.to_signed(), 0i64);
        assert_eq!(0u128.to_signed(), 0i128);
        assert_eq!(0usize.to_signed(), 0isize);
    }

    #[test]
    fn test_to_signed_negative() {
        assert_eq!((-1i8).to_signed(), -1i8);
        assert_eq!((-1i16).to_signed(), -1i16);
        assert_eq!((-1i32).to_signed(), -1i32);
        assert_eq!((-1i64).to_signed(), -1i64);
        assert_eq!((-1i128).to_signed(), -1i128);
        assert_eq!((-1isize).to_signed(), -1isize);
    }

    // ==========================================
    // Integration tests - using traits together
    // ==========================================

    #[test]
    fn test_link_reference_can_be_converted_to_signed() {
        fn use_link_reference<T: LinkReference + ToSigned>(val: T) -> <T as ToSigned>::Type {
            val.to_signed()
        }
        assert_eq!(use_link_reference(42u8), 42i8);
        assert_eq!(use_link_reference(42u16), 42i16);
        assert_eq!(use_link_reference(42u32), 42i32);
        assert_eq!(use_link_reference(42u64), 42i64);
        assert_eq!(use_link_reference(42usize), 42isize);
    }

    #[test]
    fn test_link_reference_has_max_value() {
        fn get_max<T: LinkReference + MaxValue>() -> T {
            T::MAX
        }
        assert_eq!(get_max::<u8>(), u8::MAX);
        assert_eq!(get_max::<u16>(), u16::MAX);
        assert_eq!(get_max::<u32>(), u32::MAX);
        assert_eq!(get_max::<u64>(), u64::MAX);
        assert_eq!(get_max::<usize>(), usize::MAX);
    }

    #[test]
    fn test_number_default_values() {
        fn check_default<T: Number>() -> T {
            T::default()
        }
        assert_eq!(check_default::<i8>(), 0i8);
        assert_eq!(check_default::<u8>(), 0u8);
        assert_eq!(check_default::<i16>(), 0i16);
        assert_eq!(check_default::<u16>(), 0u16);
        assert_eq!(check_default::<i32>(), 0i32);
        assert_eq!(check_default::<u32>(), 0u32);
        assert_eq!(check_default::<i64>(), 0i64);
        assert_eq!(check_default::<u64>(), 0u64);
        assert_eq!(check_default::<i128>(), 0i128);
        assert_eq!(check_default::<u128>(), 0u128);
        assert_eq!(check_default::<isize>(), 0isize);
        assert_eq!(check_default::<usize>(), 0usize);
    }

    #[test]
    fn test_number_as_usize() {
        fn to_usize<T: Number>(val: T) -> usize {
            val.as_()
        }
        assert_eq!(to_usize(42i8), 42usize);
        assert_eq!(to_usize(42u8), 42usize);
        assert_eq!(to_usize(42i16), 42usize);
        assert_eq!(to_usize(42u16), 42usize);
        assert_eq!(to_usize(42i32), 42usize);
        assert_eq!(to_usize(42u32), 42usize);
    }

    #[test]
    fn test_signed_number_signum() {
        fn get_signum<T: SignedNumber>(val: T) -> T {
            val.signum()
        }
        assert_eq!(get_signum(5i8), 1i8);
        assert_eq!(get_signum(-5i8), -1i8);
        assert_eq!(get_signum(0i8), 0i8);
        assert_eq!(get_signum(5i32), 1i32);
        assert_eq!(get_signum(-5i32), -1i32);
        assert_eq!(get_signum(0i32), 0i32);
    }

    #[test]
    fn test_signed_number_abs() {
        fn get_abs<T: SignedNumber>(val: T) -> T {
            val.abs()
        }
        assert_eq!(get_abs(-5i8), 5i8);
        assert_eq!(get_abs(5i8), 5i8);
        assert_eq!(get_abs(-100i32), 100i32);
        assert_eq!(get_abs(100i32), 100i32);
    }
}
