namespace Platform::Numbers::Tests
{
    TEST_CLASS(MathExtensionsTests)
    {
        public: TEST_METHOD(AbsTest)
        {
            auto number = -1L;
            auto returnValue = number.Abs();
            Assert::AreEqual(1L, returnValue);
            Assert::AreEqual(1L, number);
        }

        public: TEST_METHOD(NegateTest)
        {
            auto number = 2L;
            auto returnValue = number.Negate();
            Assert::AreEqual(-2L, returnValue);
            Assert::AreEqual(-2L, number);
        }

        public: TEST_METHOD(UnsignedNegateTest)
        {
            auto number = 2UL;
            auto returnValue = number.Negate();
            Assert::AreEqual(18446744073709551614, returnValue);
            Assert::AreEqual(18446744073709551614, number);
        }
    };
}
