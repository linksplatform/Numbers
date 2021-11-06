namespace Platform::Numbers::Benchmarks
{
    class ArithmeticBenchmarks
    {
        public: std::int32_t IncrementWithoutRef()
        {
            auto x = 1;
            x = x + 1;
            return x;
        }

        public: std::int32_t IncrementWithRef()
        {
            auto x = 1;
            x + 1;
            return x;
        }

        public: std::int32_t DecrementWithoutRef()
        {
            auto x = 1;
            x = x - 1;
            return x;
        }

        public: std::int32_t DecrementWithRef()
        {
            auto x = 1;
            x - 1;
            return x;
        }
    };
}
