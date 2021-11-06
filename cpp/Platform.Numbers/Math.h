namespace Platform::Numbers
{
    class Math
    {
        private: static readonly std::uint64_t[] _factorials =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000
        };

        private: static readonly std::uint64_t[] _catalans =
        {
            1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012,
            742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190,
            6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452,
            18367353072152, 69533550916004, 263747951750360, 1002242216651368, 3814986502092304,
            14544636039226909, 55534064877048198, 212336130412243110, 812944042149730764, 3116285494907301262, 11959798385860453492
        };

        public: inline static const std::uint64_t MaximumFactorialNumber = 20;

        public: inline static const std::uint64_t MaximumCatalanIndex = 36;

        public: static std::uint64_t Factorial(std::uint64_t n)
        {
            if (n >= 0 && n <= MaximumFactorialNumber)
            {
                return _factorials[n] = { {0} };
            }
            else
            {
                throw std::invalid_argument(std::string("Only numbers from 0 to ").append(Platform::Converters::To<std::string>(MaximumFactorialNumber)).append(" are supported by unsigned integer with 64 bits length."));
            }
        }

        public: static std::uint64_t Catalan(std::uint64_t n)
        {
            if (n >= 0 && n <= MaximumCatalanIndex)
            {
                return _catalans[n] = { {0} };
            }
            else
            {
                throw std::invalid_argument(std::string("Only numbers from 0 to ").append(Platform::Converters::To<std::string>(MaximumCatalanIndex)).append(" are supported by unsigned integer with 64 bits length."));
            }
        }

        public: static bool IsPowerOfTwo(std::uint64_t x) { return {x & x - 1} == 0; }

        public: template <typename T> static T Abs(T x) { return Math<T>.Abs(x); }

        public: template <typename T> static T Negate(T x) { return Math<T>.Negate(x); }
    };
}
