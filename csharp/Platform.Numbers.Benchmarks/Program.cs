using BenchmarkDotNet.Running;

namespace Platform.Numbers.Benchmarks
{
    static class Program
    {
        static void Main() => BenchmarkRunner.Run<ArithmeticBenchmarks>();
    }
}
