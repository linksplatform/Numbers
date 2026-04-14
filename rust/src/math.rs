const FACTORIALS: [u64; 21] = [
    1,
    1,
    2,
    6,
    24,
    120,
    720,
    5040,
    40320,
    362880,
    3628800,
    39916800,
    479001600,
    6227020800,
    87178291200,
    1307674368000,
    20922789888000,
    355687428096000,
    6402373705728000,
    121645100408832000,
    2432902008176640000,
];

pub const MAXIMUM_FACTORIAL_NUMBER: u64 = 20;

pub fn factorial(n: u64) -> u64 {
    if n <= MAXIMUM_FACTORIAL_NUMBER {
        FACTORIALS[n as usize]
    } else {
        panic!(
            "Only numbers from 0 to {} are supported by unsigned integer with 64 bits length.",
            MAXIMUM_FACTORIAL_NUMBER
        );
    }
}

pub fn factorial_with_likely(n: u64) -> u64 {
    if n <= MAXIMUM_FACTORIAL_NUMBER {
        FACTORIALS[n as usize]
    } else {
        cold_panic()
    }
}

pub fn factorial_with_unlikely_first(n: u64) -> u64 {
    if n > MAXIMUM_FACTORIAL_NUMBER {
        cold_panic();
    }
    FACTORIALS[n as usize]
}

pub fn factorial_direct_array_access(n: u64) -> u64 {
    FACTORIALS[n as usize]
}

#[inline(always)]
pub fn factorial_with_likely_and_force_inline(n: u64) -> u64 {
    if n <= MAXIMUM_FACTORIAL_NUMBER {
        FACTORIALS[n as usize]
    } else {
        cold_panic()
    }
}

#[cold]
#[inline(never)]
fn cold_panic() -> ! {
    panic!(
        "Only numbers from 0 to {} are supported by unsigned integer with 64 bits length.",
        MAXIMUM_FACTORIAL_NUMBER
    );
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_factorial_basic() {
        assert_eq!(factorial(0), 1);
        assert_eq!(factorial(1), 1);
        assert_eq!(factorial(5), 120);
        assert_eq!(factorial(19), 121645100408832000);
        assert_eq!(factorial(20), 2432902008176640000);
    }

    #[test]
    fn test_factorial_with_likely() {
        assert_eq!(factorial_with_likely(0), 1);
        assert_eq!(factorial_with_likely(19), 121645100408832000);
    }

    #[test]
    #[should_panic]
    fn test_factorial_out_of_range() {
        factorial(21);
    }

    #[test]
    #[should_panic]
    fn test_factorial_with_likely_out_of_range() {
        factorial_with_likely(21);
    }
}
