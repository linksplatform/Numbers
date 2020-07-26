using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    public static class MathExtensions
    {
        /// <summary>
        /// <para> Takes a module from a number </para>
        /// <para> Берёт модуль от числа </para>
        /// </summary>
        /// <returns>
        /// <para> The absolute value of a number </para>
        /// <para> Абсолютное значение числа </para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(this ref T x) where T : struct => x = Math<T>.Abs(x);

        /// <summary>
        /// <para> Makes a number negatory </para>
        /// <para> Делает число отрицательным </para>
        /// </summary>
        /// <returns>
        /// <para> Negatory number </para>
        /// <para> Отрицательное число </para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate<T>(this ref T x) where T : struct => x = Math<T>.Negate(x);
    }
}
