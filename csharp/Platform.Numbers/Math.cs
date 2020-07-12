using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly long[] _factorials =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000,
        };

        /// <remarks>
        /// <para>Source: https://oeis.org/A000108/list </para>
        /// <para>Источник: https://oeis.org/A000108/list </para>
        /// </remarks>
        private static readonly long[] _catalans =
        {
            1,  1,  2,  5,  14,  42,  132,  429,  1430,  4862,  16796,  58786,  208012, 
            742900,  2674440,  9694845,  35357670,  129644790,  477638700,  1767263190, 
            6564120420,  24466267020,  91482563640,  343059613650,  1289904147324,  4861946401452, 
            18367353072152,  69533550916004,  263747951750360,  1002242216651368,  3814986502092304
        };

        /// <summary>
        /// <para>Generate the factorial of the value "n".</para>
        /// <para>Генерация факториaла из значения переменной "n".</para>
        /// </summary>
        /// <param name="n"><para>Factorial generation value.</para><para>Значение генерации факториала.</para></param>
        /// <returns><para>Result of factorial calculation.</para><para>Результат подсчета факториала</para></returns>
        public static long Factorial(long n)
        {
            if (n <= 1)
            {
                return 1;
            }
          
          
            if (n < _factorials.Length)
            {
                return _factorials[n];
            }
            
            return n * Factorial(n - 1);
        }

        /// <summary>
        /// <para>Generate the factorial of the value "n".</para>
        /// <para>Генерация факториaла из значения переменной "n".</para>
        /// </summary>
        /// <param name="n"><para>Factorial generation value.</para><para>Значение генерации факториала.</para></param>
        /// <returns><para>Result of factorial calculation.</para><para>Результат подсчета факториала</para></returns>
        public static long FactorialEratosthenesSieve(long n)
        {
            long r = n;
            while (n > 1)
                r *= --n;
            return r;
        }

        /// <summary>
        /// <para>Generating the Catalan Number of the value "n".</para>
        /// <para>Генерация числа Каталана из значения переменной "n".</para>
        /// </summary>
        /// <param name="n"><para>Catalan Number generation value.</para><para>Значение генерации Числа Каталана.</para></param>
        /// <returns><para>Result of Catalan Number calculation.</para><para>Результат подсчета Числа Каталана.</para></returns>
        public static long Catalan(int n)
        {
           
           
            if (n <= 1)
            {
                return 1;
            }
            if (n < _catalans.Length)
            {
                return _catalans[(int)n];
            }
            return Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo(ulong x) => (x & x - 1) == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(T x) => Math<T>.Abs(x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate<T>(T x) => Math<T>.Negate(x);
    }
}
