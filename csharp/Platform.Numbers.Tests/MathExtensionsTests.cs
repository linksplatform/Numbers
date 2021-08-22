using Xunit;

namespace Platform.Numbers.Tests
{
    /// <summary>
    /// <para>
    /// Represents the math extensions tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class MathExtensionsTests
    {
        /// <summary>
        /// <para>
        /// Tests that abs test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void AbsTest()
        {
            var number = -1L;
            var returnValue = number.Abs();
            Assert.Equal(1L, returnValue);
            Assert.Equal(1L, number);
        }

        /// <summary>
        /// <para>
        /// Tests that negate test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void NegateTest()
        {
            var number = 2L;
            var returnValue = number.Negate();
            Assert.Equal(-2L, returnValue);
            Assert.Equal(-2L, number);
        }

        /// <summary>
        /// <para>
        /// Tests that unsigned negate test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void UnsignedNegateTest()
        {
            var number = 2UL;
            var returnValue = number.Negate();
            Assert.Equal(18446744073709551614, returnValue);
            Assert.Equal(18446744073709551614, number);
        }
    }
}
