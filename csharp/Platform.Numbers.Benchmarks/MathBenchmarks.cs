using BenchmarkDotNet.Attributes;

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private const int FACTORIALTESTNUMBER = 19;

        [Benchmark]
        public long FactorialUsingRecursion()
        {
            return Math.Factorial(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialRecursionCountingArraylength()
        {
            return Math.FactorialRecursionCountingArraylength(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialUsingFactTree()
        {
            return Math.FactTree(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialOnly21()
        {
            return Math.FactorialOnly21(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialOf19()
        {
            return Math.FactorialOf19(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialWhileWithArray()
        {
            return Math.FactorialWhileWithArray(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialWhileWithoutArray()
        {
            return Math.FactorialWhileWithoutArray(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialWhileWithoutArrayAndCountingArrayLength()
        {
            return Math.FactorialWhileWithoutArrayAndCountingArrayLength(FACTORIALTESTNUMBER);
        }
    }
}
