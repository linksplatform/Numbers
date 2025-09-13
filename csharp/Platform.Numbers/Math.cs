using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of math methods.</para>
    /// <para>Представляет набор математических методов.</para>
    /// </summary>
    /// <remarks>Resizable array (FileMappedMemory) for values cache may be used. or cached oeis.org</remarks>
    public static class Math
    {
        private static readonly ulong[] _catalans =
        {
            1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012,
            742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190,
            6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452,
            18367353072152, 69533550916004, 263747951750360, 1002242216651368, 3814986502092304,
            14544636039226909, 55534064877048198, 212336130412243110, 812944042149730764, 3116285494907301262, 11959798385860453492
        };

        /// <summary>
        /// <para>Represents the limit for calculating the factorial number, supported by the <see cref="ulong"/> type.</para>
        /// <para>Представляет предел расчёта факториала числа, поддерживаемый <see cref="ulong"/> типом.</para>
        /// </summary>
        public static readonly ulong MaximumCatalanIndex = 36;

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
        public static TLinkAddress Catalan<TLinkAddress>(TLinkAddress n) where TLinkAddress : IUnsignedNumber<TLinkAddress>, IComparisonOperators<TLinkAddress, TLinkAddress, bool>
        {
            if (n >= TLinkAddress.Zero && n <= TLinkAddress.CreateTruncating(MaximumCatalanIndex))
            {
                return TLinkAddress.CreateTruncating(_catalans[ulong.CreateTruncating(n)]);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Only numbers from 0 to {MaximumCatalanIndex} are supported by unsigned integer with 64 bits length.");
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo<TLinkAddress>(TLinkAddress x) where TLinkAddress : IUnsignedNumber<TLinkAddress>, IBitwiseOperators<TLinkAddress, TLinkAddress, TLinkAddress>, IComparisonOperators<TLinkAddress, TLinkAddress, bool>
        {
            return (x & x - TLinkAddress.One) == TLinkAddress.Zero;
        }
    }
}
