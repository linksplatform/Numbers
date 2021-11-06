namespace Platform::Numbers::Tests
{
    TEST_CLASS(BitTests)
    {
        public: static void GetLowestBitPositionTest(std::uint64_t value, std::int32_t expectedPosition)
        {
            Assert::IsTrue(Bit.GetLowestPosition(value) == expectedPosition);
        }

        public: TEST_METHOD(ByteBitwiseOperationsTest)
        {
            Assert::IsTrue(Bit<std::uint8_t>.Not(2) == unchecked((std::uint8_t)~2));
            Assert::IsTrue(Bit<std::uint8_t>.Or(1, 2) == (1 | 2));
            Assert::IsTrue(Bit<std::uint8_t>.And(1, 2) == (1 & 2));
            Assert::IsTrue(Bit<std::uint8_t>.ShiftLeft(1, 2) == (1 << 2));
            Assert::IsTrue(Bit<std::uint8_t>.ShiftRight(1, 2) == (1 >> 2));
            Assert::AreEqual(NumericType<std::uint8_t>.MaxValue >> 1, Bit<std::uint8_t>.ShiftRight(NumericType<std::uint8_t>.MaxValue, 1));
        }

        public: TEST_METHOD(UInt16BitwiseOperationsTest)
        {
            Assert::IsTrue(Bit<std::uint16_t>.Not(2) == unchecked((std::uint16_t)~2));
            Assert::IsTrue(Bit<std::uint16_t>.Or(1, 2) == (1 | 2));
            Assert::IsTrue(Bit<std::uint16_t>.And(1, 2) == (1 & 2));
            Assert::IsTrue(Bit<std::uint16_t>.ShiftLeft(1, 2) == (1 << 2));
            Assert::IsTrue(Bit<std::uint16_t>.ShiftRight(1, 2) == (1 >> 2));
            Assert::AreEqual(NumericType<std::uint16_t>.MaxValue >> 1, Bit<std::uint16_t>.ShiftRight(NumericType<std::uint16_t>.MaxValue, 1));
        }

        public: TEST_METHOD(UInt32BitwiseOperationsTest)
        {
            Assert::IsTrue(Bit<std::uint32_t>.Not(2) == unchecked((std::uint32_t)~2));
            Assert::IsTrue(Bit<std::uint32_t>.Or(1, 2) == (1 | 2));
            Assert::IsTrue(Bit<std::uint32_t>.And(1, 2) == (1 & 2));
            Assert::IsTrue(Bit<std::uint32_t>.ShiftLeft(1, 2) == (1 << 2));
            Assert::IsTrue(Bit<std::uint32_t>.ShiftRight(1, 2) == (1 >> 2));
            Assert::AreEqual(NumericType<std::uint32_t>.MaxValue >> 1, Bit<std::uint32_t>.ShiftRight(NumericType<std::uint32_t>.MaxValue, 1));
        }

        public: TEST_METHOD(UInt64BitwiseOperationsTest)
        {
            Assert::IsTrue(Bit<std::uint64_t>.Not(2) == unchecked((std::uint64_t)~2));
            Assert::IsTrue(Bit<std::uint64_t>.Or(1, 2) == (1 | 2));
            Assert::IsTrue(Bit<std::uint64_t>.And(1, 2) == (1 & 2));
            Assert::IsTrue(Bit<std::uint64_t>.ShiftLeft(1, 2) == (1 << 2));
            Assert::IsTrue(Bit<std::uint64_t>.ShiftRight(1, 2) == (1 >> 2));
            Assert::AreEqual(NumericType<std::uint64_t>.MaxValue >> 1, Bit<std::uint64_t>.ShiftRight(NumericType<std::uint64_t>.MaxValue, 1));
        }

        public: TEST_METHOD(PartialReadWriteTest)
        {
            {
                std::uint32_t firstValue = 1;
                std::uint32_t secondValue = 1543;

                std::uint32_t value = secondValue << 1 | firstValue;

                std::uint32_t unpackagedFirstValue = value & 1;
                std::uint32_t unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert::IsTrue(firstValue == unpackagedFirstValue);
                Assert::IsTrue(secondValue == unpackagedSecondValue);

                Assert::IsTrue(PartialRead(value, 0, 1) == firstValue);
                Assert::IsTrue(PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = PartialWrite(value, firstValue, 0, 1);
                value = PartialWrite(value, secondValue, 1, -1);

                Assert::IsTrue(PartialRead(value, 0, 1) == firstValue);
                Assert::IsTrue(PartialRead(value, 1, -1) == secondValue);
            }

            {
                std::uint32_t firstValue = 1;
                std::uint32_t secondValue = 1543;

                std::uint32_t value = secondValue << 1 | firstValue;

                std::uint32_t unpackagedFirstValue = value & 1;
                std::uint32_t unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert::IsTrue(firstValue == unpackagedFirstValue);
                Assert::IsTrue(secondValue == unpackagedSecondValue);

                Assert::IsTrue(Bit.PartialRead(value, 0, 1) == firstValue);
                Assert::IsTrue(Bit.PartialRead(value, 1, -1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = Bit.PartialWrite(value, firstValue, 0, 1);
                value = Bit.PartialWrite(value, secondValue, 1, -1);

                Assert::IsTrue(Bit.PartialRead(value, 0, 1) == firstValue);
                Assert::IsTrue(Bit.PartialRead(value, 1, -1) == secondValue);
            }

            {
                std::uint32_t firstValue = 1;
                std::uint32_t secondValue = 1543;

                std::uint32_t value = secondValue << 1 | firstValue;

                std::uint32_t unpackagedFirstValue = value & 1;
                std::uint32_t unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;

                Assert::IsTrue(firstValue == unpackagedFirstValue);
                Assert::IsTrue(secondValue == unpackagedSecondValue);

                auto readMasksAndShiftFor0And1 = GetReadMaskAndShift(0, 1);
                auto readMasksAndShiftFor1AndMinus1 = GetReadMaskAndShift(1, -1);
                auto writeMasksAndShiftFor0And1 = GetWriteMasksAndShift(0, 1);
                auto writeMasksAndShiftFor1AndMinus1 = GetWriteMasksAndShift(1, -1);

                Assert::IsTrue(PartialRead(value, readMasksAndShiftFor0And1) == firstValue);
                Assert::IsTrue(PartialRead(value, readMasksAndShiftFor1AndMinus1) == secondValue);

                firstValue = 0;
                secondValue = 6892;

                value = PartialWrite(value, firstValue, writeMasksAndShiftFor0And1);
                value = PartialWrite(value, secondValue, writeMasksAndShiftFor1AndMinus1);

                Assert::IsTrue(PartialRead(value, readMasksAndShiftFor0And1) == firstValue);
                Assert::IsTrue(PartialRead(value, readMasksAndShiftFor1AndMinus1) == secondValue);
            }
        }

        private: static std::uint32_t PartialWrite(std::uint32_t target, std::uint32_t source, std::int32_t shift, std::int32_t limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            auto sourceMask = ~(std::numeric_limits<std::uint32_t>::max() << limit) & std::numeric_limits<std::uint32_t>::max();
            auto targetMask = ~(sourceMask << shift);
            return target & targetMask | (source & sourceMask) << shift;
        }

        private: static std::uint32_t PartialRead(std::uint32_t target, std::int32_t shift, std::int32_t limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            auto sourceMask = ~(std::numeric_limits<std::uint32_t>::max() << limit) & std::numeric_limits<std::uint32_t>::max();
            auto targetMask = sourceMask << shift;
            return {target & targetMask} >> shift;
        }

        private: static Tuple<std::uint32_t, std::uint32_t, std::int32_t> GetWriteMasksAndShift(std::int32_t shift, std::int32_t limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            auto sourceMask = ~(std::numeric_limits<std::uint32_t>::max() << limit) & std::numeric_limits<std::uint32_t>::max();
            auto targetMask = ~(sourceMask << shift);
            return Tuple<std::uint32_t, std::uint32_t, std::int32_t>(targetMask, sourceMask, shift);
        }

        private: static Tuple<std::uint32_t, std::int32_t> GetReadMaskAndShift(std::int32_t shift, std::int32_t limit)
        {
            if (shift < 0)
            {
                shift = 32 + shift;
            }
            if (limit < 0)
            {
                limit = 32 + limit;
            }
            auto sourceMask = ~(std::numeric_limits<std::uint32_t>::max() << limit) & std::numeric_limits<std::uint32_t>::max();
            auto targetMask = sourceMask << shift;
            return Tuple<std::uint32_t, std::int32_t>(targetMask, shift);
        }

        private: static std::uint32_t PartialWrite(std::uint32_t target, std::uint32_t targetMask, std::uint32_t source, std::uint32_t sourceMask, std::int32_t shift) { return target & targetMask | (source & sourceMask) << shift; }

        private: static std::uint32_t PartialWrite(std::uint32_t target, std::uint32_t source, Tuple<std::uint32_t, std::uint32_t, std::int32_t> masksAndShift) { return PartialWrite(target, masksAndShift.Item1, source, masksAndShift.Item2, masksAndShift.Item3); }

        private: static std::uint32_t PartialRead(std::uint32_t target, std::uint32_t targetMask, std::int32_t shift) { return {target & targetMask} >> shift; }

        private: static std::uint32_t PartialRead(std::uint32_t target, Tuple<std::uint32_t, std::int32_t> masksAndShift) { return PartialRead(target, masksAndShift.Item1, masksAndShift.Item2); }

        public: TEST_METHOD(BugWithLoadingConstantOf8Test)
        {
            Bit<std::uint8_t>.PartialWrite(0, 1, 5, -5);
        }
    };
}
