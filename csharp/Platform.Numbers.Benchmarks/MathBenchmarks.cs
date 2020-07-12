using BenchmarkDotNet.Attributes;

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private const int FACTORIALTESTNUMBER = 50000;

        [Benchmark]
        public long FactorialUsingRecursion()
        {
            return Math.Factorial(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public long FactorialUsingEratosthenesSieve()
        {
            return Math.FastFactor(FACTORIALTESTNUMBER);
        }
    }
}
