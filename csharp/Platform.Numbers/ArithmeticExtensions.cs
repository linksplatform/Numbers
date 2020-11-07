using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    public static class ArithmeticExtensions
    {
      /// <summary>
      /// <para>.</para>
      /// <para>.</para>
      /// </summary>
      /// <typeparam name="T">
      /// <para>The number type.</para>
      /// <para>Тип числа.</para>
      /// </typeparam>
      /// <param name="x">
      /// <para>.</para>
      /// <para>.</para>
      /// </param>
      /// <returns>
      /// <para>.</para>
      /// <para>.</para>
      /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(this ref T x) where T : struct => x = Arithmetic<T>.Decrement(x);

        /// <summary>
        /// <para>.</para>
        /// <para>.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>.</para>
        /// <para>.</para>
        /// </param>
        /// <returns>
        /// <para>.</para>
        /// <para>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(this ref T x) where T : struct => x = Arithmetic<T>.Increment(x);
    }
}
