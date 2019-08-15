using System;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class ArithmeticTests
    {
        [Fact]
        public static void CompiledOperationsTest()
        {
            Assert.True(Arithmetic<short>.Add(1, 2) == 3);
            Assert.True(Arithmetic<byte>.Increment(1) == 2);
            Assert.True(Arithmetic<ulong>.Decrement(2) == 1);
            Assert.Throws<NotSupportedException>(() => Arithmetic<string>.Subtract("1", "2"));
        }
    }
}
