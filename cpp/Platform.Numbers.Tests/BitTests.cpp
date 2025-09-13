#include "gtest/gtest.h"
#include "Platform.Numbers.h"

namespace Platform::Numbers::Tests
{
    // Test GetLowestPosition function with various values based on C# tests
    TEST(BitTests, GetLowestBitPositionTest)
    {
        // Test cases from C# implementation
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(0), -1);   // 0000 0000 (none, -1)
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(1), 0);    // 0000 0001 (first, 0)
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(8), 3);    // 0000 1000 (forth, 3)
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(88), 3);   // 0101 1000 (forth, 3)
        ASSERT_EQ(Platform::Numbers::Bit::GetLowestPosition(32), 5);   // Previous test case
    }

    // Test Count function
    TEST(BitTests, CountTest)
    {
        ASSERT_EQ(Platform::Numbers::Bit::Count(0), 0);
        ASSERT_EQ(Platform::Numbers::Bit::Count(1), 1);    // 0001
        ASSERT_EQ(Platform::Numbers::Bit::Count(3), 2);    // 0011
        ASSERT_EQ(Platform::Numbers::Bit::Count(7), 3);    // 0111
        ASSERT_EQ(Platform::Numbers::Bit::Count(15), 4);   // 1111
    }

    // PartialRead and PartialWrite tests based on C# implementation
    TEST(BitTests, PartialReadWriteTest)
    {
        std::uint32_t firstValue = 1;
        std::uint32_t secondValue = 1543;
        
        // Pack (join) two values at the same time
        std::uint32_t value = secondValue << 1 | firstValue;
        
        std::uint32_t unpackagedFirstValue = value & 1;
        std::uint32_t unpackagedSecondValue = (value & 0xFFFFFFFE) >> 1;
        
        ASSERT_EQ(firstValue, unpackagedFirstValue);
        ASSERT_EQ(secondValue, unpackagedSecondValue);
        
        // Using universal functions:
        ASSERT_EQ(Platform::Numbers::Bit::PartialRead(value, 0, 1), firstValue);
        ASSERT_EQ(Platform::Numbers::Bit::PartialRead(value, 1, -1), secondValue);
        
        firstValue = 0;
        secondValue = 6892;
        
        value = Platform::Numbers::Bit::PartialWrite(value, firstValue, 0, 1);
        value = Platform::Numbers::Bit::PartialWrite(value, secondValue, 1, -1);
        
        ASSERT_EQ(Platform::Numbers::Bit::PartialRead(value, 0, 1), firstValue);
        ASSERT_EQ(Platform::Numbers::Bit::PartialRead(value, 1, -1), secondValue);
    }

    // Test Math functions
    TEST(MathTests, FactorialTest)
    {
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(0), 1);
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(1), 1);
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(2), 2);
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(3), 6);
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(4), 24);
        ASSERT_EQ(Platform::Numbers::Math::Factorial<std::uint64_t>(5), 120);
        
        // Test out of range
        ASSERT_THROW(Platform::Numbers::Math::Factorial<std::uint64_t>(21), std::out_of_range);
    }

    TEST(MathTests, CatalanTest)
    {
        ASSERT_EQ(Platform::Numbers::Math::Catalan<std::uint64_t>(0), 1);
        ASSERT_EQ(Platform::Numbers::Math::Catalan<std::uint64_t>(1), 1);
        ASSERT_EQ(Platform::Numbers::Math::Catalan<std::uint64_t>(2), 2);
        ASSERT_EQ(Platform::Numbers::Math::Catalan<std::uint64_t>(3), 5);
        ASSERT_EQ(Platform::Numbers::Math::Catalan<std::uint64_t>(4), 14);
        
        // Test out of range
        ASSERT_THROW(Platform::Numbers::Math::Catalan<std::uint64_t>(37), std::out_of_range);
    }

    TEST(MathTests, IsPowerOfTwoTest)
    {
        ASSERT_FALSE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(0));
        ASSERT_TRUE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(1));
        ASSERT_TRUE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(2));
        ASSERT_FALSE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(3));
        ASSERT_TRUE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(4));
        ASSERT_FALSE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(5));
        ASSERT_TRUE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(8));
        ASSERT_TRUE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(16));
        ASSERT_FALSE(Platform::Numbers::Math::IsPowerOfTwo<std::uint64_t>(17));
    }
}
