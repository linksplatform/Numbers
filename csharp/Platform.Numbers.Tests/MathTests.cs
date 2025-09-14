using Xunit;

namespace Platform.Numbers.Tests
{
    public static class MathTests
    {
        [Fact]
        public static void AbsTest()
        {
            // Test with signed integers
            Assert.Equal(5, Math<int>.Abs(-5));
            Assert.Equal(5, Math<int>.Abs(5));
            Assert.Equal(0, Math<int>.Abs(0));
            
            // Test with long
            Assert.Equal(123L, Math<long>.Abs(-123L));
            Assert.Equal(123L, Math<long>.Abs(123L));
            
            // Test with double
            Assert.Equal(3.14, Math<double>.Abs(-3.14));
            Assert.Equal(3.14, Math<double>.Abs(3.14));
            
            // Test with unsigned types (should return same value)
            Assert.Equal(42u, Math<uint>.Abs(42u));
            Assert.Equal(0u, Math<uint>.Abs(0u));
        }

        [Fact]
        public static void NegateTest()
        {
            // Test with signed integers
            Assert.Equal(-5, Math<int>.Negate(5));
            Assert.Equal(5, Math<int>.Negate(-5));
            Assert.Equal(0, Math<int>.Negate(0));
            
            // Test with long
            Assert.Equal(-123L, Math<long>.Negate(123L));
            Assert.Equal(123L, Math<long>.Negate(-123L));
            
            // Test with double
            Assert.Equal(-3.14, Math<double>.Negate(3.14));
            Assert.Equal(3.14, Math<double>.Negate(-3.14));
            
            // Test with float
            Assert.Equal(-2.5f, Math<float>.Negate(2.5f));
            Assert.Equal(2.5f, Math<float>.Negate(-2.5f));
        }
    }
}