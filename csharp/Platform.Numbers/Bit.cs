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
        /// <para>Выполняет побитовое сложение.</para>
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
        /// <para>Performs bitwise multiplication x by y.</para>
        /// <para>Выполняет побитовое умножение x на y.</para>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// </summary>
        /// <param name="x">
        /// <para>First multiplier.</para>
        /// <para>Первый множитель.</para>
        /// </param>
        /// <param name="y">
        /// <para>Second multiplier.</para>
        /// <para>Второй множитель.</para>
        /// </param>
        /// <returns>
        /// <para>Product of x and y.</para>
        /// <para>Произведение x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T And<T>(T x, T y) => Bit<T>.And(x, y);

        /// <summary>
        /// <para>Performs a bitwise shift of a bit x left by y bits.</para>
        /// <para>Выполняет побитовые свиг бита x влево, на y бит.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number on which the shift operation will be performed.</para>
        /// <para>Число над которым будет производиться операция смещения.<para>
        /// </param>
        /// <param name="y">
        /// <para>Number of bits to shift.</para>
        /// <para>Количество бит на которые выполнить смещение.<para>
        /// </param>
        /// <returns>
        /// <para>The changed value of x.</para>
        /// <para>Изменённое значение x.</para>
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
        /// <param name="x">
        /// <para>The number on which the shift operation will be performed.</para>
        /// <para>Число над которым будет производиться операция смещения.<para>
        /// </param>
        /// <param name="y">
        /// <para>Number of bits to shift.</para>
        /// <para>Количество бит на которые выполнить смещение.<para>
        /// </param>
        /// <returns>
        /// <para>The changed value of x.</para>
        /// <para>Изменённое значение x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftRight<T>(T x, int y) => Bit<T>.ShiftRight(x, y);

        /// <summary>
        /// <para>Performs a partial shift of a specified number of bits from source to target.</para>
        /// <para>Выполняет частичное смещение определенного количества бит из source в target.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>The value to which the partial write will be performed.</para>
        /// <para>Значение в которое будет выполнена частичная запись.</para>
        /// </param>
        /// <param name="source">
        /// <para>Data source for recording.</para>
        /// <para>Источник данных для записи.</para>
        /// </param>
        /// <param name="shift">
        /// <para>Record start position.</para>
        /// <para>Стартовая позиция записи.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to write from source to target.</para>
        /// <para>Количество бит, которые нужно записать из source в target.</para>
        /// </param>
        /// <returns>
        /// <para>Modified target value.</para>
        /// <para>Изменённое значение target.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite<T>(T target, T source, int shift, int limit) => Bit<T>.PartialWrite(target, source, shift, limit);

        /// <summary>
        /// <para>Shifts a specified number of bits into target.</para>
        /// <para>Сдвигает определенное количество бит в target.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип чисела.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>The value in which the partial write will be performed.</para>
        /// <para>Значение в котором будет выполнена частичная запись.</para>
        /// </param>
        /// <param name="shift">
        /// <para>Record start position.</para>
        /// <para>Стартовая позиция записи.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to shift.</para>
        /// <para>Количество бит, которые нужно сдвинуть.</para>
        /// </param>
        /// <returns>
        /// <para>Modified target value.</para>
        /// <para>Изменённое значение target.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
