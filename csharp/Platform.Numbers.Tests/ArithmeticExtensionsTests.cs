using Xunit;

namespace Platform.Numbers.Tests
{
    /// <summary>
    /// <para>
    /// Represents the arithmetic extensions tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class ArithmeticExtensionsTests
    {
        /// <summary>
        /// <para>
        /// Tests that increment test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void IncrementTest()
        {
            var number = 0UL;
            var returnValue = number.Increment();
            Assert.Equal(1UL, returnValue);
            Assert.Equal(1UL, number);
        }

        /// <summary>
        /// <para>
        /// Tests that decrement test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void DecrementTest()
        {
            var number = 1UL;
            var returnValue = number.Decrement();
            Assert.Equal(0UL, returnValue);
            Assert.Equal(0UL, number);
        }
    }
}
