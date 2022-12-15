using System.Numerics;
using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>A set of operations on the set bits of a number.</para>
    /// <para>Набор операций над установленными битами числа.</para>
    /// </summary>
    public static class Bit
    {
        /// <summary>
        /// <para>Counts the number of bits set in a number.</para>
        /// <para>Подсчитывает количество установленных бит в числе.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Bitwise number.</para>
        /// <para>Число в битовом представлении.</para>
        /// </param>
        /// <returns>
        /// <para>Number of bits set in a number.</para>
        /// <para>Количество установленных бит в числе.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count(long x)
        {
            long n = 0;
            while (x != 0)
            {
                n++;
                x &= x - 1;
            }
            return n;
        }

        /// <summary>
        /// <para>Searches for the first bit set in a number.</para>
        /// <para>Ищет первый установленный бит в числе.</para>
        /// </summary>
        /// <param name="value">
        /// <para>Bitwise number.</para>
        /// <para>Число в битовом представлении.</para>
        /// </param>
        /// <returns>
        /// <para>First bit set.</para>
        /// <para>Первый установленный бит.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetLowestPosition(ulong value)
        {
            if (value == 0)
            {
                return -1;
            }
            var position = 0;
            while ((value & 1UL) == 0)
            {
                value >>= 1;
                ++position;
            }
            return position;
        }
    }
}
