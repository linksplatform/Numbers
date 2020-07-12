using BenchmarkDotNet.Attributes;

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private class Alternatives
        {
            /// <remarks>
            /// <para>Source: https://oeis.org/A000142/list </para>
            /// <para>Источник: https://oeis.org/A000142/list </para>
            /// </remarks>
            private static readonly ulong[] _factorials =
            {
                1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
                479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
                355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000,
            };

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

            public static ulong FactorialWithDirectArrayAccess(ulong n)
            {
                return _factorials[n];
            }

            public static ulong FactorialOf19()
            {
                return 121645100408832000;
            }

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

            public static ulong FactorialWhileLoopWithoutArray(ulong n)
            {
                if (n < (ulong)_factorials.Length) return _factorials[n];
                ulong r = n;
                while (n > 1) r *= --n;
                return r;
            }

            public static ulong FactorialWhileLoopWithoutArrayAndCountingArrayLength(ulong n)
            {
                if (n < 21) return _factorials[n];
                ulong r = n;
                while (n > 1) r *= --n;
                return r;
            }
        }

        private const ulong FactorialNumber = 19;

        [Benchmark]
        public ulong CurrentFactorialImplementation()
        {
            return Math.Factorial(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN()
        {
            return Alternatives.FactorialUsingStaticArrayAndRecursionWithContantAsMaximumN(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN()
        {
            return Alternatives.FactorialUsingStaticArrayAndRecursionWithArrayLengthFieldAsMaximumN(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialUsingFactTree()
        {
            return Alternatives.ConditionSeries(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialOnly21()
        {
            return Alternatives.FactorialWithDirectArrayAccess(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialOf19()
        {
            return Alternatives.FactorialOf19();
        }

        [Benchmark]
        public ulong FactorialWhileWithArray()
        {
            return Alternatives.FactorialWhileLoopWithArray(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialWhileWithoutArray()
        {
            return Alternatives.FactorialWhileLoopWithoutArray(FactorialNumber);
        }

        [Benchmark]
        public ulong FactorialWhileWithoutArrayAndCountingArrayLength()
        {
            return Alternatives.FactorialWhileLoopWithoutArrayAndCountingArrayLength(FactorialNumber);
        }
    }
}
