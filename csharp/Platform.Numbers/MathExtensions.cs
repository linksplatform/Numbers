using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Provides a set of extension methods that perform mathematical operations on arbitrary object types.</para>
    /// <para>Предоставляет набор методов расширения выполняющих математические операции для объектов произвольного типа.</para>
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// <para>Takes a module from a number.</para>
        /// <para>Берёт модуль от числа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number from which to take the absolute value.</para>
        /// <para>Число от которого необходимо взять абсолютное значение.</para>
        /// </param>
        /// <returns>
        /// <para>The absolute value of a number.</para>
        /// <para>Абсолютное значение числа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(this ref T x) where T : struct => x = Math<T>.Abs(x);

        /// <summary>
        /// <para>Makes a number negative.</para>
        /// <para>Делает число отрицательным.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number to be made negative.</para>
        /// <para>Число которое нужно сделать отрицательным.</para>
        /// </param>
        /// <returns>
        /// <para>Negative number.</para>
        /// <para>Отрицательное число.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate<T>(this ref T x) where T : struct => x = Math<T>.Negate(x);
    }
}
