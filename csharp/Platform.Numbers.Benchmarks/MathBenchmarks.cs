using BenchmarkDotNet.Attributes;

namespace Platform.Numbers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the math benchmarks.
    /// </para>
    /// <para></para>
    /// </summary>
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private class Alternatives
        {
            private static readonly ulong[] _factorials =
            {
                1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
                479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
                355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000,
            };

            /// <summary>
            /// <para>
            /// Factorials the using static array and recursion with contant as maximum n using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The ulong</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN(ulong n)
            {
                if (n <= 1)
                {
                    return 1;
                }
                if (n < 21)
                {
                    return _factorials[n];
                }
                return n * FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN(n - 1);
            }

            /// <summary>
            /// <para>
            /// Factorials the using static array and recursion with array length field as maximum n using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The ulong</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN(ulong n)
            {
                if (n <= 1)
                {
                    return 1;
                }
                if (n < (ulong)_factorials.Length)
                {
                    return _factorials[n];
                }
                return n * FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN(n - 1);
            }

            /// <summary>
            /// <para>
            /// Factorials the with direct array access using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The ulong</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialWithDirectArrayAccess(ulong n)
            {
                return _factorials[n];
            }

            /// <summary>
            /// <para>
            /// Factorials the of 19.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <returns>
            /// <para>The ulong</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialOf19()
            {
                return 121645100408832000;
            }

            /// <summary>
            /// <para>
            /// Conditions the series using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The ulong</para>
            /// <para></para>
            /// </returns>
            public static ulong ConditionSeries(ulong n)
            {
                if (n < 0)
                    return 0;
                if (n == 0)
                    return 1;
                if (n == 1 || n == 2)
                    return 1;
                if (n == 3) return 2;
                if (n == 4) return 6;
                if (n == 5) return 24;
                if (n == 6) return 120;
                if (n == 7) return 720;
                if (n == 8) return 5040;
                if (n == 9) return 40320;
                if (n == 10) return 362880;
                if (n == 11) return 3628800;
                if (n == 12) return 39916800;
                if (n == 13) return 479001600;
                if (n == 14) return 6227020800;
                if (n == 15) return 87178291200;
                if (n == 16) return 1307674368000;
                if (n == 17) return 20922789888000;
                if (n == 18) return 355687428096000;
                if (n == 19) return 6402373705728000;
                if (n == 20) return 121645100408832000;
                if (n == 21) return 2432902008176640000;
                return n * ConditionSeries(n - 1);
            }

            /// <summary>
            /// <para>
            /// Factorials the while loop with array using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The .</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialWhileLoopWithArray(ulong n)
            {
                ulong[] _facts =
                {
                    1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
                    479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
                    355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000,
                };
                if (n < (ulong)_facts.Length) return _facts[n];
                ulong r = n;
                while (n > 1) r *= --n;
                return r;
            }

            /// <summary>
            /// <para>
            /// Factorials the while loop without array using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The .</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialWhileLoopWithoutArray(ulong n)
            {
                if (n < (ulong)_factorials.Length) return _factorials[n];
                ulong r = n;
                while (n > 1) r *= --n;
                return r;
            }

            /// <summary>
            /// <para>
            /// Factorials the while loop without array and counting array length using the specified n.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="n">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The .</para>
            /// <para></para>
            /// </returns>
            public static ulong FactorialWhileLoopWithoutArrayAndCountingArrayLength(ulong n)
            {
                if (n < 21) return _factorials[n];
                ulong r = n;
                while (n > 1) r *= --n;
                return r;
            }
        }
        private const ulong FactorialNumber = 19;

        /// <summary>
        /// <para>
        /// Currents the factorial implementation.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong CurrentFactorialImplementation()
        {
            return Math.Factorial(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the using static array and recursion with contant as maximum n.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN()
        {
            return Alternatives.FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the using static array and recursion with array length field as maximum n.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN()
        {
            return Alternatives.FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the using fact tree.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialUsingFactTree()
        {
            return Alternatives.ConditionSeries(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the only 21.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialOnly21()
        {
            return Alternatives.FactorialWithDirectArrayAccess(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the of 19.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialOf19()
        {
            return Alternatives.FactorialOf19();
        }

        /// <summary>
        /// <para>
        /// Factorials the while with array.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialWhileWithArray()
        {
            return Alternatives.FactorialWhileLoopWithArray(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the while without array.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialWhileWithoutArray()
        {
            return Alternatives.FactorialWhileLoopWithoutArray(FactorialNumber);
        }

        /// <summary>
        /// <para>
        /// Factorials the while without array and counting array length.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The ulong</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public ulong FactorialWhileWithoutArrayAndCountingArrayLength()
        {
            return Alternatives.FactorialWhileLoopWithoutArrayAndCountingArrayLength(FactorialNumber);
        }
    }
}
