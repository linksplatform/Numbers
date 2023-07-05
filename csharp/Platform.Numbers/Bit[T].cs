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
        /// 
        /// </summary>
        /// <returns></returns>
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
