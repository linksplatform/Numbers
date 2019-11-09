using System;
using BenchmarkDotNet.Attributes;

#pragma warning disable CA1822 // Mark members as static

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class ArithmeticBenchmarks
    {
        [Benchmark]
        public int IncrementWithoutRef()
        {
            var x = 1;
            x = Arithmetic.Increment(x);
            return x;
        }

        [Benchmark]
        public int IncrementWithRef()
        {
            var x = 1;
            Arithmetic.Increment(ref x);
            return x;
        }

        [Benchmark]
        public int DecrementWithoutRef()
        {
            var x = 1;
            x = Arithmetic.Decrement(x);
            return x;
        }

        [Benchmark]
        public int DecrementWithRef()
        {
            var x = 1;
            Arithmetic.Decrement(ref x);
            return x;
        }
    }
}
