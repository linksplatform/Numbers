using System;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class IntegerTests
    {
        [Fact]
        [Obsolete]
        public static void SignedIntegersTest()
        {
            var integer = -10;
            Assert.True(((Integer)integer) == -10L);
        }
    }
}
