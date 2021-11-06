namespace Platform::Numbers::Tests
{
    TEST_CLASS(ArithmeticTests)
    {
        public: TEST_METHOD(CompiledOperationsTest)
        {
            Assert::AreEqual(3, 1 + 2);
            Assert::AreEqual(1, Arithmetic.Subtract(2, 1));
            Assert::AreEqual(8, Arithmetic.Multiply(2, 4));
            Assert::AreEqual(4, Arithmetic.Divide(8, 2));
            Assert::AreEqual(2, 1 + 1);
            Assert::AreEqual(1UL, 2UL - 1);
            Assert::ExpectException<NotSupportedException>([&]()-> auto { return Arithmetic<std::string>.Subtract("1", "2"); });
        }
    };
}
