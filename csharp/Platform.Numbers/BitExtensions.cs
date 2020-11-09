using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of bitwise operation.</para>
    /// <para>Представляет набор битовых операций.</para>
    /// </summary>
    public static class BitwiseExtensions
    {
        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Not<T>(this ref T target) where T : struct => target = Bit.Not(target);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <param name="source">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialWrite<T>(this ref T target, T source, int shift, int limit) where T : struct => target = Bit<T>.PartialWrite(target, source, shift, limit);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="target">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PartialRead<T>(this T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
