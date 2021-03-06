using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of arithmetic methods.</para>
    /// <para>Представляет набор арифметических методов.</para>
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// <para>Performing adding the x and y arguments.</para>
        /// <para>Выполняет сложение аргументов х и у.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers' type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
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
        /// <para>Performs subtracting y from x.</para>
        /// <para>Выполняет вычитание y из x.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers' type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>Minuend.</para>
        /// <para>Уменьшаемое.</para>
        /// </param>
        /// <param name="y">
        /// <para>Subtrahend.</para>
        /// <para>Вычитаемое.</para>
        /// </param>
        /// <returns>
        /// <para>Difference between x and y.</para>
        /// <para>Разность между x и y.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract<T>(T x, T y) => Arithmetic<T>.Subtract(x, y);

        /// <summary>
        /// <para>Performs multiplication x by y.</para>
        /// <para>Выполняет умножение х на у.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers' type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
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
        /// <para>Performs dividing x by y.</para>
        /// <para>Выполняет деление х на у.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The numbers' type.</para>
        /// <para>Тип чисел.</para>
        /// </typeparam>
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
        /// <para>Increasing the number by one.</para>
        /// <para>Увеличивает число на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number to increase.</para>
        /// <para>Число для увеличения.</para>
        /// </param>
        /// <returns>
        /// <para>Increase by one number.</para>
        /// <para>Увеличенное на единицу число.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(T x) => Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Increases the value of argument by one.</para>
        /// <para>Увеличивает значение аргумента на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The argument to increase.</para>
        /// <para>Аргумент для увеличения.</para>
        /// </param>
        /// <returns>
        /// <para>Increased argument value.</para>
        /// <para>Увеличенное значение аргумента.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Increment<T>(ref T x) => x = Arithmetic<T>.Increment(x);

        /// <summary>
        /// <para>Decreases number by one.</para>
        /// <para>Уменьшение числа на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The number to reduce.</para>
        /// <para>Число для уменьшения.</para>
        /// </param>
        /// <returns>
        /// <para>Decreased by one number.</para>
        /// <para>Уменьшенное на единицу число.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(T x) => Arithmetic<T>.Decrement(x);

        /// <summary>
        /// <para>Decreases the value of the argument by one.</para>
        /// <para>Уменьшает значение аргумента на единицу.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The number's type.</para>
        /// <para>Тип числа.</para>
        /// </typeparam>
        /// <param name="x">
        /// <para>The argument to reduce.</para>
        /// <para>Аргумент для уменьшения.</para>
        /// </param>
        /// <returns>
        /// <para>Decreased argument value.</para>
        /// <para>Уменьшеное значение аргумента.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Decrement<T>(ref T x) => x = Arithmetic<T>.Decrement(x);
    }
}
