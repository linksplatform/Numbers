using BenchmarkDotNet.Attributes;

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private const int FACTORIALTESTNUMBER = 10000;

        [Benchmark]
        public long FactorialUsingRecursion()
        {
            return Math.Factorial(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialUsingFactTree()
        {
            return Math.FactTree(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialUsingRecursionWihoutStaticField()
        {
            return Math.FactorialStatic(FACTORIALTESTNUMBER);
        }
    }
}
