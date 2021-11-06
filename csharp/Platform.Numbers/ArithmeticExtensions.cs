using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of extension methods that perform arithmetic operations on arbitrary object types.</para>
    /// <para>Представляет набор методов расширения выполняющих арифметические операции для объектов произвольного типа.</para>
    /// </summary>
    public static class ArithmeticExtensions
    {
        /// <summary>
        /// <para>Increments the variable passed as an argument by one.</para>
        /// <para>Увеличивает переданную в качестве аргумента переменную на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The reference to the incremented variable.</para>
        /// <para>Ссылка на увеличиваемую переменную.</para>
        /// </param>
        /// <returns>
        /// <para>The value of the argument incremented by one.</para>
        /// <para>Увеличенное значение аргумента на единицу.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(this ref T x) where T : struct => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Decrements the variable passed as an argument by one.</para>
        /// <para>Уменьшает переданную в качестве аргумента переменную на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The reference to the decremented variable.</para>
        /// <para>Ссылка на уменьшаемую переменную.</para>
        /// </param>
        /// <returns>
        /// <para>The value of the argument decremented by one.</para>
        /// <para>Уменьшеное значение аргумента на единицу.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(this ref T x) where T : struct => x = Arithmetic<T>.Decrement(x);
    }
}
