using System.Collections.Generic;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class CalcResultTests
    {
        [Fact]
        public static void SimpleIntegration_Test()
        {
            //arrange
            int expected = (5 + 6) * (3 + (9 / 3));
            expected++;
            expected++;
            expected--;

            //act
            var result = ((CalcResult<int>)5 + 6) * (3 + (9 / (CalcResult<int>)3));
            result.Increment();
            result++;
            result--;

            //assert
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public static void ArithmeticOperation_Test(ArithmeticOpetation op, int a, int b)
        {
            //arrange
            int expected = a;
            var result = new CalcResult<int>(a);

            //act
            if (op == ArithmeticOpetation.Add)
            {
                result.Add(b);
                expected += b;
            }

            if (op == ArithmeticOpetation.Subtract)
            {
                result.Subtract(b);
                expected -= b;
            }

            if (op == ArithmeticOpetation.Multiply)
            {
                result.Multiply(b);
                expected *= b;
            }

            if (op == ArithmeticOpetation.Divide)
            {
                result.Divide(b);
                expected /= b;
            }

            //assert
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public static void ArithmeticOperation_Test2(ArithmeticOpetation op, int a, int b)
        {
            //arrange
            int expected = a;
            var result = new CalcResult<int>(a);
            var _b = new CalcResult<int>(b);
            //act
            if (op == ArithmeticOpetation.Add)
            {
                result.Add(_b);
                expected += b;
            }

            if (op == ArithmeticOpetation.Subtract)
            {
                result.Subtract(_b);
                expected -= b;
            }

            if (op == ArithmeticOpetation.Multiply)
            {
                result.Multiply(_b);
                expected *= b;
            }

            if (op == ArithmeticOpetation.Divide)
            {
                result.Divide(_b);
                expected /= b;
            }

            //assert
            Assert.Equal(expected, result.Value);
        }
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {ArithmeticOpetation.Add, 40, 2};

            yield return new object[] { ArithmeticOpetation.Subtract, 44, 2};

            yield return new object[] { ArithmeticOpetation.Multiply, 21, 2 };

            yield return new object[] { ArithmeticOpetation.Divide, 84, 2 };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public static void Operators_Test(ArithmeticOpetation op, int a, int b)
        {
            //arrange
            int expected = a;
            var result = new CalcResult<int>(a);
            //act
            if (op == ArithmeticOpetation.Add)
            {
                result += b;
                expected += b;
            }

            if (op == ArithmeticOpetation.Subtract)
            {
                result -= b;
                expected -= b;
            }

            if (op == ArithmeticOpetation.Multiply)
            {
                result *= b;
                expected *= b;
            }

            if (op == ArithmeticOpetation.Divide)
            {
                result /= b;
                expected /= b;
            }

            //assert
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public static void Operators_Test2(ArithmeticOpetation op, int a, int b)
        {
            //arrange
            int expected = a;
            var result = new CalcResult<int>(a);
            var _b = new CalcResult<int>(b);

            //act
            if (op == ArithmeticOpetation.Add)
            {
                result += _b;
                expected += b;
            }

            if (op == ArithmeticOpetation.Subtract)
            {
                result -= _b;
                expected -= b;
            }

            if (op == ArithmeticOpetation.Multiply)
            {
                result *= _b;
                expected *= b;
            }

            if (op == ArithmeticOpetation.Divide)
            {
                result /= _b;
                expected /= b;
            }

            //assert
            Assert.Equal(expected, result.Value);
        }

        public enum ArithmeticOpetation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
    }
}
