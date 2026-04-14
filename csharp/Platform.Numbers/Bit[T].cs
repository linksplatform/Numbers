using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Platform.Exceptions;
using Platform.Reflection;

// ReSharper disable StaticFieldInGenericType

namespace Platform.Numbers
{
    
    /// <summary>
    /// <para>Represents a set of compiled bit operations delegates.</para>
    /// <para>Представляет набор скомпилированных делегатов битовых операций.</para>
    /// </summary>
    public static class Bit<T> where T : INumberBase<T>, IShiftOperators<T, int, T> , IBitwiseOperators<T, T, T>, IMinMaxValue<T>
    {
        private static int BitsSize = NumericType<T>.BitsSize;

        /// <summary>
        /// <para>Writes a portion of the source value into the target value at the specified bit position.</para>
        /// <para>Записывает часть исходного значения в целевое значение в указанной битовой позиции.</para>
        /// </summary>
        /// <param name="target">
        /// <para>The target value to write to.</para>
        /// <para>Целевое значение для записи.</para>
        /// </param>
        /// <param name="source">
        /// <para>The source value to read from.</para>
        /// <para>Исходное значение для чтения.</para>
        /// </param>
        /// <param name="shift">
        /// <para>The bit position to start writing at.</para>
        /// <para>Битовая позиция для начала записи.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to write.</para>
        /// <para>Количество битов для записи.</para>
        /// </param>
        /// <returns>
        /// <para>The target value with the specified bits updated.</para>
        /// <para>Целевое значение с обновленными указанными битами.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite(T target, T source, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = BitsSize + shift;
            }
            if (limit < 0)
            {
                limit = BitsSize + limit;
            }
            var sourceMask = ~(T.MaxValue << limit) & T.MaxValue;
            var targetMask = ~(sourceMask << shift);
            return target & targetMask | (source & sourceMask) << shift;
        }
        
        /// <summary>
        /// <para>Reads a portion of bits from the target value at the specified bit position.</para>
        /// <para>Читает часть битов из целевого значения в указанной битовой позиции.</para>
        /// </summary>
        /// <param name="target">
        /// <para>The target value to read from.</para>
        /// <para>Целевое значение для чтения.</para>
        /// </param>
        /// <param name="shift">
        /// <para>The bit position to start reading from.</para>
        /// <para>Битовая позиция для начала чтения.</para>
        /// </param>
        /// <param name="limit">
        /// <para>The number of bits to read.</para>
        /// <para>Количество битов для чтения.</para>
        /// </param>
        /// <returns>
        /// <para>The extracted bits as a value.</para>
        /// <para>Извлеченные биты в виде значения.</para>
        /// </returns>
        public static T PartialRead(T target, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = BitsSize + shift;
            }
            if (limit < 0)
            {
                limit = BitsSize + limit;
            }
            var sourceMask = ~(T.MaxValue << limit) & T.MaxValue;
            var targetMask = sourceMask << shift;
            return (target & targetMask) >> shift;
        }
    }
}
