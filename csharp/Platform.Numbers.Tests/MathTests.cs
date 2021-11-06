using Xunit;

namespace Platform.Numbers.Tests
{
    /// <summary>
    /// <para>
    /// Represents the math tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class MathTests
    {
        /// <summary>
        /// <para>
        /// Tests that compiled operations test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void CompiledOperationsTest()
        {
            Assert.True(Math.Abs(Arithmetic<double>.Subtract(3D, 2D) - 1D) < 0.01);
        }
    }
}
