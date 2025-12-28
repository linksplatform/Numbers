use std::fmt::{Debug, Display};
use std::hash::Hash;

use num_traits::{AsPrimitive, FromPrimitive, PrimInt, Signed, ToPrimitive, Unsigned};

pub trait Num: PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive {}

impl<All: PrimInt + Default + Debug + AsPrimitive<usize> + ToPrimitive> Num for All {}

pub trait SignNum: Num + Signed + FromPrimitive {}

impl<All: Num + Signed + FromPrimitive> SignNum for All {}

pub trait ToSigned {
    type Type: Num + Signed;

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

pub trait MaxValue {
    const MAX: Self;
}

macro_rules! max_value_impl {
    ($T:ty) => {
        impl MaxValue for $T {
            const MAX: Self = <$T>::MAX;
        }
    };
}

// TODO: Create macro foreach
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

// TODO: Not use alias - IDEs does not support it
#[rustfmt::skip]
pub trait LinkType:
Num
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
    All: Num
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
> LinkType for All {}

#[cfg(test)]
mod tests {
    use super::*;

    // ==========================================
    // Tests for Num trait
    // ==========================================

    #[test]
    fn test_num_trait_for_i8() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0i8);
    }

    #[test]
    fn test_num_trait_for_u8() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0u8);
    }

    #[test]
    fn test_num_trait_for_i16() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0i16);
    }

    #[test]
    fn test_num_trait_for_u16() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0u16);
    }

    #[test]
    fn test_num_trait_for_i32() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0i32);
    }

    #[test]
    fn test_num_trait_for_u32() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0u32);
    }

    #[test]
    fn test_num_trait_for_i64() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0i64);
    }

    #[test]
    fn test_num_trait_for_u64() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0u64);
    }

    #[test]
    fn test_num_trait_for_i128() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0i128);
    }

    #[test]
    fn test_num_trait_for_u128() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0u128);
    }

    #[test]
    fn test_num_trait_for_isize() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0isize);
    }

    #[test]
    fn test_num_trait_for_usize() {
        fn assert_num<T: Num>(_val: T) {}
        assert_num(0usize);
    }

    // ==========================================
    // Tests for SignNum trait
    // ==========================================

    #[test]
    fn test_sign_num_trait_for_i8() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0i8);
    }

    #[test]
    fn test_sign_num_trait_for_i16() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0i16);
    }

    #[test]
    fn test_sign_num_trait_for_i32() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0i32);
    }

    #[test]
    fn test_sign_num_trait_for_i64() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0i64);
    }

    #[test]
    fn test_sign_num_trait_for_i128() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0i128);
    }

    #[test]
    fn test_sign_num_trait_for_isize() {
        fn assert_sign_num<T: SignNum>(_val: T) {}
        assert_sign_num(0isize);
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
    // Tests for LinkType trait
    // ==========================================

    #[test]
    fn test_link_type_for_u8() {
        fn assert_link_type<T: LinkType>(_val: T) {}
        assert_link_type(0u8);
    }

    #[test]
    fn test_link_type_for_u16() {
        fn assert_link_type<T: LinkType>(_val: T) {}
        assert_link_type(0u16);
    }

    #[test]
    fn test_link_type_for_u32() {
        fn assert_link_type<T: LinkType>(_val: T) {}
        assert_link_type(0u32);
    }

    #[test]
    fn test_link_type_for_u64() {
        fn assert_link_type<T: LinkType>(_val: T) {}
        assert_link_type(0u64);
    }

    #[test]
    fn test_link_type_for_usize() {
        fn assert_link_type<T: LinkType>(_val: T) {}
        assert_link_type(0usize);
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
    fn test_link_type_can_be_converted_to_signed() {
        fn use_link_type<T: LinkType + ToSigned>(val: T) -> <T as ToSigned>::Type {
            val.to_signed()
        }
        assert_eq!(use_link_type(42u8), 42i8);
        assert_eq!(use_link_type(42u16), 42i16);
        assert_eq!(use_link_type(42u32), 42i32);
        assert_eq!(use_link_type(42u64), 42i64);
        assert_eq!(use_link_type(42usize), 42isize);
    }

    #[test]
    fn test_link_type_has_max_value() {
        fn get_max<T: LinkType + MaxValue>() -> T {
            T::MAX
        }
        assert_eq!(get_max::<u8>(), u8::MAX);
        assert_eq!(get_max::<u16>(), u16::MAX);
        assert_eq!(get_max::<u32>(), u32::MAX);
        assert_eq!(get_max::<u64>(), u64::MAX);
        assert_eq!(get_max::<usize>(), usize::MAX);
    }

    #[test]
    fn test_num_default_values() {
        fn check_default<T: Num>() -> T {
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
    fn test_num_as_usize() {
        fn to_usize<T: Num>(val: T) -> usize {
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
    fn test_sign_num_signum() {
        fn get_signum<T: SignNum>(val: T) -> T {
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
    fn test_sign_num_abs() {
        fn get_abs<T: SignNum>(val: T) -> T {
            val.abs()
        }
        assert_eq!(get_abs(-5i8), 5i8);
        assert_eq!(get_abs(5i8), 5i8);
        assert_eq!(get_abs(-100i32), 100i32);
        assert_eq!(get_abs(100i32), 100i32);
    }
}
