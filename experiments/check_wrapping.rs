use num_traits::ops::wrapping::*;

fn check<T: WrappingAdd + WrappingSub + WrappingMul + WrappingNeg + WrappingShl + WrappingShr>() {}

fn main() {
    check::<u8>();
    check::<u16>();
    check::<u32>();
    check::<u64>();
    check::<u128>();
    check::<usize>();
    println!("All unsigned types implement all wrapping traits!");
}
