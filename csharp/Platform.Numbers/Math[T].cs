using System;
using System.Runtime.CompilerServices;
using Platform.Exceptions;
using Platform.Reflection;

// ReSharper disable StaticFieldInGenericType
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>.</para>
    /// <para>.</para>
    /// </summary>
    public static class Math<T>
    {
        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>>
        /// </returns>
        public static readonly Func<T, T> Abs = CompileAbsDelegate();

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        public static readonly Func<T, T> Negate = CompileNegateDelegate();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T> CompileAbsDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArgument(0);
                if (NumericType<T>.IsSigned)
                {
                    emiter.Call(typeof(System.Math).GetMethod("Abs", Types<T>.Array));
                }
                emiter.Return();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T> CompileNegateDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                emiter.LoadArgument(0);
                emiter.Negate();
                emiter.Return();
            });
        }
    }
}
