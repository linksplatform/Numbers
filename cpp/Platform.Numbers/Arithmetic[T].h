

// ReSharper disable StaticFieldInGenericType
namespace Platform::Numbers
{
    template <typename ...> class Arithmetic;
    template <typename T> class Arithmetic<T>
    {
        public: static readonly Func<T, T, T> Add = CompileAddDelegate();

        public: static readonly Func<T, T, T> Subtract = CompileSubtractDelegate();

        public: static readonly Func<T, T, T> Multiply = CompileMultiplyDelegate();

        public: static readonly Func<T, T, T> Divide = CompileDivideDelegate();

        public: static readonly Func<T, T> Increment = CompileIncrementDelegate();

        public: static readonly Func<T, T> Decrement = CompileDecrementDelegate();

        private: static Func<T, T, T> CompileAddDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Add();
                emiter.Return();
            });
        }

        private: static Func<T, T, T> CompileSubtractDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Subtract();
                emiter.Return();
            });
        }

        private: static Func<T, T, T> CompileMultiplyDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Emit(OpCodes.Mul);
                emiter.Return();
            });
        }

        private: static Func<T, T, T> CompileDivideDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                if(NumericType<T>.IsSigned)
                {
                    emiter.Emit(OpCodes.Div);
                }
                else
                {
                    emiter.Emit(OpCodes.Div_Un);
                }
                emiter.Return();
            });
        }

        private: static Func<T, T> CompileIncrementDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Increment<T>();
                emiter.Return();
            });
        }

        private: static Func<T, T> CompileDecrementDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Decrement<T>();
                emiter.Return();
            });
        }
    };
}
