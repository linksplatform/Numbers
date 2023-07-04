namespace Platform::Numbers::Tests
{
    // Assuming that GetLowestPosition is a valid function in your bit operations library
    TEST(BitTests, GetLowestBitPositionTest)
    {
        std::uint64_t value = 32; 
        std::int32_t expectedPosition = 5; 
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(value), expectedPosition);
    }

    // Similar tests can be written for other operations like And, Or, ShiftLeft, ShiftRight, etc. 

    // PartialRead and PartialWrite tests
    TEST(BitTests, PartialReadWriteTest)
    {
        std::uint32_t firstValue = 1;
        std::uint32_t secondValue = 1543;
        std::uint32_t value = Platform::Numbers::Bit::PartialWrite(secondValue, firstValue, 0, 1);
        std::uint32_t readValue = Platform::Numbers::Bit::PartialRead(value, 0, 1);
        ASSERT_EQ(readValue, firstValue);
    }
}
