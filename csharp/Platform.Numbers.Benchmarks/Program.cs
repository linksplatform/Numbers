using BenchmarkDotNet.Running;
using System;

namespace Platform.Numbers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the program.
    /// </para>
    /// <para></para>
    /// </summary>
    static class Program
    {
        /// <summary>
        /// <para>
        /// Main.
        /// </para>
        /// <para></para>
        /// </summary>
        static void Main() {
            //BenchmarkRunner.Run<ArithmeticBenchmarks>();
            BenchmarkRunner.Run<MathBenchmarks>();
        }
    }
}
