using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// Each function performs the simplest arithmetic operation on the type specified as a parameter
    /// Каждая функция выполняет простейшую арифметическую операцию над типом, указанным в качестве параметра.
    /// </summary>
    public static class Arithmetic
    {

        /// <summary>
        /// Adding the x and y arguments
        /// Сложение аргументов х и у
        /// </summary>
        /// <returns>
        /// Sum of x and y
        /// Сумма x и y
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T x, T y) => Arithmetic<T>.Add(x, y);

        /// <summary>
        /// Subtracting x from y
        /// Вычитание х из у
        /// </summary>
        /// <returns>
        /// Difference of x and y
        /// Разность x и y
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract<T>(T x, T y) => Arithmetic<T>.Subtract(x, y);

        /// <summary>
        /// Multiplication the x and y
        /// Умножение х и у
        /// </summary>
        /// <returns>
        /// <returns>
        /// Product of x and y
        /// Произведение x и y
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Multiply<T>(T x, T y) => Arithmetic<T>.Multiply(x, y);

        /// <summary>
        /// Dividing x by y
        /// Деление х на у
        /// </summary>
        /// <returns>
        /// Quoitent of x and y
        /// Частное x и y
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Divide<T>(T x, T y) => Arithmetic<T>.Divide(x, y);

        /// <summary>
        /// Increasing the parameter x by one
        /// Увеличение параметра x на единицу
        /// </summary>
        /// <returns>
        /// Increase by one x
        /// Увеличенное на единицу x
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(T x) => Arithmetic<T>.Increment(x);

        /// <summary>
        /// Increase the parameter x passed by reference by one
        /// Увеличение переданного по ссылке параметра x на единицу
        /// </summary>
        /// <returns>
        /// Increase by one x with returning the value to the original variable
        /// Увеличенное на единицу x с возвратом значения в исходную переменную
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(ref T x) => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// Decrease parameter x by one
        /// Уменьшение параметра x на единицу
        /// </summary>
        /// <returns>
        /// Reduced by one x
        /// Уменьшенное на единицу x
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(T x) => Arithmetic<T>.Decrement(x);

        /// <summary>
        /// Decreasing the parameter x passed by reference by one
        /// Уменьшение переданного по ссылке параметра x на единицу
        /// </summary>
        /// <returns>
        /// Reduced by one x with returning the value to the original variable
        /// Уменьшенное на единицу x с воз вратом значения в исходную переменную
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(ref T x) => x = Arithmetic<T>.Decrement(x);
    }
}
