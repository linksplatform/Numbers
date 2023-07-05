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
        public static void GetLowestBitPositionTestForUint(uint value, int expectedPosition)
        {
            Assert.True(Bit.GetLowestPosition(value) == expectedPosition);
        }

        [Fact]
        public static void PartialReadWriteTestForUint()
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
                var readMasksAndShiftFor0And1 = GetReadMaskAndShiftForUint(0, 1);
                var readMasksAndShiftFor1AndMinus1 = GetReadMaskAndShiftForUint(1, -1);
                var writeMasksAndShiftFor0And1 = GetWriteMasksAndShiftForUint(0, 1);
                var writeMasksAndShiftFor1AndMinus1 = GetWriteMasksAndShiftForUint(1, -1);

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
        private static Tuple<uint, uint, int> GetWriteMasksAndShiftForUint(int shift, int limit)
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
        private static Tuple<uint, int> GetReadMaskAndShiftForUint(int shift, int limit)
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
        
        // TESTS FOR ULONG
        [Theory]
        [InlineData(00, -1)] // 0000 0000 (none, -1)
        [InlineData(01, 00)] // 0000 0001 (first, 0)
        [InlineData(08, 03)] // 0000 1000 (forth, 3)
        [InlineData(88, 03)] // 0101 1000 (forth, 3)
        public static void GetLowestBitPositionTestForUlong(ulong value, int expectedPosition)
        {
            Assert.True(Bit.GetLowestPosition(value) == expectedPosition);
        }

        [Fact]
        public static void PartialReadWriteTestForUlong()
        {
            {
                ulong firstValue = 1;
                ulong secondValue = 1543;

                // Pack (join) two values at the same time
                ulong value = secondValue << 1 | firstValue;

                ulong unpackagedFirstValue = value & 1;
                ulong unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

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
                ulong firstValue = 1;
                ulong secondValue = 1543;

                // Pack (join) two values at the same time
                ulong value = secondValue << 1 | firstValue;

                ulong unpackagedFirstValue = value & 1;
                ulong unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert.True(firstValue == unpackagedFirstValue);
                Assert.True(secondValue == unpackagedSecondValue);

                // Using universal functions:
                Assert.True(Bit<ulong>.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit<ulong>.PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = Bit<ulong>.PartialWrite(value, firstValue, 0, 1);
                value = Bit<ulong>.PartialWrite(value, secondValue, 1, -1);

                Assert.True(Bit<ulong>.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit<ulong>.PartialRead(value, 1, -1) == secondValue);
            }

            {
                ulong firstValue = 1;
                ulong secondValue = 1543;

                // Pack (join) two values at the same time
                ulong value = secondValue << 1 | firstValue;

                ulong unpackagedFirstValue = value & 1;
                ulong unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert.True(firstValue == unpackagedFirstValue);
                Assert.True(secondValue == unpackagedSecondValue);

                // Using universal functions:
                var readMasksAndShiftFor0And1 = GetReadMaskAndShiftForUlong(0, 1);
                var readMasksAndShiftFor1AndMinus1 = GetReadMaskAndShiftForUlong(1, -1);
                var writeMasksAndShiftFor0And1 = GetWriteMasksAndShiftForUlong(0, 1);
                var writeMasksAndShiftFor1AndMinus1 = GetWriteMasksAndShiftForUlong(1, -1);

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
        private static ulong PartialWrite(ulong target, ulong source, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 64 + shift;
            }
            if (limit < 0)
            {
                limit = 64 + limit;
            }
            var sourceMask = ~(ulong.MaxValue << limit) & ulong.MaxValue;
            var targetMask = ~(sourceMask << shift);
            return target & targetMask | (source & sourceMask) << shift;
        }
        private static ulong PartialRead(ulong target, int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 64 + shift;
            }
            if (limit < 0)
            {
                limit = 64 + limit;
            }
            var sourceMask = ~(ulong.MaxValue << limit) & ulong.MaxValue;
            var targetMask = sourceMask << shift;
            return (target & targetMask) >> shift;
        }
        private static Tuple<ulong, ulong, int> GetWriteMasksAndShiftForUlong(int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 64 + shift;
            }
            if (limit < 0)
            {
                limit = 64 + limit;
            }
            var sourceMask = ~(ulong.MaxValue << limit) & ulong.MaxValue;
            var targetMask = ~(sourceMask << shift);
            return new Tuple<ulong, ulong, int>(targetMask, sourceMask, shift);
        }
        private static Tuple<ulong, int> GetReadMaskAndShiftForUlong(int shift, int limit)
        {
            if (shift < 0)
            {
                shift = 64 + shift;
            }
            if (limit < 0)
            {
                limit = 64 + limit;
            }
            var sourceMask = ~(ulong.MaxValue << limit) & ulong.MaxValue;
            var targetMask = sourceMask << shift;
            return new Tuple<ulong, int>(targetMask, shift);
        }
        private static ulong PartialWrite(ulong target, ulong targetMask, ulong source, ulong sourceMask, int shift) => target & targetMask | (source & sourceMask) << shift;
        private static ulong PartialWrite(ulong target, ulong source, Tuple<ulong, ulong, int> masksAndShift) => PartialWrite(target, masksAndShift.Item1, source, masksAndShift.Item2, masksAndShift.Item3);
        private static ulong PartialRead(ulong target, ulong targetMask, int shift) => (target & targetMask) >> shift;
        private static ulong PartialRead(ulong target, Tuple<ulong, int> masksAndShift) => PartialRead(target, masksAndShift.Item1, masksAndShift.Item2);
    }
}
