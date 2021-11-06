namespace Platform::Numbers::Tests
{
    TEST_CLASS(ArithmeticExtensionsTests)
    {
        public: TEST_METHOD(IncrementTest)
        {
            auto number = 0UL;
            auto returnValue = number.Increment();
            Assert::AreEqual(1UL, returnValue);
            Assert::AreEqual(1UL, number);
        }

        public: TEST_METHOD(DecrementTest)
        {
            auto number = 1UL;
            auto returnValue = number.Decrement();
            Assert::AreEqual(0UL, returnValue);
            Assert::AreEqual(0UL, number);
        }
    };
}
