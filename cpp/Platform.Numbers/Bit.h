namespace Platform::Numbers::Bit
{
    constexpr auto Count(std::unsigned_integral auto x) noexcept { return std::popcount(x); }

    constexpr auto GetLowestPosition(std::unsigned_integral auto value) noexcept { return (value == 0) ? -1 : std::countr_zero(value); }

    template<std::integral T>
    constexpr auto PartialRead(T target, int shift, int limit) noexcept
    {
        constexpr auto bits = sizeof(T) * 8;
        shift = shift + bits * (shift < 0);
        limit = limit + bits * (limit < 0);

        constexpr auto max_value = std::numeric_limits<T>::max();
        auto sourceMask = ~(max_value << limit) & max_value;
        auto targetMask = sourceMask << shift;
        return (target & targetMask) >> shift;
    }

    template<std::integral T>
    constexpr auto PartialWrite(T target, T source, int shift, int limit) noexcept
    {
        constexpr auto bits = sizeof(T) * 8;
        shift = shift + bits * (shift < 0);
        limit = limit + bits * (limit < 0);

        constexpr auto max_value = std::numeric_limits<T>::max();
        auto sourceMask = ~(max_value << limit) & max_value;
        auto targetMask = ~(sourceMask << shift);
        return target & targetMask | (source & sourceMask) << shift;
    }
}
