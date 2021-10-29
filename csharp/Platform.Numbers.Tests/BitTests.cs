using System;
using Platform.Reflection;
using Xunit;

namespace Platform.Numbers.Tests
{
    /// <summary>
    /// <para>
    /// Represents the bit tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class BitTests
    {
        /// <summary>
        /// <para>
        /// Tests that get lowest bit position test.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="value">
        /// <para>The value.</para>
        /// <para></para>
        /// </param>
        /// <param name="expectedPosition">
        /// <para>The expected position.</para>
        /// <para></para>
        /// </param>
        [Theory]
        [InlineData(00, -1)] // 0000 0000 (none, -1)
        [InlineData(01, 00)] // 0000 0001 (first, 0)
        [InlineData(08, 03)] // 0000 1000 (forth, 3)
        [InlineData(88, 03)] // 0101 1000 (forth, 3)
        public static void GetLowestBitPositionTest(ulong value, int expectedPosition)
        {
            Assert.True(Bit.GetLowestPosition(value) == expectedPosition);
        }

        /// <summary>
        /// <para>
        /// Tests that byte bitwise operations test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ByteBitwiseOperationsTest()
        {
            Assert.True(Bit<byte>.Not(2) == unchecked((byte)~2));
            Assert.True(Bit<byte>.Or(1, 2) == (1 | 2));
            Assert.True(Bit<byte>.And(1, 2) == (1 & 2));
            Assert.True(Bit<byte>.ShiftLeft(1, 2) == (1 << 2));
            Assert.True(Bit<byte>.ShiftRight(1, 2) == (1 >> 2));
            Assert.Equal(NumericType<byte>.MaxValue >> 1, Bit<byte>.ShiftRight(NumericType<byte>.MaxValue, 1));
        }

        /// <summary>
        /// <para>
        /// Tests that u int 16 bitwise operations test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void UInt16BitwiseOperationsTest()
        {
            Assert.True(Bit<ushort>.Not(2) == unchecked((ushort)~2));
            Assert.True(Bit<ushort>.Or(1, 2) == (1 | 2));
            Assert.True(Bit<ushort>.And(1, 2) == (1 & 2));
            Assert.True(Bit<ushort>.ShiftLeft(1, 2) == (1 << 2));
            Assert.True(Bit<ushort>.ShiftRight(1, 2) == (1 >> 2));
            Assert.Equal(NumericType<ushort>.MaxValue >> 1, Bit<ushort>.ShiftRight(NumericType<ushort>.MaxValue, 1));
        }

        /// <summary>
        /// <para>
        /// Tests that u int 32 bitwise operations test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void UInt32BitwiseOperationsTest()
        {
            Assert.True(Bit<uint>.Not(2) == unchecked((uint)~2));
            Assert.True(Bit<uint>.Or(1, 2) == (1 | 2));
            Assert.True(Bit<uint>.And(1, 2) == (1 & 2));
            Assert.True(Bit<uint>.ShiftLeft(1, 2) == (1 << 2));
            Assert.True(Bit<uint>.ShiftRight(1, 2) == (1 >> 2));
            Assert.Equal(NumericType<uint>.MaxValue >> 1, Bit<uint>.ShiftRight(NumericType<uint>.MaxValue, 1));
        }

        /// <summary>
        /// <para>
        /// Tests that u int 64 bitwise operations test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void UInt64BitwiseOperationsTest()
        {
            Assert.True(Bit<ulong>.Not(2) == unchecked((ulong)~2));
            Assert.True(Bit<ulong>.Or(1, 2) == (1 | 2));
            Assert.True(Bit<ulong>.And(1, 2) == (1 & 2));
            Assert.True(Bit<ulong>.ShiftLeft(1, 2) == (1 << 2));
            Assert.True(Bit<ulong>.ShiftRight(1, 2) == (1 >> 2));
            Assert.Equal(NumericType<ulong>.MaxValue >> 1, Bit<ulong>.ShiftRight(NumericType<ulong>.MaxValue, 1));
        }

        /// <summary>
        /// <para>
        /// Tests that partial read write test.
        /// </para>
        /// <para></para>
        /// </summary>
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
                Assert.True(Bit.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit.PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = Bit.PartialWrite(value, firstValue, 0, 1);
                value = Bit.PartialWrite(value, secondValue, 1, -1);

                Assert.True(Bit.PartialRead(value, 0, 1) == firstValue);
                Assert.True(Bit.PartialRead(value, 1, -1) == secondValue);
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
        /// <summary>
        /// <para>
        /// Partials the write using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="source">
        /// <para>The source.</para>
        /// <para></para>
        /// </param>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <param name="limit">
        /// <para>The limit.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
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

        /// <summary>
        /// <para>
        /// Partials the read using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <param name="limit">
        /// <para>The limit.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
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

        /// <summary>
        /// <para>
        /// Gets the write masks and shift using the specified shift.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <param name="limit">
        /// <para>The limit.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>A tuple of uint and uint and int</para>
        /// <para></para>
        /// </returns>
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

        /// <summary>
        /// <para>
        /// Gets the read mask and shift using the specified shift.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <param name="limit">
        /// <para>The limit.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>A tuple of uint and int</para>
        /// <para></para>
        /// </returns>
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

        /// <summary>
        /// <para>
        /// Partials the write using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="targetMask">
        /// <para>The target mask.</para>
        /// <para></para>
        /// </param>
        /// <param name="source">
        /// <para>The source.</para>
        /// <para></para>
        /// </param>
        /// <param name="sourceMask">
        /// <para>The source mask.</para>
        /// <para></para>
        /// </param>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
        private static uint PartialWrite(uint target, uint targetMask, uint source, uint sourceMask, int shift) => target & targetMask | (source & sourceMask) << shift;

        /// <summary>
        /// <para>
        /// Partials the write using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="source">
        /// <para>The source.</para>
        /// <para></para>
        /// </param>
        /// <param name="masksAndShift">
        /// <para>The masks and shift.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
        private static uint PartialWrite(uint target, uint source, Tuple<uint, uint, int> masksAndShift) => PartialWrite(target, masksAndShift.Item1, source, masksAndShift.Item2, masksAndShift.Item3);

        /// <summary>
        /// <para>
        /// Partials the read using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="targetMask">
        /// <para>The target mask.</para>
        /// <para></para>
        /// </param>
        /// <param name="shift">
        /// <para>The shift.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
        private static uint PartialRead(uint target, uint targetMask, int shift) => (target & targetMask) >> shift;

        /// <summary>
        /// <para>
        /// Partials the read using the specified target.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="target">
        /// <para>The target.</para>
        /// <para></para>
        /// </param>
        /// <param name="masksAndShift">
        /// <para>The masks and shift.</para>
        /// <para></para>
        /// </param>
        /// <returns>
        /// <para>The uint</para>
        /// <para></para>
        /// </returns>
        private static uint PartialRead(uint target, Tuple<uint, int> masksAndShift) => PartialRead(target, masksAndShift.Item1, masksAndShift.Item2);

        /// <summary>
        /// <para>
        /// Tests that bug with loading constant of 8 test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void BugWithLoadingConstantOf8Test()
        {
            Bit<byte>.PartialWrite(0, 1, 5, -5);
        }
    }
}
