namespace Platform::Numbers::Math
{
    namespace Internal
    {
        constexpr std::uint64_t _factorials[] =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000
        };

        constexpr std::uint64_t _catalans[] =
        {
            1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012,
            742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190,
            6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452,
            18367353072152, 69533550916004, 263747951750360, 1002242216651368, 3814986502092304,
            14544636039226909, 55534064877048198, 212336130412243110, 812944042149730764, 3116285494907301262, 11959798385860453492UL
        };
    }

    constexpr auto MaximumFactorialNumber = std::size(Internal::_factorials) - 1;

    constexpr auto MaximumCatalanIndex = std::size(Internal::_catalans)  - 1;

    constexpr std::uint64_t Factorial(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber)
        {
            return Internal::_factorials[n];
        }
        else
        {
            throw std::out_of_range(std::string("Only numbers from 0 to ").append(std::to_string(MaximumFactorialNumber)).append("are supported by unsigned integer with 64 bits length."));
        }
    }

    constexpr std::uint64_t Catalan(std::size_t n)
    {
        if (n <= MaximumCatalanIndex)
        {
            return Internal::_catalans[n];
        }
        else
        {
            throw std::out_of_range(std::string("Only numbers from 0 to ").append(std::to_string(MaximumCatalanIndex)).append("are supported by unsigned integer with 64 bits length."));
        }
    }

    constexpr bool IsPowerOfTwo(std::size_t x) { return std::has_single_bit(x); }
}
