#pragma once
#include <cstdint>
#include <stdexcept>
#include <string>
#include <type_traits>

namespace Platform::Numbers
{
    /// <summary>
    /// <para>Represents a set of math methods.</para>
    /// <para>Представляет набор математических методов.</para>
    /// </summary>
    class Math
    {
    private:
        static constexpr std::uint64_t _factorials[] =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800ULL, 87178291200ULL, 1307674368000ULL, 20922789888000ULL,
            355687428096000ULL, 6402373705728000ULL, 121645100408832000ULL, 2432902008176640000ULL
        };

        static constexpr std::uint64_t _catalans[] =
        {
            1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012,
            742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190,
            6564120420ULL, 24466267020ULL, 91482563640ULL, 343059613650ULL, 1289904147324ULL, 4861946401452ULL,
            18367353072152ULL, 69533550916004ULL, 263747951750360ULL, 1002242216651368ULL, 3814986502092304ULL,
            14544636039226909ULL, 55534064877048198ULL, 212336130412243110ULL, 812944042149730764ULL, 3116285494907301262ULL, 11959798385860453492ULL
        };

    public:
        /// <summary>
        /// <para>Represents the limit for calculating the factorial number, supported by the <see cref="ulong"/> type.</para>
        /// <para>Представляет предел расчёта факториала числа, поддерживаемый <see cref="ulong"/> типом.</para>
        /// </summary>
        static constexpr std::uint64_t MaximumFactorialNumber = 20;

        /// <summary>
        /// <para>Represents the limit for calculating the catanal number, supported by the <see cref="ulong"/> type.</para>
        /// <para>Представляет предел расчёта катаналового числа, поддерживаемый <see cref="ulong"/> типом.</para>
        /// </summary>
        static constexpr std::uint64_t MaximumCatalanIndex = 36;

        /// <summary>
        /// <para>Returns the product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Возвращает произведение всех положительных чисел меньше или равных указанному в качестве аргумента числу.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The maximum positive number that will participate in factorial's product.</para>
        /// <para>Максимальное положительное число, которое будет участвовать в произведении факториала.</para>
        /// </param>
        /// <returns>
        /// <para>The product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Произведение всех положительных чисел меньше или равных указанному, в качестве аргумента, числу.</para>
        /// </returns>
        template <typename TLinkAddress>
        static constexpr TLinkAddress Factorial(TLinkAddress n)
        {
            static_assert(std::is_unsigned_v<TLinkAddress>, "TLinkAddress must be an unsigned integer type");
            if (n <= MaximumFactorialNumber)
            {
                return static_cast<TLinkAddress>(_factorials[static_cast<std::size_t>(n)]);
            }
            else
            {
                throw std::out_of_range("Only numbers from 0 to " + std::to_string(MaximumFactorialNumber) + " are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>Returns the Catalan Number with the number specified as an argument.</para>
        /// <para>Возвращает Число Катанала с номером, указанным в качестве аргумента.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The number of the Catalan number.</para>
        /// <para>Номер Числа Катанала.</para>
        /// </param>
        /// <returns>
        /// <para>The Catalan Number with the number specified as an argument.</para>
        /// <para>Число Катанала с номером, указанным в качестве аргумента.</para>
        /// </returns>
        template <typename TLinkAddress>
        static constexpr TLinkAddress Catalan(TLinkAddress n)
        {
            static_assert(std::is_unsigned_v<TLinkAddress>, "TLinkAddress must be an unsigned integer type");
            if (n <= MaximumCatalanIndex)
            {
                return static_cast<TLinkAddress>(_catalans[static_cast<std::size_t>(n)]);
            }
            else
            {
                throw std::out_of_range("Only numbers from 0 to " + std::to_string(MaximumCatalanIndex) + " are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>Checks if a number is a power of two.</para>
        /// <para>Проверяет, является ли число степенью двойки.</para>
        /// </summary>
        /// <param name="x">
        /// <para>The number to check.</para>
        /// <para>Число для проверки.</para>
        /// </param>
        /// <returns>
        /// <para>True if the number is a power of two otherwise false.</para>
        /// <para>True, если число является степенью двойки, иначе - false.</para>
        /// </returns>
        template <typename TLinkAddress>
        static constexpr bool IsPowerOfTwo(TLinkAddress x)
        {
            static_assert(std::is_unsigned_v<TLinkAddress>, "TLinkAddress must be an unsigned integer type");
            return x != 0 && (x & (x - 1)) == 0;
        }
    };
}
