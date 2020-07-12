using BenchmarkDotNet.Running;
using System;

namespace Platform.Numbers.Benchmarks
{
    static class Program
    {
        static void Main() {
            //BenchmarkRunner.Run<ArithmeticBenchmarks>();
            BenchmarkRunner.Run<MathBenchmarks>();
        }
    }
}
