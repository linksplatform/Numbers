using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Provides a set of extension methods that perform mathematical operations on arbitrary object types.</para>
    /// <para>Предоставляет набор методов расширения выполняющих математические операции для объектов произвольного типа.</para>
    /// </summary>
    public static class ArithmeticExtensions
    {
        /// <summary>
        /// <para>Increments the variable passed as an argument by one.</para>
        /// <para>Увеличивает переданную в качестве аргумента переменную на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>Reference to the variable being incremented.</para>
        /// <para>Ссылка на увеличиваемую переменную.</para>
        /// </param>
        /// <returns>
        /// <para>Increased the value of the argument by one.</para>
        /// <para>Увеличенное значение аргумента на единицу.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(this ref T x) where T : struct => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Reduces the variable passed as an argument by one.</para>
        /// <para>Уменьшает переданную в качестве аргумента переменную на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>Reference to a reduced variable.</para>
        /// <para>Ссылка на увеличиваемую переменную.</para>
        /// </param>
        /// <returns>
        /// <para>Reduces the value of the argument by one.</para>
        /// <para>Уменьшеное значение аргумента на единицу.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(this ref T x) where T : struct => x = Arithmetic<T>.Decrement(x);
    }
}
