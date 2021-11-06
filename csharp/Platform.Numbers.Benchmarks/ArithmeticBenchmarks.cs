using BenchmarkDotNet.Attributes;

#pragma warning disable CA1822 // Mark members as static

namespace Platform.Numbers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the arithmetic benchmarks.
    /// </para>
    /// <para></para>
    /// </summary>
    [SimpleJob]
    [MemoryDiagnoser]
    public class ArithmeticBenchmarks
    {
        /// <summary>
        /// <para>
        /// Increments the without ref.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The .</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int IncrementWithoutRef()
        {
            var x = 1;
            x = Arithmetic.Increment(x);
            return x;
        }

        /// <summary>
        /// <para>
        /// Increments the with ref.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The .</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int IncrementWithRef()
        {
            var x = 1;
            Arithmetic.Increment(ref x);
            return x;
        }

        /// <summary>
        /// <para>
        /// Decrements the without ref.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The .</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int DecrementWithoutRef()
        {
            var x = 1;
            x = Arithmetic.Decrement(x);
            return x;
        }

        /// <summary>
        /// <para>
        /// Decrements the with ref.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The .</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int DecrementWithRef()
        {
            var x = 1;
            Arithmetic.Decrement(ref x);
            return x;
        }
    }
}
