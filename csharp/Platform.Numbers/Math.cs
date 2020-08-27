using System;
using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <remarks>
    /// Resizable array (FileMappedMemory) for values cache may be used. or cached oeis.org
    /// </remarks>
    public static class Math
    {
        /// <remarks>
        /// <para>Source: https://oeis.org/A000142/list </para>
        /// <para>Источник: https://oeis.org/A000142/list </para>
        /// </remarks>

        private static readonly ulong[] _factorials =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000
        };

        /// <remarks>
        /// <para>Source: https://oeis.org/A000108/list </para>
        /// <para>Источник: https://oeis.org/A000108/list </para>
        /// </remarks>
        private static readonly ulong[] _catalans =
        {
            1,  1,  2,  5,  14,  42,  132,  429,  1430,  4862,  16796,  58786,  208012,
            742900,  2674440,  9694845,  35357670,  129644790,  477638700,  1767263190,
            6564120420,  24466267020,  91482563640,  343059613650,  1289904147324,  4861946401452,
            18367353072152,  69533550916004,  263747951750360,  1002242216651368,  3814986502092304,
            14544636039226909, 55534064877048198, 212336130412243110, 812944042149730764, 3116285494907301262, 11959798385860453492
        };

        public static readonly ulong MaximumFactorialNumber = 20;

        public static readonly ulong MaximumCatalanIndex = 36;

        /// <summary>
        /// <para>Returns the product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Возвращает произведение всех положительных чисел меньше или равных указанному в качестве аргумента числу.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The maximum positive number that will participate in factorial's product.</para>
        /// <para>Максимальное положительное число, которое будет участвовать в произведение факториала.</para>
        /// </param>
        /// <returns>
        /// <para>The product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Произведение всех положительных чисел меньше или равных указанному в качестве аргумента числу.</para>
        /// </returns>
        public static ulong Factorial(ulong n)
        {
            if (n >= 0 && n <= MaximumFactorialNumber)
            {
                return _factorials[n];
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Only numbers from 0 to {MaximumFactorialNumber} are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>Returns the Catalan Number with the number specified as an argument.</para>
        /// <para>Возвращает Каталановое число с номером указанным в качестве аргумента.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The number of Catalan number.</para>
        /// <para>Номер Каталанового числа.</para>
        /// </param>
        /// <returns>
        /// <para>The Catalan Number with the number specified as an argument.</para>
        /// <para>Каталановое число с номером указанным в качестве аргумента.</para>
        /// </returns>
        public static ulong Catalan(ulong n)
        {
            if (n >= 0 && n <= MaximumCatalanIndex)
            {
                return _catalans[n];
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Only numbers from 0 to {MaximumCatalanIndex} are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <param name="x">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(ulong x) => (x & x - 1) == 0;

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(T x) => Math<T>.Abs(x);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate<T>(T x) => Math<T>.Negate(x);
    }
}
