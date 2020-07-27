using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Each function performs the simplest arithmetic operation on the type specified as a parameter.</para>
    /// <para>Каждая функция выполняет простейшую арифметическую операцию над типом, указанным в качестве параметра.</para>
    /// </summary>
    public static class Arithmetic
    {

        /// <summary>
        /// <para>Adding the x and y arguments.</para>
        /// <para>Сложение аргументов х и у.</para>
        /// </summary>
        /// <returns>
        /// <para>Sum of x and y.</para>
        /// <para>Сумма x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T x, T y) => Arithmetic<T>.Add(x, y);

        /// <summary>
        /// <para>Subtracting x from y.</para>
        /// <para>Вычитание х из у.</para>
        /// </summary>
        /// <returns>
        /// <para>Difference of x and y.</para>
        /// <para>Разность x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract<T>(T x, T y) => Arithmetic<T>.Subtract(x, y);

        /// <summary>
        /// <para>Multiplication the x and y.</para>
        /// <para>Умножение х и у.</para>
        /// </summary>
        /// <returns>
        /// <returns>
        /// <para>Product of x and y.</para>
        /// <para>Произведение x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Multiply<T>(T x, T y) => Arithmetic<T>.Multiply(x, y);

        /// <summary>
        /// <para>Dividing x by y.</para>
        /// <para>Деление х на у.</para>
        /// </summary>
        /// <returns>
        /// <para>Quoitent of x and y.</para>
        /// <para>Частное x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Divide<T>(T x, T y) => Arithmetic<T>.Divide(x, y);

        /// <summary>
        /// <para>Increasing the parameter x by one.</para>
        /// <para>Увеличение параметра x на единицу.</para>
        /// </summary>
        /// <returns>
        /// <para>Increase by one x.</para>
        /// <para>Увеличенное на единицу x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(T x) => Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Increase the parameter x passed by reference by one.</para>
        /// <para>Увеличение переданного по ссылке параметра x на единицу.</para>
        /// </summary>
        /// <returns>
        /// <para>Increase by one x with returning the value to the original variable.</para>
        /// <para>Увеличенное на единицу x с возвратом значения в исходную переменную.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(ref T x) => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Decrease parameter x by one.</para>
        /// <para>Уменьшение параметра x на единицу.</para>
        /// </summary>
        /// <returns>
        /// <para>Reduced by one x.</para>
        /// <para>Уменьшенное на единицу x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(T x) => Arithmetic<T>.Decrement(x);

        /// <summary>
        /// <para>Decreasing the parameter x passed by reference by one.</para>
        /// <para>Уменьшение переданного по ссылке параметра x на единицу.</para>
        /// </summary>
        /// <returns>
        /// <para>Reduced by one x with returning the value to the original variable.</para>
        /// <para>Уменьшенное на единицу x с воз вратом значения в исходную переменную.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(ref T x) => x = Arithmetic<T>.Decrement(x);
    }
}
