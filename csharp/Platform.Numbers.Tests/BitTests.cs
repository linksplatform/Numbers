using System;
using Platform.Reflection;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class BitTests
    {
        [Theory]
        [InlineData(00, -1)] // 0000 0000 (none, -1)
        [InlineData(01, 00)] // 0000 0001 (first, 0)
        [InlineData(08, 03)] // 0000 1000 (forth, 3)
        [InlineData(88, 03)] // 0101 1000 (forth, 3)
        public static void GetLowestBitPositionTest(ulong value, int expectedPosition)
        {
            Assert.True(Bit.GetLowestPosition(value) == expectedPosition);
        }

        [Fact]
        public static void PartialReadWriteTest()
        {
            {
                uint firstValue = 1;
                uint secondValue = 1543;

                // Pack (join) two values at the same time
                uint value = secondValue << 1 | firstValue;

                uint unpackagedFirstValue = value & 1;
                uint unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert.True(firstValue == unpackagedFirstValue);
                Assert.True(secondValue == unpackagedSecondValue);

                // Using universal functions:
                Assert.True(PartialRead(value, 0, 1) == firstValue);
                Assert.True(PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = PartialWrite(value, firstValue, 0, 1);
                value = PartialWrite(value, secondValue, 1, -1);

                Assert.True(PartialRead(value, 0, 1) == firstValue);
                Assert.True(PartialRead(value, 1, -1) == secondValue);
            }

            {
                uint firstValue = 1;
                uint secondValue = 1543;

                // Pack (join) two values at the same time
                uint value = secondValue << 1 | firstValue;

                uint unpackagedFirstValue = value & 1;
                uint unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert.True(firstValue == unpackagedFirstValue);
                Assert.True(secondValue == unpackagedSecondValue);

                // Using universal functions:
                Assert.True(Bit<uint>.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit<uint>.PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = Bit<uint>.PartialWrite(value, firstValue, 0, 1);
                value = Bit<uint>.PartialWrite(value, secondValue, 1, -1);

                Assert.True(Bit<uint>.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit<uint>.PartialRead(value, 1, -1) == secondValue);
            }

            {
                uint firstValue = 1;
                uint secondValue = 1543;

                // Pack (join) two values at the same time
                uint value = secondValue << 1 | firstValue;

                uint unpackagedFirstValue = value & 1;
                uint unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert.True(firstValue == unpackagedFirstValue);
                Assert.True(secondValue == unpackagedSecondValue);

                // Using universal functions:
                var readMasksAndShiftFor0And1 = GetReadMaskAndShift(0, 1);
                var readMasksAndShiftFor1AndMinus1 = GetReadMaskAndShift(1, -1);
                var writeMasksAndShiftFor0And1 = GetWriteMasksAndShift(0, 1);
                var writeMasksAndShiftFor1AndMinus1 = GetWriteMasksAndShift(1, -1);

                Assert.True(PartialRead(value, readMasksAndShiftFor0And1) == firstValue);
                Assert.True(PartialRead(value, readMasksAndShiftFor1AndMinus1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = PartialWrite(value, firstValue, writeMasksAndShiftFor0And1);
                value = PartialWrite(value, secondValue, writeMasksAndShiftFor1AndMinus1);

                Assert.True(PartialRead(value, readMasksAndShiftFor0And1) == firstValue);
                Assert.True(PartialRead(value, readMasksAndShiftFor1AndMinus1) == secondValue);
            }
        }

        // TODO: Can be optimized using precalculation of TargetMask and SourceMask
        private static uint PartialWrite(uint target, uint source, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            var sourceMask = ~(uint.MaxValue << limit) & uint.MaxValue;
            var targetMask = ~(sourceMask << shift);
            return target & targetMask | (source & sourceMask) << shift;
        }
        private static uint PartialRead(uint target, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            var sourceMask = ~(uint.MaxValue << limit) & uint.MaxValue;
            var targetMask = sourceMask << shift;
            return (target & targetMask) >> shift;
        }
        private static Tuple<uint, uint, int> GetWriteMasksAndShift(int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            var sourceMask = ~(uint.MaxValue << limit) & uint.MaxValue;
            var targetMask = ~(sourceMask << shift);
            return new Tuple<uint, uint, int>(targetMask, sourceMask, shift);
        }
        private static Tuple<uint, int> GetReadMaskAndShift(int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            var sourceMask = ~(uint.MaxValue << limit) & uint.MaxValue;
            var targetMask = sourceMask << shift;
            return new Tuple<uint, int>(targetMask, shift);
        }
        private static uint PartialWrite(uint target, uint targetMask, uint source, uint sourceMask, int shift) => target & targetMask | (source & sourceMask) << shift;
        private static uint PartialWrite(uint target, uint source, Tuple<uint, uint, int> masksAndShift) => PartialWrite(target, masksAndShift.Item1, source, masksAndShift.Item2, masksAndShift.Item3);
        private static uint PartialRead(uint target, uint targetMask, int shift) => (target & targetMask) >> shift;
        private static uint PartialRead(uint target, Tuple<uint, int> masksAndShift) => PartialRead(target, masksAndShift.Item1, masksAndShift.Item2);

        [Fact]
        public static void BugWithLoadingConstantOf8Test()
        {
            Bit<byte>.PartialWrite(0, 1, 5, -5);
        }

        [Theory]
        [InlineData(0L, 0)]
        [InlineData(1L, 1)]
        [InlineData(2L, 1)]
        [InlineData(3L, 2)]
        [InlineData(4L, 1)]
        [InlineData(5L, 2)]
        [InlineData(7L, 3)]
        [InlineData(8L, 1)]
        [InlineData(15L, 4)]
        [InlineData(255L, 8)]
        [InlineData(1023L, 10)]
        [InlineData(-1L, 64)]
        [InlineData(long.MaxValue, 63)]
        public static void BitCountTest(long value, int expectedCount)
        {
            Assert.Equal(expectedCount, Bit.Count(value));
        }

        [Fact]
        public static void BitGenericPartialWriteWithNegativeShiftTest()
        {
            uint target = 0xFFFFFFFF;
            uint source = 0b101;
            
            uint result = Bit<uint>.PartialWrite(target, source, -5, 3);
            
            // -5 becomes 32-5=27, so we write 101 at positions 27-29
            uint expected = 0xEFFFFFFF; // 11101111111111111111111111111111
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void BitGenericPartialReadWithNegativeShiftTest()
        {
            uint target = 0xEFFFFFFF; // 11101111111111111111111111111111
            
            uint result = Bit<uint>.PartialRead(target, -5, 3);
            
            // -5 becomes 27, read 3 bits at position 27-29 should give 101
            uint expected = 0b101;
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void BitGenericPartialWriteWithNegativeLimitTest()
        {
            uint target = 0;
            uint source = 0b111;
            
            uint result = Bit<uint>.PartialWrite(target, source, 0, -29);
            
            uint expected = 0b111;
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void BitGenericPartialReadWithNegativeLimitTest()
        {
            uint target = 0b111;
            
            uint result = Bit<uint>.PartialRead(target, 0, -29);
            
            uint expected = 0b111;
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void BitGenericPartialWriteReadRoundTripTest()
        {
            uint original = 0b10110101;
            uint value1 = 0b011;
            uint value2 = 0b1010;
            
            uint packed = Bit<uint>.PartialWrite(original, value1, 2, 3);
            packed = Bit<uint>.PartialWrite(packed, value2, 8, 4);
            
            uint extracted1 = Bit<uint>.PartialRead(packed, 2, 3);
            uint extracted2 = Bit<uint>.PartialRead(packed, 8, 4);
            
            Assert.Equal(value1, extracted1);
            Assert.Equal(value2, extracted2);
        }

        [Theory]
        [InlineData(typeof(byte))]
        [InlineData(typeof(ushort))]
        [InlineData(typeof(uint))]
        [InlineData(typeof(ulong))]
        public static void BitGenericWorksWithDifferentTypes(Type numericType)
        {
            if (numericType == typeof(byte))
            {
                byte result = Bit<byte>.PartialWrite(0, 3, 1, 2);
                Assert.Equal((byte)6, result);
                Assert.Equal((byte)3, Bit<byte>.PartialRead(result, 1, 2));
            }
            else if (numericType == typeof(ushort))
            {
                ushort result = Bit<ushort>.PartialWrite(0, 3, 1, 2);
                Assert.Equal((ushort)6, result);
                Assert.Equal((ushort)3, Bit<ushort>.PartialRead(result, 1, 2));
            }
            else if (numericType == typeof(uint))
            {
                uint result = Bit<uint>.PartialWrite(0, 3, 1, 2);
                Assert.Equal(6u, result);
                Assert.Equal(3u, Bit<uint>.PartialRead(result, 1, 2));
            }
            else if (numericType == typeof(ulong))
            {
                ulong result = Bit<ulong>.PartialWrite(0, 3, 1, 2);
                Assert.Equal(6ul, result);
                Assert.Equal(3ul, Bit<ulong>.PartialRead(result, 1, 2));
            }
        }
    }
}
