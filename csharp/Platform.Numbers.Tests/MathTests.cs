using System;
using System.Collections.Generic;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class MathTests
    {
        [Fact]
        public static void AddTest()
        {
            Assert.Equal(5, Math.Add(2, 3));
            Assert.Equal(5.5, Math.Add(2.2, 3.3));
            Assert.Equal(7L, Math.Add(3L, 4L));
            Assert.Equal((ulong)10, Math.Add((ulong)4, (ulong)6));
        }

        [Fact]
        public static void SubtractTest()
        {
            Assert.Equal(2, Math.Subtract(5, 3));
            Assert.Equal(-1.1, Math.Subtract(2.2, 3.3), 1);
            Assert.Equal(-1L, Math.Subtract(3L, 4L));
            Assert.Equal((ulong)2, Math.Subtract((ulong)6, (ulong)4));
        }

        [Fact]
        public static void MultiplyTest()
        {
            Assert.Equal(6, Math.Multiply(2, 3));
            Assert.Equal(7.26, Math.Multiply(2.2, 3.3), 2);
            Assert.Equal(12L, Math.Multiply(3L, 4L));
            Assert.Equal((ulong)24, Math.Multiply((ulong)4, (ulong)6));
        }

        [Fact]
        public static void DivideTest()
        {
            Assert.Equal(2, Math.Divide(6, 3));
            Assert.Equal(2.0, Math.Divide(4.0, 2.0));
            Assert.Equal(2L, Math.Divide(8L, 4L));
            Assert.Equal((ulong)3, Math.Divide((ulong)12, (ulong)4));
        }

        [Fact]
        public static void NegateTest()
        {
            Assert.Equal(-5, Math.Negate(5));
            Assert.Equal(5, Math.Negate(-5));
            Assert.Equal(-3.14, Math.Negate(3.14));
            Assert.Equal(-100L, Math.Negate(100L));
        }

        [Fact]
        public static void MinTest()
        {
            Assert.Equal(2, Math.Min(2, 3));
            Assert.Equal(2, Math.Min(3, 2));
            Assert.Equal(2.2, Math.Min(2.2, 3.3));
            Assert.Equal(3L, Math.Min(3L, 4L));
            Assert.Equal((ulong)4, Math.Min((ulong)4, (ulong)6));
        }

        [Fact]
        public static void MaxTest()
        {
            Assert.Equal(3, Math.Max(2, 3));
            Assert.Equal(3, Math.Max(3, 2));
            Assert.Equal(3.3, Math.Max(2.2, 3.3));
            Assert.Equal(4L, Math.Max(3L, 4L));
            Assert.Equal((ulong)6, Math.Max((ulong)4, (ulong)6));
        }

        [Fact]
        public static void AbsTest()
        {
            Assert.Equal(5, Math.Abs(-5));
            Assert.Equal(5, Math.Abs(5));
            Assert.Equal(3.14, Math.Abs(-3.14));
            Assert.Equal(3.14, Math.Abs(3.14));
            Assert.Equal(100L, Math.Abs(-100L));
            Assert.Equal(100L, Math.Abs(100L));
        }

        [Fact]
        public static void SignTest()
        {
            Assert.Equal(-1, Math.Sign(-5));
            Assert.Equal(1, Math.Sign(5));
            Assert.Equal(0, Math.Sign(0));
            Assert.Equal(-1, Math.Sign(-3.14));
            Assert.Equal(1, Math.Sign(3.14));
            Assert.Equal(0, Math.Sign(0.0));
            Assert.Equal(-1, Math.Sign(-100L));
            Assert.Equal(1, Math.Sign(100L));
            Assert.Equal(0, Math.Sign(0L));
        }

        [Fact]
        public static void SumTest()
        {
            var intValues = new List<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(15, Math.Sum(intValues));

            var doubleValues = new List<double> { 1.1, 2.2, 3.3 };
            Assert.Equal(6.6, Math.Sum(doubleValues), 1);

            var longValues = new List<long> { 10L, 20L, 30L };
            Assert.Equal(60L, Math.Sum(longValues));

            var emptyValues = new List<int>();
            Assert.Equal(0, Math.Sum(emptyValues));
        }

        [Fact]
        public static void AverageTest()
        {
            var intValues = new List<int> { 2, 4, 6 };
            Assert.Equal(4, Math.Average(intValues));

            var doubleValues = new List<double> { 1.0, 2.0, 3.0, 4.0 };
            Assert.Equal(2.5, Math.Average(doubleValues));

            var longValues = new List<long> { 10L, 20L, 30L };
            Assert.Equal(20L, Math.Average(longValues));
        }

        [Fact]
        public static void AverageThrowsOnEmptySequenceTest()
        {
            var emptyValues = new List<int>();
            Assert.Throws<InvalidOperationException>(() => Math.Average(emptyValues));
        }

        [Fact]
        public static void ZeroTest()
        {
            Assert.Equal(0, Math.Zero<int>());
            Assert.Equal(0.0, Math.Zero<double>());
            Assert.Equal(0L, Math.Zero<long>());
            Assert.Equal((ulong)0, Math.Zero<ulong>());
        }

        [Fact]
        public static void OneTest()
        {
            Assert.Equal(1, Math.One<int>());
            Assert.Equal(1.0, Math.One<double>());
            Assert.Equal(1L, Math.One<long>());
            Assert.Equal((ulong)1, Math.One<ulong>());
        }

        [Fact]
        public static void ExistingFunctionalityTest()
        {
            // Test that existing functionality still works
            Assert.Equal((ulong)1, Math.Factorial((ulong)0));
            Assert.Equal((ulong)1, Math.Factorial((ulong)1));
            Assert.Equal((ulong)120, Math.Factorial((ulong)5));

            Assert.Equal((ulong)1, Math.Catalan((ulong)0));
            Assert.Equal((ulong)1, Math.Catalan((ulong)1));
            Assert.Equal((ulong)5, Math.Catalan((ulong)3));

            Assert.True(Math.IsPowerOfTwo((ulong)1));
            Assert.True(Math.IsPowerOfTwo((ulong)2));
            Assert.True(Math.IsPowerOfTwo((ulong)4));
            Assert.True(Math.IsPowerOfTwo((ulong)8));
            Assert.False(Math.IsPowerOfTwo((ulong)3));
            Assert.False(Math.IsPowerOfTwo((ulong)5));
        }
    }
}