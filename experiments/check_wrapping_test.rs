#[cfg(test)]
mod tests {
    use num_traits::ops::wrapping::*;

    fn check_all_wrapping<T: WrappingAdd + WrappingSub + WrappingMul + WrappingNeg + WrappingShl + WrappingShr>() {}

    #[test]
    fn test_all_unsigned_types_implement_wrapping() {
        check_all_wrapping::<u8>();
        check_all_wrapping::<u16>();
        check_all_wrapping::<u32>();
        check_all_wrapping::<u64>();
        check_all_wrapping::<u128>();
        check_all_wrapping::<usize>();
    }
}
