using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Implements unary mathematical operations.</para>
    /// <para>Реализует унарные математические операции.</para>
    /// </summary>
    public static class ArithmeticExtensions
    {
        /// <summary>
        /// <para>Increasing the parameter by one.</para>
        /// <para>Увеличение параметра на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The parameter to increase.</para>
        /// <para>Параметр для увеличения.</para>
        /// </param>
        /// <returns>
        /// <para>Increased the value of the parameter per unit.</para>
        /// <para>Увеличенное значение параметра на единицу.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(this ref T x) where T : struct => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Decreases parameter by one.</para>
        /// <para>Уменьшение параметра на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The parameter to decrease.</para>
        /// <para>Параметр для уменьшения.</para>
        /// </param>
        /// <returns>
        /// <para>Decreased the value of the parameter per unit.</para>
        /// <para>Уменьшенное на единицу значение параметра.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(this ref T x) where T : struct => x = Arithmetic<T>.Decrement(x);
    }
}
