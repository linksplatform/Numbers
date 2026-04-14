use platform_num::{LinkReference, MaxValue, Number, SignedNumber, ToSigned};

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

// ==========================================
// Tests for Number trait - ToPrimitive
// ==========================================

#[test]
fn test_number_to_primitive() {
    fn check_to_primitive<T: Number>(val: T) -> Option<f64> {
        num_traits::ToPrimitive::to_f64(&val)
    }
    assert_eq!(check_to_primitive(42i32), Some(42.0));
    assert_eq!(check_to_primitive(42u64), Some(42.0));
    assert_eq!(check_to_primitive(0i8), Some(0.0));
}

// ==========================================
// Tests for Number trait - PrimInt operations
// ==========================================

#[test]
fn test_number_prim_int_operations() {
    fn check_ops<T: Number>(a: T, b: T) -> T {
        a | b
    }
    assert_eq!(check_ops(0b1010u8, 0b0101u8), 0b1111u8);
    assert_eq!(check_ops(0b1100u32, 0b0011u32), 0b1111u32);
}

#[test]
fn test_number_count_ones() {
    fn count<T: Number>(val: T) -> u32 {
        num_traits::PrimInt::count_ones(val)
    }
    assert_eq!(count(0b1111u8), 4);
    assert_eq!(count(0u32), 0);
    assert_eq!(count(u64::MAX), 64);
}

// ==========================================
// Tests for SignedNumber - FromPrimitive
// ==========================================

#[test]
fn test_signed_number_from_primitive() {
    fn from_i64<T: SignedNumber>(val: i64) -> Option<T> {
        num_traits::FromPrimitive::from_i64(val)
    }
    assert_eq!(from_i64::<i32>(42), Some(42i32));
    assert_eq!(from_i64::<i8>(127), Some(127i8));
    assert_eq!(from_i64::<i8>(128), None); // overflow
}

// ==========================================
// Tests for LinkReference - Send + Sync
// ==========================================

#[test]
fn test_link_reference_is_send_sync() {
    fn assert_send_sync<T: Send + Sync>() {}
    assert_send_sync::<u8>();
    assert_send_sync::<u16>();
    assert_send_sync::<u32>();
    assert_send_sync::<u64>();
    assert_send_sync::<usize>();
}

#[test]
fn test_link_reference_display() {
    fn format_link<T: LinkReference>(val: T) -> String {
        format!("{val}")
    }
    assert_eq!(format_link(42u32), "42");
    assert_eq!(format_link(0u64), "0");
    assert_eq!(format_link(255u8), "255");
}

#[test]
fn test_link_reference_hash() {
    use std::collections::HashSet;

    fn collect_links<T: LinkReference>(vals: &[T]) -> HashSet<T> {
        vals.iter().copied().collect()
    }
    let set = collect_links(&[1u32, 2, 3, 1, 2]);
    assert_eq!(set.len(), 3);
}

#[test]
fn test_link_reference_from_primitive() {
    fn link_from_u64<T: LinkReference>(val: u64) -> Option<T> {
        num_traits::FromPrimitive::from_u64(val)
    }
    assert_eq!(link_from_u64::<u32>(42), Some(42u32));
    assert_eq!(link_from_u64::<u8>(255), Some(255u8));
    assert_eq!(link_from_u64::<u8>(256), None); // overflow
}

// ==========================================
// Tests for LinkReference - TryFrom bounds
// ==========================================

#[test]
fn test_link_reference_try_from_u8() {
    fn try_from_u8<T: LinkReference>(val: u8) -> T {
        T::try_from(val).unwrap()
    }
    assert_eq!(try_from_u8::<u8>(42), 42u8);
    assert_eq!(try_from_u8::<u16>(42), 42u16);
    assert_eq!(try_from_u8::<u32>(42), 42u32);
    assert_eq!(try_from_u8::<u64>(42), 42u64);
    assert_eq!(try_from_u8::<usize>(42), 42usize);
}

#[test]
fn test_link_reference_try_from_i8() {
    fn try_from_i8<T: LinkReference>(val: i8) -> Option<T> {
        T::try_from(val).ok()
    }
    assert_eq!(try_from_i8::<u8>(42), Some(42u8));
    assert_eq!(try_from_i8::<u32>(42), Some(42u32));
    assert_eq!(try_from_i8::<u8>(-1), None);
}

#[test]
fn test_link_reference_try_from_u16() {
    fn try_from_u16<T: LinkReference>(val: u16) -> Option<T> {
        T::try_from(val).ok()
    }
    assert_eq!(try_from_u16::<u8>(255), Some(255u8));
    assert_eq!(try_from_u16::<u8>(256), None);
    assert_eq!(try_from_u16::<u32>(1000), Some(1000u32));
}

#[test]
fn test_link_reference_try_from_u64() {
    fn try_from_u64<T: LinkReference>(val: u64) -> Option<T> {
        T::try_from(val).ok()
    }
    assert_eq!(try_from_u64::<u8>(255), Some(255u8));
    assert_eq!(try_from_u64::<u8>(256), None);
    assert_eq!(try_from_u64::<u64>(u64::MAX), Some(u64::MAX));
}

#[test]
fn test_link_reference_try_from_i128() {
    fn try_from_i128<T: LinkReference>(val: i128) -> Option<T> {
        T::try_from(val).ok()
    }
    assert_eq!(try_from_i128::<u32>(42), Some(42u32));
    assert_eq!(try_from_i128::<u32>(-1), None);
    assert_eq!(try_from_i128::<u64>(i128::MAX), None);
}

#[test]
fn test_link_reference_try_from_usize() {
    fn try_from_usize<T: LinkReference>(val: usize) -> Option<T> {
        T::try_from(val).ok()
    }
    assert_eq!(try_from_usize::<u8>(100), Some(100u8));
    assert_eq!(try_from_usize::<u8>(256), None);
    assert_eq!(try_from_usize::<usize>(12345), Some(12345usize));
}

// ==========================================
// Tests for LinkReference - TryInto bounds
// ==========================================

#[test]
fn test_link_reference_try_into_u8() {
    fn try_into_u8<T: LinkReference>(val: T) -> Option<u8> {
        val.try_into().ok()
    }
    assert_eq!(try_into_u8(255u16), Some(255u8));
    assert_eq!(try_into_u8(256u16), None);
    assert_eq!(try_into_u8(42u64), Some(42u8));
}

#[test]
fn test_link_reference_try_into_i64() {
    fn try_into_i64<T: LinkReference>(val: T) -> Option<i64> {
        val.try_into().ok()
    }
    assert_eq!(try_into_i64(42u32), Some(42i64));
    assert_eq!(try_into_i64(u64::MAX), None);
}

#[test]
fn test_link_reference_try_into_usize() {
    fn try_into_usize<T: LinkReference>(val: T) -> Option<usize> {
        val.try_into().ok()
    }
    assert_eq!(try_into_usize(42u8), Some(42usize));
    assert_eq!(try_into_usize(1000u32), Some(1000usize));
}

#[test]
fn test_link_reference_try_into_i128() {
    fn try_into_i128<T: LinkReference>(val: T) -> Option<i128> {
        val.try_into().ok()
    }
    assert_eq!(try_into_i128(42u8), Some(42i128));
    assert_eq!(try_into_i128(u64::MAX), Some(u64::MAX as i128));
}

// ==========================================
// Tests for LinkReference - funty method
// ==========================================

#[test]
fn test_link_reference_funty() {
    fn make_val<T: LinkReference>(n: u8) -> T {
        T::funty(n)
    }
    assert_eq!(make_val::<u8>(0), 0u8);
    assert_eq!(make_val::<u8>(255), 255u8);
    assert_eq!(make_val::<u16>(42), 42u16);
    assert_eq!(make_val::<u32>(100), 100u32);
    assert_eq!(make_val::<u64>(1), 1u64);
    assert_eq!(make_val::<usize>(0), 0usize);
}

#[test]
fn test_link_reference_funty_all_u8_range_for_u16() {
    for n in 0..=255u8 {
        assert_eq!(u16::funty(n), n as u16);
    }
}

#[test]
fn test_link_reference_funty_zero() {
    assert_eq!(u8::funty(0), 0u8);
    assert_eq!(u16::funty(0), 0u16);
    assert_eq!(u32::funty(0), 0u32);
    assert_eq!(u64::funty(0), 0u64);
    assert_eq!(usize::funty(0), 0usize);
}

#[test]
fn test_link_reference_funty_one() {
    assert_eq!(u8::funty(1), 1u8);
    assert_eq!(u16::funty(1), 1u16);
    assert_eq!(u32::funty(1), 1u32);
    assert_eq!(u64::funty(1), 1u64);
    assert_eq!(usize::funty(1), 1usize);
}

// ==========================================
// Tests for LinkReference - Sized bound
// ==========================================

#[test]
fn test_link_reference_is_sized() {
    fn assert_sized<T: LinkReference + Sized>() {}
    assert_sized::<u8>();
    assert_sized::<u16>();
    assert_sized::<u32>();
    assert_sized::<u64>();
    assert_sized::<usize>();
}

// ==========================================
// Tests for LinkReference - Error: Debug bound
// ==========================================

#[test]
fn test_link_reference_try_from_error_is_debug() {
    fn check_error_debug<T: LinkReference>() {
        if let Err(e) = T::try_from(-1i8) {
            let _ = format!("{e:?}");
        }
    }
    check_error_debug::<u8>();
    check_error_debug::<u16>();
    check_error_debug::<u32>();
    check_error_debug::<u64>();
    check_error_debug::<usize>();
}
