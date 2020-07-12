using BenchmarkDotNet.Attributes;
using Sharith.Arithmetic;
using Sharith.Factorial;

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class MathBenchmarks
    {
        private const int FACTORIALTESTNUMBER = 10000;

        [Benchmark]
        public int FactorialUsingRecursion()
        {
            return (int)Math.Factorial(FACTORIALTESTNUMBER);
        }

        [Benchmark]
        public XInt FactorialUsingParallelPrimeSwing()
        {
            var f = new ParallelPrimeSwing();
            return f.Factorial(FACTORIALTESTNUMBER);
        }
    }
}
