// cppcheck-suppress missingIncludeSystem
#include <benchmark/benchmark.h>
// cppcheck-suppress missingIncludeSystem
#include <cstdint>
// cppcheck-suppress missingIncludeSystem
#include <stdexcept>
// cppcheck-suppress missingIncludeSystem
#include <string>

namespace Platform::Numbers::Benchmarks
{
    static constexpr std::uint64_t _factorials[] =
    {
        1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
        479001600, 6227020800ULL, 87178291200ULL, 1307674368000ULL, 20922789888000ULL,
        355687428096000ULL, 6402373705728000ULL, 121645100408832000ULL, 2432902008176640000ULL
    };

    static constexpr std::uint64_t MaximumFactorialNumber = 20;
    static constexpr std::uint64_t FactorialNumber = 19;

    [[noreturn]] __attribute__((noinline))
    static void ThrowOutOfRange()
    {
        throw std::out_of_range("Only numbers from 0 to 20 are supported by unsigned integer with 64 bits length.");
    }

    static std::uint64_t FactorialBaseline(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber)
        {
            return _factorials[n];
        }
        else
        {
            throw std::out_of_range("Only numbers from 0 to " + std::to_string(MaximumFactorialNumber) + " are supported by unsigned integer with 64 bits length.");
        }
    }

    static std::uint64_t FactorialWithLikely(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber) [[likely]]
        {
            return _factorials[n];
        }
        else [[unlikely]]
        {
            throw std::out_of_range("Only numbers from 0 to " + std::to_string(MaximumFactorialNumber) + " are supported by unsigned integer with 64 bits length.");
        }
    }

    static std::uint64_t FactorialWithLikelyAndSeparateThrow(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber) [[likely]]
        {
            return _factorials[n];
        }
        else [[unlikely]]
        {
            ThrowOutOfRange();
        }
    }

    __attribute__((always_inline))
    static inline std::uint64_t FactorialWithLikelyAndForceInline(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber) [[likely]]
        {
            return _factorials[n];
        }
        else [[unlikely]]
        {
            ThrowOutOfRange();
        }
    }

    static std::uint64_t FactorialWithBuiltinExpect(std::uint64_t n)
    {
        if (__builtin_expect(n <= MaximumFactorialNumber, 1))
        {
            return _factorials[n];
        }
        else
        {
            ThrowOutOfRange();
        }
    }

    static std::uint64_t FactorialUnlikelyFirst(std::uint64_t n)
    {
        if (n > MaximumFactorialNumber) [[unlikely]]
        {
            ThrowOutOfRange();
        }
        return _factorials[n];
    }

    static std::uint64_t FactorialWithoutAttributes(std::uint64_t n)
    {
        if (n <= MaximumFactorialNumber)
        {
            return _factorials[n];
        }
        ThrowOutOfRange();
        __builtin_unreachable();
    }

    static std::uint64_t FactorialDirectArrayAccess(std::uint64_t n)
    {
        return _factorials[n];
    }

    template <typename T>
    static T FactorialGenericWithLikely(T n)
    {
        static_assert(std::is_unsigned_v<T>, "T must be an unsigned integer type");
        if (n <= static_cast<T>(MaximumFactorialNumber)) [[likely]]
        {
            return static_cast<T>(_factorials[static_cast<std::size_t>(n)]);
        }
        else [[unlikely]]
        {
            ThrowOutOfRange();
        }
    }

    static void BM_FactorialBaseline(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialBaseline(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialBaseline);

    static void BM_FactorialWithLikely(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialWithLikely(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialWithLikely);

    static void BM_FactorialWithLikelyAndSeparateThrow(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialWithLikelyAndSeparateThrow(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialWithLikelyAndSeparateThrow);

    static void BM_FactorialWithLikelyAndForceInline(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialWithLikelyAndForceInline(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialWithLikelyAndForceInline);

    static void BM_FactorialWithBuiltinExpect(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialWithBuiltinExpect(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialWithBuiltinExpect);

    static void BM_FactorialUnlikelyFirst(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialUnlikelyFirst(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialUnlikelyFirst);

    static void BM_FactorialWithoutAttributes(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialWithoutAttributes(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialWithoutAttributes);

    static void BM_FactorialDirectArrayAccess(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialDirectArrayAccess(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialDirectArrayAccess);

    static void BM_FactorialGenericWithLikely(benchmark::State& state)
    {
        for (auto _ : state)
        {
            benchmark::DoNotOptimize(FactorialGenericWithLikely<std::uint64_t>(FactorialNumber));
        }
    }
    BENCHMARK(BM_FactorialGenericWithLikely);
}

BENCHMARK_MAIN();
