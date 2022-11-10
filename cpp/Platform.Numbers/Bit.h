namespace Platform::Numbers::Bit
{
    constexpr std::int64_t Count(std::int64_t x)
    {
        std::int64_t n = 0;
        while (x != 0)
        {
            n++;
            x &= x - 1;
        }
        return n;
    }

    constexpr std::int32_t GetLowestPosition(std::uint64_t value)
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

    template <typename T>
    constexpr T PartialWrite(T target, T source, int shift, int limit)
    {
        if (shift < 0)
        {
            shift = sizeof(T) * 8 + shift;
        }
        if (limit < 0)
        {
            limit = sizeof(T) * 8 + limit;
        }
        auto sourceMask = ~(std::numeric_limits<T>::max() << limit) & std::numeric_limits<T>::max();
        auto targetMask = ~(sourceMask << shift);
        return target & targetMask | (source & sourceMask) << shift;
    }
    
    template <typename T>
    constexpr T PartialRead(T target, T shift, int limit)
    {
        if (shift < 0)
        {
            shift = sizeof(T) * 8 + shift;
        }
        if (limit < 0)
        {
            limit = sizeof(T) * 8 + limit;
        }
        auto sourceMask = ~(std::numeric_limits<T>::max() << limit) & std::numeric_limits<T>::max();
        auto targetMask = sourceMask << shift;
        return (target & targetMask) >> shift;
    }
}
