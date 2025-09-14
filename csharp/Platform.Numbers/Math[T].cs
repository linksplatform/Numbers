using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of math operations using direct reference to operator methods of .NET classes.</para>
    /// <para>Представляет набор математических операций, используя прямую ссылку на методы операторов классов .NET.</para>
    /// </summary>
    public static class Math<T> where T : INumberBase<T>
    {
        /// <summary>
        /// <para>Returns the absolute value of a number.</para>
        /// <para>Возвращает абсолютное значение числа.</para>
        /// </summary>
        /// <param name="x">The number to get the absolute value of.</param>
        /// <returns>The absolute value of the input number.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs(T x)
        {
            if (typeof(T) == typeof(sbyte))
                return T.CreateTruncating(System.Math.Abs((sbyte)(object)x));
            if (typeof(T) == typeof(short))
                return T.CreateTruncating(System.Math.Abs((short)(object)x));
            if (typeof(T) == typeof(int))
                return T.CreateTruncating(System.Math.Abs((int)(object)x));
            if (typeof(T) == typeof(long))
                return T.CreateTruncating(System.Math.Abs((long)(object)x));
            if (typeof(T) == typeof(float))
                return T.CreateTruncating(System.Math.Abs((float)(object)x));
            if (typeof(T) == typeof(double))
                return T.CreateTruncating(System.Math.Abs((double)(object)x));
            if (typeof(T) == typeof(decimal))
                return T.CreateTruncating(System.Math.Abs((decimal)(object)x));

            // For unsigned types, absolute value is the number itself
            return x;
        }

        /// <summary>
        /// <para>Returns the negation of a number.</para>
        /// <para>Возвращает отрицание числа.</para>
        /// </summary>
        /// <param name="x">The number to negate.</param>
        /// <returns>The negated value of the input number.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate(T x)
        {
            return -x;
        }
    }
}