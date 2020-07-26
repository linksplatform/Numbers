using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member



namespace Platform.Numbers
{

    public static class Bit
    {
        /// <summary>
        /// <para> Counts the number of bits set in a number </para>
        /// <para> Подсчитывает количество установленных бит в числе </para>
        ///</summary>
        /// <returns>
        /// <para> Number of bits set in a number </para>
        /// <para> Количество установленных бит в числе </para>
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
        /// <para> Searches for the first bit set in a number </para>
        /// <para> Ищет первый установленный бит в числе </para>
        /// </summary>
        /// <returns>
        /// <para> First bit set </para>
        /// <para> Первый установленный бит </para>
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Not<T>(T x) => Bit<T>.Not(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Or<T>(T x, T y) => Bit<T>.Or(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T And<T>(T x, T y) => Bit<T>.And(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftLeft<T>(T x, int y) => Bit<T>.ShiftLeft(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftRight<T>(T x, int y) => Bit<T>.ShiftRight(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite<T>(T target, T source, int shift, int limit) => Bit<T>.PartialWrite(target, source, shift, limit);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
