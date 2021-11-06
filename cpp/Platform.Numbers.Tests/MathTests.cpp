namespace Platform::Numbers::Tests
{
    TEST_CLASS(MathTests)
    {
        public: TEST_METHOD(CompiledOperationsTest)
        {
            Assert::IsTrue(Math.Abs(Arithmetic<double>.Subtract(3D, 2D) - 1D) < 0.01);
        }
    };
}
