namespace Platform::Numbers
{
    class Bit
    {
        public: static std::int64_t Count(std::int64_t x)
        {
            std::int64_t n = 0;
            while (x != 0)
            {
                n++;
                x &= x - 1;
            }
            return n;
        }

        public: static std::int32_t GetLowestPosition(std::uint64_t value)
        {
            if (value == 0)
            {
                return -1;
            }
            auto position = 0;
            while ((value & 1UL) == 0)
            {
                value >>= 1;
                ++position;
            }
            return position;
        }

        public: template <typename T> static T Not(T x) { return Bit<T>.Not(x); }

        public: template <typename T> static T Or(T x, T y) { return Bit<T>.Or(x, y); }

        public: template <typename T> static T And(T x, T y) { return Bit<T>.And(x, y); }

        public: template <typename T> static T ShiftLeft(T x, std::int32_t y) { return Bit<T>.ShiftLeft(x, y); }

        public: template <typename T> static T ShiftRight(T x, std::int32_t y) { return Bit<T>.ShiftRight(x, y); }

        public: template <typename T> static T PartialWrite(T target, T source, std::int32_t shift, std::int32_t limit) { return Bit<T>.PartialWrite(target, source, shift, limit); }

        public: template <typename T> static T PartialRead(T target, std::int32_t shift, std::int32_t limit) { return Bit<T>.PartialRead(target, shift, limit); }
    };
}
