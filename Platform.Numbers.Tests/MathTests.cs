using Xunit;
using Platform.Numbers;

namespace Platform.Tests.Numbers
{
    public class MathTests
    {
        [Fact]
        public void CompiledOperationsTest()
        {
            Assert.True(Math.Abs(Arithmetic<double>.Subtract(3D, 2D) - 1D) < 0.01);
        }
    }
}
