using System.ComponentModel;
using System.Numerics;
using BenchmarkDotNet.Attributes;

#pragma warning disable CA1822 // Mark members as static

namespace Platform.Numbers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class ArithmeticBenchmarks
    {
        [Params(100, 1000)]
        public ulong N { get; set; }
        static T Add<T>(T left, T right)
            where T : INumber<T>
        {
            return left + right;
        }
        
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

        [Benchmark]
        public ulong AddWithGenericMath()
        {
            ulong result = default;
            for (ulong i = 0; i < N; i++)
            {
                result = Add(i, i);
            }
            return result;
        }
        
        [Benchmark]
        public ulong AddByPlusOperator()
        {
            ulong result = default;
            for (ulong i = 0; i < N; i++)
            {
                result = i + i;
            }
            return result;
        }
    }
}
