using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of math methods.</para>
    /// <para>Представляет набор математических методов.</para>
    /// </summary>
    /// <remarks>Resizable array (FileMappedMemory) for values cache may be used. or cached oeis.org</remarks>
    public static class Math
    {
        private static readonly ulong[] _factorials =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800,
            479001600, 6227020800, 87178291200, 1307674368000, 20922789888000,
            355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000
        };
        private static readonly ulong[] _catalans =
        {
            1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012,
            742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190,
            6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452,
            18367353072152, 69533550916004, 263747951750360, 1002242216651368, 3814986502092304,
            14544636039226909, 55534064877048198, 212336130412243110, 812944042149730764, 3116285494907301262, 11959798385860453492
        };

        /// <summary>
        /// <para>Represents the limit for calculating the catanal number, supported by the <see cref="ulong"/> type.</para>
        /// <para>Представляет предел расчёта катаналового числа, поддерживаемый <see cref="ulong"/> типом.</para>
        /// </summary>
        public static readonly ulong MaximumFactorialNumber = 20;

        /// <summary>
        /// <para>Represents the limit for calculating the factorial number, supported by the <see cref="ulong"/> type.</para>
        /// <para>Представляет предел расчёта факториала числа, поддерживаемый <see cref="ulong"/> типом.</para>
        /// </summary>
        public static readonly ulong MaximumCatalanIndex = 36;

        /// <summary>
        /// <para>Returns the product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Возвращает произведение всех положительных чисел меньше или равных указанному в качестве аргумента числу.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The maximum positive number that will participate in factorial's product.</para>
        /// <para>Максимальное положительное число, которое будет участвовать в произведении факториала.</para>
        /// </param>
        /// <returns>
        /// <para>The product of all positive integers less than or equal to the number specified as an argument.</para>
        /// <para>Произведение всех положительных чисел меньше или равных указанному, в качестве аргумента, числу.</para>
        /// </returns>
        public static TLinkAddress Factorial<TLinkAddress>(TLinkAddress n) where TLinkAddress : IUnsignedNumber<TLinkAddress>, IComparisonOperators<TLinkAddress, TLinkAddress, bool>
        {
            if (n >= TLinkAddress.Zero && n <= TLinkAddress.CreateTruncating(MaximumCatalanIndex))
            {
                return TLinkAddress.CreateTruncating(_factorials[ulong.CreateTruncating(n)]);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Only numbers from 0 to {MaximumFactorialNumber} are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>Returns the Catalan Number with the number specified as an argument.</para>
        /// <para>Возвращает Число Катанала с номером, указанным в качестве аргумента.</para>
        /// </summary>
        /// <param name="n">
        /// <para>The number of the Catalan number.</para>
        /// <para>Номер Числа Катанала.</para>
        /// </param>
        /// <returns>
        /// <para>The Catalan Number with the number specified as an argument.</para>
        /// <para>Число Катанала с номером, указанным в качестве аргумента.</para>
        /// </returns>
        public static TLinkAddress Catalan<TLinkAddress>(TLinkAddress n) where TLinkAddress : IUnsignedNumber<TLinkAddress>, IComparisonOperators<TLinkAddress, TLinkAddress, bool>
        {
            if (n >= TLinkAddress.Zero && n <= TLinkAddress.CreateTruncating(MaximumCatalanIndex))
            {
                return TLinkAddress.CreateTruncating(_catalans[ulong.CreateTruncating(n)]);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Only numbers from 0 to {MaximumCatalanIndex} are supported by unsigned integer with 64 bits length.");
            }
        }

        /// <summary>
        /// <para>Checks if a number is a power of two.</para>
        /// <para>Проверяет, является ли число степенью двойки.</para>
        /// </summary>
        /// <param name="x">
        /// <para>The number to check.</para>
        /// <para>Число для проверки.</para>
        /// </param>
        /// <returns>
        /// <para>True if the number is a power of two otherwise false.</para>
        /// <para>True, если число является степенью двойки, иначе - false.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPowerOfTwo<TLinkAddress>(TLinkAddress x) where TLinkAddress : IUnsignedNumber<TLinkAddress>, IBitwiseOperators<TLinkAddress, TLinkAddress, TLinkAddress>, IComparisonOperators<TLinkAddress, TLinkAddress, bool>
        {
            return (x & x - TLinkAddress.One) == TLinkAddress.Zero;
        }

        /// <summary>
        /// <para>Adds two values and returns the result.</para>
        /// <para>Складывает два значения и возвращает результат.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports addition operations.</para>
        /// <para>Тип, который поддерживает операции сложения.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The first value to add.</para>
        /// <para>Первое значение для сложения.</para>
        /// </param>
        /// <param name="right">
        /// <para>The second value to add.</para>
        /// <para>Второе значение для сложения.</para>
        /// </param>
        /// <returns>
        /// <para>The result of adding left and right.</para>
        /// <para>Результат сложения left и right.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Add<T>(T left, T right) where T : IAdditionOperators<T, T, T>
        {
            return left + right;
        }

        /// <summary>
        /// <para>Subtracts one value from another and returns the result.</para>
        /// <para>Вычитает одно значение из другого и возвращает результат.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports subtraction operations.</para>
        /// <para>Тип, который поддерживает операции вычитания.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The value to subtract from.</para>
        /// <para>Значение, из которого вычитается.</para>
        /// </param>
        /// <param name="right">
        /// <para>The value to subtract.</para>
        /// <para>Значение, которое вычитается.</para>
        /// </param>
        /// <returns>
        /// <para>The result of subtracting right from left.</para>
        /// <para>Результат вычитания right из left.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Subtract<T>(T left, T right) where T : ISubtractionOperators<T, T, T>
        {
            return left - right;
        }

        /// <summary>
        /// <para>Multiplies two values and returns the result.</para>
        /// <para>Умножает два значения и возвращает результат.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports multiplication operations.</para>
        /// <para>Тип, который поддерживает операции умножения.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The first value to multiply.</para>
        /// <para>Первое значение для умножения.</para>
        /// </param>
        /// <param name="right">
        /// <para>The second value to multiply.</para>
        /// <para>Второе значение для умножения.</para>
        /// </param>
        /// <returns>
        /// <para>The result of multiplying left and right.</para>
        /// <para>Результат умножения left и right.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Multiply<T>(T left, T right) where T : IMultiplyOperators<T, T, T>
        {
            return left * right;
        }

        /// <summary>
        /// <para>Divides one value by another and returns the result.</para>
        /// <para>Делит одно значение на другое и возвращает результат.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports division operations.</para>
        /// <para>Тип, который поддерживает операции деления.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The dividend.</para>
        /// <para>Делимое.</para>
        /// </param>
        /// <param name="right">
        /// <para>The divisor.</para>
        /// <para>Делитель.</para>
        /// </param>
        /// <returns>
        /// <para>The result of dividing left by right.</para>
        /// <para>Результат деления left на right.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Divide<T>(T left, T right) where T : IDivisionOperators<T, T, T>
        {
            return left / right;
        }

        /// <summary>
        /// <para>Negates a value and returns the result.</para>
        /// <para>Отрицает значение и возвращает результат.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports unary negation operations.</para>
        /// <para>Тип, который поддерживает операции унарного отрицания.</para>
        /// </typeparam>
        /// <param name="value">
        /// <para>The value to negate.</para>
        /// <para>Значение для отрицания.</para>
        /// </param>
        /// <returns>
        /// <para>The negated value.</para>
        /// <para>Отрицательное значение.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Negate<T>(T value) where T : IUnaryNegationOperators<T, T>
        {
            return -value;
        }

        /// <summary>
        /// <para>Returns the smaller of two values.</para>
        /// <para>Возвращает меньшее из двух значений.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports comparison operations.</para>
        /// <para>Тип, который поддерживает операции сравнения.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The first value to compare.</para>
        /// <para>Первое значение для сравнения.</para>
        /// </param>
        /// <param name="right">
        /// <para>The second value to compare.</para>
        /// <para>Второе значение для сравнения.</para>
        /// </param>
        /// <returns>
        /// <para>The smaller of the two values.</para>
        /// <para>Меньшее из двух значений.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Min<T>(T left, T right) where T : IComparisonOperators<T, T, bool>
        {
            return left < right ? left : right;
        }

        /// <summary>
        /// <para>Returns the larger of two values.</para>
        /// <para>Возвращает большее из двух значений.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports comparison operations.</para>
        /// <para>Тип, который поддерживает операции сравнения.</para>
        /// </typeparam>
        /// <param name="left">
        /// <para>The first value to compare.</para>
        /// <para>Первое значение для сравнения.</para>
        /// </param>
        /// <param name="right">
        /// <para>The second value to compare.</para>
        /// <para>Второе значение для сравнения.</para>
        /// </param>
        /// <returns>
        /// <para>The larger of the two values.</para>
        /// <para>Большее из двух значений.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Max<T>(T left, T right) where T : IComparisonOperators<T, T, bool>
        {
            return left > right ? left : right;
        }

        /// <summary>
        /// <para>Returns the absolute value of a number.</para>
        /// <para>Возвращает абсолютное значение числа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports number operations.</para>
        /// <para>Тип, который поддерживает числовые операции.</para>
        /// </typeparam>
        /// <param name="value">
        /// <para>The value to get the absolute value of.</para>
        /// <para>Значение, для которого нужно получить абсолютное значение.</para>
        /// </param>
        /// <returns>
        /// <para>The absolute value of the input.</para>
        /// <para>Абсолютное значение входного параметра.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(T value) where T : INumberBase<T>
        {
            return T.Abs(value);
        }

        /// <summary>
        /// <para>Returns a value that indicates the sign of a number.</para>
        /// <para>Возвращает значение, которое указывает знак числа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports number operations.</para>
        /// <para>Тип, который поддерживает числовые операции.</para>
        /// </typeparam>
        /// <param name="value">
        /// <para>The value to get the sign of.</para>
        /// <para>Значение, для которого нужно получить знак.</para>
        /// </param>
        /// <returns>
        /// <para>A number that indicates the sign of value: -1 if value is less than zero, 0 if value equals zero, 1 if value is greater than zero.</para>
        /// <para>Число, которое указывает знак value: -1, если value меньше нуля, 0, если value равно нулю, 1, если value больше нуля.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign<T>(T value) where T : INumber<T>
        {
            return T.Sign(value);
        }

        /// <summary>
        /// <para>Computes the sum of a sequence of numeric values.</para>
        /// <para>Вычисляет сумму последовательности числовых значений.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports addition operations.</para>
        /// <para>Тип, который поддерживает операции сложения.</para>
        /// </typeparam>
        /// <param name="values">
        /// <para>A sequence of values to calculate the sum of.</para>
        /// <para>Последовательность значений для вычисления суммы.</para>
        /// </param>
        /// <returns>
        /// <para>The sum of the values in the sequence.</para>
        /// <para>Сумма значений в последовательности.</para>
        /// </returns>
        public static T Sum<T>(IEnumerable<T> values) where T : IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>
        {
            return values.Aggregate(T.AdditiveIdentity, Add);
        }

        /// <summary>
        /// <para>Computes the average of a sequence of numeric values.</para>
        /// <para>Вычисляет среднее значение последовательности числовых значений.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports division and addition operations.</para>
        /// <para>Тип, который поддерживает операции деления и сложения.</para>
        /// </typeparam>
        /// <param name="values">
        /// <para>A sequence of values to calculate the average of.</para>
        /// <para>Последовательность значений для вычисления среднего.</para>
        /// </param>
        /// <returns>
        /// <para>The average of the values in the sequence.</para>
        /// <para>Среднее значение последовательности.</para>
        /// </returns>
        public static T Average<T>(IEnumerable<T> values) where T : IAdditiveIdentity<T, T>, IAdditionOperators<T, T, T>, IDivisionOperators<T, T, T>, INumber<T>
        {
            var valuesList = values.ToList();
            if (valuesList.Count == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }
            var sum = Sum(valuesList);
            var count = T.CreateTruncating(valuesList.Count);
            return Divide(sum, count);
        }

        /// <summary>
        /// <para>Gets the additive identity value for the specified type.</para>
        /// <para>Получает аддитивную идентичность для указанного типа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports additive identity.</para>
        /// <para>Тип, который поддерживает аддитивную идентичность.</para>
        /// </typeparam>
        /// <returns>
        /// <para>The additive identity (zero) for the type.</para>
        /// <para>Аддитивная идентичность (ноль) для типа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Zero<T>() where T : IAdditiveIdentity<T, T>
        {
            return T.AdditiveIdentity;
        }

        /// <summary>
        /// <para>Gets the multiplicative identity value for the specified type.</para>
        /// <para>Получает мультипликативную идентичность для указанного типа.</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>The type that supports multiplicative identity.</para>
        /// <para>Тип, который поддерживает мультипликативную идентичность.</para>
        /// </typeparam>
        /// <returns>
        /// <para>The multiplicative identity (one) for the type.</para>
        /// <para>Мультипликативная идентичность (единица) для типа.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T One<T>() where T : IMultiplicativeIdentity<T, T>
        {
            return T.MultiplicativeIdentity;
        }
    }
}
