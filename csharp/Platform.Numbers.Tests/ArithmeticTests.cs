using System;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class ArithmeticTests
    {
        [Fact]
        public static void CompiledOperationsTest()
        {
            Assert.Equal(3, Arithmetic.Add(1, 2));
            Assert.Equal(1, Arithmetic.Subtract(2, 1));
            Assert.Equal(8, Arithmetic.Multiply(2, 4));
            Assert.Equal(4, Arithmetic.Divide(8, 2));
            Assert.Equal(2, Arithmetic.Increment(1));
            Assert.Equal(1UL, Arithmetic.Decrement(2UL));
            Assert.Throws<NotSupportedException>(() => Arithmetic<string>.Subtract("1", "2"));
        }
    }
}
