using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Binary mathematical operations.</para>
    /// <para>Бинарные математические операции.</para>
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// <para>Performing adding the x and y arguments.</para>
        /// <para>Выполняется ложение аргументов х и у.</para>
        /// </summary>
        /// <param name="x">
        /// <para>The first term.</para>
        /// <para>Первое слагаемое.</para>
        /// </param>
        /// <param name="y">
        /// <para>The second term.</para>
        /// <para>Второе слагаемое.</para>
        /// </param>
        /// <returns>
        /// <para>Sum of x and y.</para>
        /// <para>Сумма x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T x, T y) => Arithmetic<T>.Add(x, y);

        /// <summary>
        /// <para>Permorming subtracting x from y.</para>
        /// <para>Выполняется вычитание х из у.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Minuend.</para>
        /// <para>Уменьшаемое.</para>
        /// </param>
        /// <param name="y">
        /// <para>Subtrahend.</para>
        /// <para>Вычитаемое.</para>
        /// </param>
        /// <returns>
        /// <para>Difference of x and y.</para>
        /// <para>Разность x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract<T>(T x, T y) => Arithmetic<T>.Subtract(x, y);

        /// <summary>
        /// <para>Permorming multiplication the x and y.</para>
        /// <para>Выполняется умножение х и у.</para>
        /// </summary>
        /// <param name="x">
        /// <para>First multiplier.</para>
        /// <para>Первый множитель.</para>
        /// </param>
        /// <param name="y">
        /// <para>Second multiplier.</para>
        /// <para>Второй множитель.</para>
        /// </param>
        /// <returns>
        /// <para>Product of x and y.</para>
        /// <para>Произведение x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Multiply<T>(T x, T y) => Arithmetic<T>.Multiply(x, y);

        /// <summary>
        /// <para>Permorming dividing x by y.</para>
        /// <para>Выполняется деление х на у.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Dividend.</para>
        /// <para>Делимое.</para>
        /// </param>
        /// <param name="y">
        /// <para>Divider.</para>
        /// <para>Делитель.</para>
        /// </param>
        /// <returns>
        /// <para>Quoitent of x and y.</para>
        /// <para>Частное x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Divide<T>(T x, T y) => Arithmetic<T>.Divide(x, y);

        /// <summary>
        /// <para>Increases the number x by one.</para>
        /// <para>Увеличение числа x на единицу.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Increase the number required.</para>
        /// <para>Число необходимое увеличить.</para>
        /// </param>
        /// <returns>
        /// <para>Increase by one number x.</para>
        /// <para>Увеличенное на единицу число x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(T x) => Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Increases the value of argument x by one.</para>
        /// <para>Увеличение значения аргумента x на единицу.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Increase the argument required.</para>
        /// <para>Аргумент требуемый увеличить.</para>
        /// </param>
        /// <returns>
        /// <para>Increased argument x value.</para>
        /// <para>Увеличенное значение аргумента x</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(ref T x) => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Decrease number x by one.</para>
        /// <para>Уменьшение числа x на единицу.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Require the number reduce.</para>
        /// <para>Число необходимое уменьшить.</para>
        /// </param>
        /// <returns>
        /// <para>Decreased by one number x.</para>
        /// <para>Уменьшенное на единицу число x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(T x) => Arithmetic<T>.Decrement(x);

        /// <summary>
        /// <para>Decreases the value of the argument x by one.</para>
        /// <para>Уменьшение значения аргумента x на единицу.</para>
        /// </summary>
        /// <param name="x">
        /// <para>Require the argument reduce.</para>
        /// <para>Аргумент требуемый уменьшить.</para>
        /// </param>
        /// <returns>
        /// <para>Decreased argument x value.</para>
        /// <para>Уменьшеное значение аргумента x.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(ref T x) => x = Arithmetic<T>.Decrement(x);
    }
}
