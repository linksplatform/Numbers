using System;
using Platform.Exceptions;
using Platform.Reflection;
using Platform.Reflection.Sigil;

// ReSharper disable StaticFieldInGenericType

namespace Platform.Numbers
{
    public static class ArithmeticHelpers<T>
    {
        public static readonly Func<T, T, T> Add;
        public static readonly Func<T, T, T> And;
        public static readonly Func<T, T> Increment;
        public static readonly Func<T, T, T> Subtract;
        public static readonly Func<T, T> Decrement;

        static ArithmeticHelpers()
        {
            Add = DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Add();
                emiter.Return();
            });
            And = DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.And();
                emiter.Return();
            });
            Increment = DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Increment(typeof(T));
                emiter.Return();
            });
            Subtract = DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Subtract();
                emiter.Return();
            });
            Decrement = DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Decrement(typeof(T));
                emiter.Return();
            });
        }
    }
}
