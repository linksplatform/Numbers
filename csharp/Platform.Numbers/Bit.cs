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

        /// <summary>
        /// <para>Performing bitwise inversion of number.</para>
        /// <para>Выполненяет побитовую инверсии числа.</para>
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
        /// <para>Inverse value of the number</para>
        /// <para>Обратное значение числа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Not<T>(T x) => Bit<T>.Not(x);

        /// <summary>
        /// <para>Performing bitwise numbers addition.</para>
        /// <para>Выполняет побитовое сложение чисел.</para>
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
        /// <para>Numbers sum.</para>
        /// <para>Сумма чисел.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Or<T>(T x, T y) => Bit<T>.Or(x, y);

        /// <summary>
        /// <para>Performs bitwise numbers multiplication.</para>
        /// <para>Выполняет побитовое умножение чисел.</para>
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
        /// <para>Logical product of numbers.</para>
        /// <para>Логическое произведение чисел.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T And<T>(T x, T y) => Bit<T>.And(x, y);

        /// <summary>
        /// <para>Performs a bitwise shift of a number to the left by the specified number of bits.</para>
        /// <para>Выполняет побитовый свиг числа влево на указанное количество бит.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number on which the left bitwise shift operation will be performed.</para>
        /// <para>Число над которым будет производиться операция пиботового смещения влево.<para>
        /// </param>
        /// <param name="y">
        /// <para>The number of bits to shift.</para>
        /// <para>Количество бит на которые выполнить смещение.<para>
        /// </param>
        /// <returns>
        /// <para>The value with discarded high-order bits that are outside the range of the number type and set low-order empty bit positions to zero.</para>
        /// <para>Значение с отброшенными старшими битами, которые находятся за пределами диапазона типа числа и устанавливленными пустыми битовыми позициями младших разрядов в ноль.</para>
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
        /// <para>Число над которым будет производиться операция спобитового смещения вправо.<para>
        /// </param>
        /// <param name="y">
        /// <para>The number of bits to shift.</para>
        /// <para>Количество бит на которые выполнить смещение.<para>
        /// </param>
        /// <returns>
        /// <para>The value with discarded low-order bits.</para>
        /// <para>Значение с отброшенными младшими битами</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ShiftRight<T>(T x, int y) => Bit<T>.ShiftRight(x, y);

        /// <summary>
        /// <para>Performs a partial write of a specified number of bits from source number to target number.</para>
        /// <para>Выполняет частичную запись определенного количества бит исходного числа в целевое число.</para>
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
        /// <para>The start position to read from.</para>
        /// <para>Стартовая позиция чтения.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to write from source to target.</para>
        /// <para>Количество бит, которые нужно записать из source в target.</para>
        /// </param>
        /// <returns>
        /// <para>The target number updated with bits from source number.</para>
        /// <para>Целевое число с обновленными битами из исходного числа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite<T>(T target, T source, int shift, int limit) => Bit<T>.PartialWrite(target, source, shift, limit);

        /// <summary>
        /// <para>Reads a specified number of bits from the number at specified position.</para>
        /// <para>Считывает указанное количество бит из числа в указанной позиции.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>The number from which the partial read will be performed.</para>
        /// <para>Число из которого будет выполнено частичное чтение.</para>
        /// </param>
        /// <param name="shift">
        /// <para>The start position to read from.</para>
        /// <para>Стартовая позиция чтения.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to read.</para>
        /// <para>Количество бит, которые нужно считать.</para>
        /// </param>
        /// <returns>
        /// <para>The number consisting of bits read from the source number.</para>
        /// <para>Число состоящие из считанных из исходного числа бит.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
