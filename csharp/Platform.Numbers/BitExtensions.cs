using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of bitwise operation.</para>
    /// <para>Представляет набор битовых операций.</para>
    /// </summary>
    public static class BitwiseExtensions
    {
        /// <summary>
        /// <para>Performing bitwise inversion of a number.</para>
        /// <para>Выполняет побитовую инверсию числа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbeк's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>Number to invert.</para>
        /// <para>Число для инверсии.</para>
        /// </param>
        /// <returns>
        /// <para>Inverse value of the number.</para>
        /// <para>Обратное значение числа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Not<T>(this ref T target) where T : struct => target = Bit.Not(target);

        /// <summary>
        /// <para>Performs a partial write of a specified number of bits from source number to target number.</para>
        /// <para>Выполняет частичную запись определенного количества бит исходного числа в целевое число.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers' type.</para>
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
        public static T PartialWrite<T>(this ref T target, T source, int shift, int limit) where T : struct => target = Bit<T>.PartialWrite(target, source, shift, limit);

        /// <summary>
        /// <para>Reads a specified number of bits from the number at specified position.</para>
        /// <para>Считывает указанное количество бит из числа в указанной позиции.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
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
        /// <para>Число состоящее из считанных из исходного числа бит.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(this T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
