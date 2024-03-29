﻿

// ReSharper disable StaticFieldInGenericType
namespace Platform::Numbers
{
    template <typename ...> class Math;
    template <typename T> class Math<T>
    {
        public: static readonly Func<T, T> Abs = CompileAbsDelegate();

        public: static readonly Func<T, T> Negate = CompileNegateDelegate();

        private: static Func<T, T> CompileAbsDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                if (NumericType<T>.IsSigned)
                {
                    emiter.Call(typeof(System::Math).GetMethod("Abs", Types<T>.Array));
                }
                emiter.Return();
            });
        }

        private: static Func<T, T> CompileNegateDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                emiter.LoadArgument(0);
                emiter.Negate();
                emiter.Return();
            });
        }
    };
}
