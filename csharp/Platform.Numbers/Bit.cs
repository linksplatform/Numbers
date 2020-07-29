using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member



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
        /// <param name = "x">
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
        /// <param name = "value">
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

        /// <summary>
        /// <para>Performing bitwise number x inversion.</para>
        /// <para>Выполняет побитовую инверсию числа x.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>Number to invert.</para>
        /// <para>Число для инверсии.</para>
        /// </param>
        /// <returns>
        /// <para>Inverse x value.</para>
        /// <para>Обратное значение x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Not<T>(T x) => Bit<T>.Not(x);

        /// <summary>
        /// <para>Performing bitwise addition x and y.</para>
        /// <para>Выполняет логическое сложение.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>First term.</para>
        /// <para>Первое слагаемое.</para>
        /// </param>
        /// <param name="y">
        /// <para>Second term.</para>
        /// <para>Второе слагаемое.</para>
        /// </param>
        /// <returns>
        /// <para>Sum of x and y.</para>
        /// <para>Сумма x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Or<T>(T x, T y) => Bit<T>.Or(x, y);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// </summary>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T And<T>(T x, T y) => Bit<T>.And(x, y);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftLeft<T>(T x, int y) => Bit<T>.ShiftLeft(x, y);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftRight<T>(T x, int y) => Bit<T>.ShiftRight(x, y);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite<T>(T target, T source, int shift, int limit) => Bit<T>.PartialWrite(target, source, shift, limit);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
