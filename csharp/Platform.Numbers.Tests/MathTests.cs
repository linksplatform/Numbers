using System;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class MathTests
    {
        [Theory]
        [InlineData(0ul, 1ul)]
        [InlineData(1ul, 1ul)]
        [InlineData(2ul, 2ul)]
        [InlineData(3ul, 6ul)]
        [InlineData(4ul, 24ul)]
        [InlineData(5ul, 120ul)]
        [InlineData(6ul, 720ul)]
        [InlineData(10ul, 3628800ul)]
        [InlineData(20ul, 2432902008176640000ul)]
        public static void FactorialTest(ulong input, ulong expected)
        {
            Assert.Equal(expected, Math.Factorial(input));
        }

        [Theory]
        [InlineData(21ul)]
        [InlineData(100ul)]
        [InlineData(ulong.MaxValue)]
        public static void FactorialOutOfRangeTest(ulong input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Factorial(input));
        }

        [Theory]
        [InlineData(0ul, 1ul)]
        [InlineData(1ul, 1ul)]
        [InlineData(2ul, 2ul)]
        [InlineData(3ul, 5ul)]
        [InlineData(4ul, 14ul)]
        [InlineData(5ul, 42ul)]
        [InlineData(6ul, 132ul)]
        [InlineData(10ul, 16796ul)]
        [InlineData(36ul, 11959798385860453492ul)]
        public static void CatalanTest(ulong input, ulong expected)
        {
            Assert.Equal(expected, Math.Catalan(input));
        }

        [Theory]
        [InlineData(37ul)]
        [InlineData(100ul)]
        [InlineData(ulong.MaxValue)]
        public static void CatalanOutOfRangeTest(ulong input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Catalan(input));
        }

        [Theory]
        [InlineData(0ul, true)]
        [InlineData(1ul, true)]
        [InlineData(2ul, true)]
        [InlineData(3ul, false)]
        [InlineData(4ul, true)]
        [InlineData(5ul, false)]
        [InlineData(8ul, true)]
        [InlineData(16ul, true)]
        [InlineData(32ul, true)]
        [InlineData(64ul, true)]
        [InlineData(128ul, true)]
        [InlineData(256ul, true)]
        [InlineData(512ul, true)]
        [InlineData(1024ul, true)]
        [InlineData(1023ul, false)]
        [InlineData(1025ul, false)]
        [InlineData(9ul, false)]
        [InlineData(15ul, false)]
        [InlineData(17ul, false)]
        public static void IsPowerOfTwoTest(ulong input, bool expected)
        {
            Assert.Equal(expected, Math.IsPowerOfTwo(input));
        }

        [Fact]
        public static void FactorialGenericTest()
        {
            Assert.Equal(6u, Math.Factorial(3u));
            Assert.Equal(24ul, Math.Factorial(4ul));
        }

        [Fact]
        public static void CatalanGenericTest()
        {
            Assert.Equal(5u, Math.Catalan(3u));
            Assert.Equal(14ul, Math.Catalan(4ul));
        }

        [Fact]
        public static void IsPowerOfTwoGenericTest()
        {
            Assert.True(Math.IsPowerOfTwo(8u));
            Assert.False(Math.IsPowerOfTwo(9u));
            Assert.True(Math.IsPowerOfTwo(16ul));
            Assert.False(Math.IsPowerOfTwo(15ul));
        }

        [Fact]
        public static void MaximumConstantsTest()
        {
            Assert.Equal(20ul, Math.MaximumFactorialNumber);
            Assert.Equal(36ul, Math.MaximumCatalanIndex);
        }
    }
}