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
        private static readonly double[] _factorials =
        {
            1D, 1D, 2D, 6D, 24D, 120D, 720D, 5040D, 40320D, 362880D, 3628800D, 39916800D,
            479001600, 6227020800, 87178291200, 1307674368000D, 20922789888000D,
            355687428096000D, 6402373705728000D, 121645100408832000D, 2432902008176640000D,
            51090942171709440000D, 1124000727777607680000D
        };

        /// <remarks>
        /// <para>Source: https://oeis.org/A000108/list </para>
        /// <para>Источник: https://oeis.org/A000108/list </para>
        /// </remarks>
        private static readonly double[] _catalans =
        {
            1D,  1D,  2D,  5D,  14D,  42D,  132D,  429D,  1430D,  4862D,  16796D,  58786D,  208012D, 
            742900D,  2674440D,  9694845D,  35357670D,  129644790D,  477638700D,  1767263190D, 
            6564120420D,  24466267020D,  91482563640D,  343059613650D,  1289904147324D,  4861946401452D, 
            18367353072152D,  69533550916004D,  263747951750360D,  1002242216651368D,  3814986502092304D
        };

        /// <summary>
        /// <para>Generate the factorial of the value "n".</para>
        /// <para>Генерация факториaла из значения переменной "n".</para>
        /// </summary>
        /// <param name="n"><para>Factorial generation value.</para><para>Значение генерации факториала.</para></param>
        /// <returns><para>Result of factorial calculation.</para><para>Результат подсчета факториала</para></returns>
        public static double Factorial(double n)
        {
            if (n <= 1)
            {
                return 1;
            }
          
          
            if (n < _factorials.Length)
            {
                return _factorials[(int)n];
            }
            
            return n * Factorial(n - 1);
        }
        
        
        /// <summary>
        /// <para>Generating the Catalan Number of the value "n".</para>
        /// <para>Генерация числа Каталана из значения переменной "n".</para>
        /// </summary>
        /// <param name="n"><para>Catalan Number generation value.</para><para>Значение генерации Числа Каталана.</para></param>
        /// <returns><para>Result of Catalan Number calculation.</para><para>Результат подсчета Числа Каталана.</para></returns>
        public static double Catalan(double n)
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
