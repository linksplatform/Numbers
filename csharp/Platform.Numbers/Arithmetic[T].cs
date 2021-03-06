using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Platform.Exceptions;
using Platform.Reflection;

// ReSharper disable StaticFieldInGenericType
namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents compiled arithmetic operations delegates.</para>
    /// <para>Представляет набор скомпилированных делегатов арифметических операций.</para>
    /// </summary>
    public static class Arithmetic<T>
    {
        /// <summary>
        /// <para>A read-only field that represents a addition function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции сложения.</para>
        /// </summary>
        public static readonly Func<T, T, T> Add = CompileAddDelegate();

        /// <summary>
        /// <para>A read-only field that represents a subtraction function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции вычитания.</para>
        /// </summary>
        public static readonly Func<T, T, T> Subtract = CompileSubtractDelegate();

        /// <summary>
        /// <para>A read-only field that represents a multiplication function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции умножения.</para>
        /// </summary>
        public static readonly Func<T, T, T> Multiply = CompileMultiplyDelegate();

        /// <summary>
        /// <para>A read-only field that represents a division function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции деления.</para>
        /// </summary>
        public static readonly Func<T, T, T> Divide = CompileDivideDelegate();

        /// <summary>
        /// <para>A read-only field that represents a increment function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции инкремента.</para>
        /// </summary>
        public static readonly Func<T, T> Increment = CompileIncrementDelegate();

        /// <summary>
        /// <para>A read-only field that represents a decrement function delegate.</para>
        /// <para>Поле только для чтения, представляющее делегат функции декремента.</para>
        /// </summary>
        public static readonly Func<T, T> Decrement = CompileDecrementDelegate();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> CompileAddDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Add();
                emiter.Return();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> CompileSubtractDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Subtract();
                emiter.Return();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> CompileMultiplyDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Emit(OpCodes.Mul);
                emiter.Return();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> CompileDivideDelegate()
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T> CompileIncrementDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Increment<T>();
                emiter.Return();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T> CompileDecrementDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                emiter.Decrement<T>();
                emiter.Return();
            });
        }
    }
}
