using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Numerics;
using System.Text.RegularExpressions;
using Xunit;

namespace Platform.Numbers.Tests
{
    public static class MathTests
    {
        private static readonly TimeSpan ComputationTimeLimit = TimeSpan.FromSeconds(10);
        private static readonly HttpClient HttpClient = new();

        // Fetches all entries from an OEIS b-file (plain text format: "n value" per line).
        // Returns a dictionary mapping index -> value as BigInteger.
        // The b-file URL format is: https://oeis.org/AXXXXXX/b000XXX.txt
        private static Dictionary<ulong, BigInteger> FetchOeisSequence(string bFileUrl)
        {
            var result = new Dictionary<ulong, BigInteger>();
            string content = HttpClient.GetStringAsync(bFileUrl).GetAwaiter().GetResult();
            foreach (var line in content.Split('\n'))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("#") || trimmed.Length == 0)
                {
                    continue;
                }
                var parts = Regex.Split(trimmed, @"\s+");
                if (parts.Length >= 2 && ulong.TryParse(parts[0], out var index) && BigInteger.TryParse(parts[1], out var value))
                {
                    result[index] = value;
                }
            }
            return result;
        }

        // Lazily-fetched OEIS sequences, cached for the lifetime of the test run.
        private static Dictionary<ulong, BigInteger>? _oeisFactorials;
        private static Dictionary<ulong, BigInteger> OeisFactorials =>
            _oeisFactorials ??= FetchOeisSequence("https://oeis.org/A000142/b000142.txt");

        private static Dictionary<ulong, BigInteger>? _oeisCatalans;
        private static Dictionary<ulong, BigInteger> OeisCatalans =>
            _oeisCatalans ??= FetchOeisSequence("https://oeis.org/A000108/b000108.txt");

        // Computes factorial of n using BigInteger so it never overflows.
        // Returns null if computation exceeds the time limit.
        private static BigInteger? ComputeFactorialWithTimeLimit(ulong n)
        {
            var stopwatch = Stopwatch.StartNew();
            BigInteger result = BigInteger.One;
            for (ulong i = 2; i <= n; i++)
            {
                result *= i;
                if (stopwatch.Elapsed > ComputationTimeLimit)
                {
                    return null;
                }
            }
            return result;
        }

        // Computes the nth Catalan number from scratch using the formula:
        // C(n) = (2n)! / ((n+1)! * n!)
        // Returns null if computation exceeds the time limit.
        private static BigInteger? ComputeCatalanWithTimeLimit(ulong n)
        {
            var twoNFact = ComputeFactorialWithTimeLimit(2 * n);
            if (twoNFact is null)
            {
                return null;
            }

            var nPlusOneFact = ComputeFactorialWithTimeLimit(n + 1);
            if (nPlusOneFact is null)
            {
                return null;
            }

            var nFact = ComputeFactorialWithTimeLimit(n);
            if (nFact is null)
            {
                return null;
            }

            return twoNFact / (nPlusOneFact * nFact);
        }

        [Theory]
        [InlineData(0ul, 1ul)]
        [InlineData(1ul, 1ul)]
        [InlineData(2ul, 2ul)]
        [InlineData(3ul, 6ul)]
        [InlineData(4ul, 24ul)]
        [InlineData(5ul, 120ul)]
        [InlineData(6ul, 720ul)]
        [InlineData(10ul, 3628800ul)]
        [InlineData(20ul, 2432902008176640000ul)]
        public static void FactorialTest(ulong input, ulong expected)
        {
            Assert.Equal(expected, Math.Factorial(input));
        }

        [Theory]
        [InlineData(21ul)]
        [InlineData(100ul)]
        [InlineData(ulong.MaxValue)]
        public static void FactorialOutOfRangeTest(ulong input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Factorial(input));
        }

        [Theory]
        [InlineData(0ul, 1ul)]
        [InlineData(1ul, 1ul)]
        [InlineData(2ul, 2ul)]
        [InlineData(3ul, 5ul)]
        [InlineData(4ul, 14ul)]
        [InlineData(5ul, 42ul)]
        [InlineData(6ul, 132ul)]
        [InlineData(10ul, 16796ul)]
        [InlineData(36ul, 11959798385860453492ul)]
        public static void CatalanTest(ulong input, ulong expected)
        {
            Assert.Equal(expected, Math.Catalan(input));
        }

        [Theory]
        [InlineData(37ul)]
        [InlineData(100ul)]
        [InlineData(ulong.MaxValue)]
        public static void CatalanOutOfRangeTest(ulong input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Catalan(input));
        }

        [Theory]
        [InlineData(0ul, true)]
        [InlineData(1ul, true)]
        [InlineData(2ul, true)]
        [InlineData(3ul, false)]
        [InlineData(4ul, true)]
        [InlineData(5ul, false)]
        [InlineData(8ul, true)]
        [InlineData(16ul, true)]
        [InlineData(32ul, true)]
        [InlineData(64ul, true)]
        [InlineData(128ul, true)]
        [InlineData(256ul, true)]
        [InlineData(512ul, true)]
        [InlineData(1024ul, true)]
        [InlineData(1023ul, false)]
        [InlineData(1025ul, false)]
        [InlineData(9ul, false)]
        [InlineData(15ul, false)]
        [InlineData(17ul, false)]
        public static void IsPowerOfTwoTest(ulong input, bool expected)
        {
            Assert.Equal(expected, Math.IsPowerOfTwo(input));
        }

        [Fact]
        public static void FactorialGenericTest()
        {
            Assert.Equal(6u, Math.Factorial(3u));
            Assert.Equal(24ul, Math.Factorial(4ul));
        }

        [Fact]
        public static void CatalanGenericTest()
        {
            Assert.Equal(5u, Math.Catalan(3u));
            Assert.Equal(14ul, Math.Catalan(4ul));
        }

        [Fact]
        public static void IsPowerOfTwoGenericTest()
        {
            Assert.True(Math.IsPowerOfTwo(8u));
            Assert.False(Math.IsPowerOfTwo(9u));
            Assert.True(Math.IsPowerOfTwo(16ul));
            Assert.False(Math.IsPowerOfTwo(15ul));
        }

        [Fact]
        public static void MaximumConstantsTest()
        {
            Assert.Equal(20ul, Math.MaximumFactorialNumber);
            Assert.Equal(36ul, Math.MaximumCatalanIndex);
        }

        [Fact]
        public static void PrecalculatedFactorialsMatchComputedValues()
        {
            // Verify that every precalculated factorial constant in Math._factorials is actually
            // a correct factorial value. For values that can be computed locally within 10 seconds,
            // an independent BigInteger computation is used. For values that take longer, the
            // expected value is fetched from OEIS A000142 (https://oeis.org/A000142) via HTTP.
            for (ulong n = 0; n <= Math.MaximumFactorialNumber; n++)
            {
                var computed = ComputeFactorialWithTimeLimit(n);
                BigInteger expected;
                if (computed is null)
                {
                    // Computation exceeded 10 seconds — verify against OEIS A000142.
                    Assert.True(OeisFactorials.TryGetValue(n, out expected),
                        $"OEIS A000142 did not contain a value for n={n}");
                }
                else
                {
                    expected = computed.Value;
                }
                var precalculated = Math.Factorial<ulong>(n);
                Assert.Equal((ulong)expected, precalculated);
            }
        }

        [Fact]
        public static void PrecalculatedCatalansMatchComputedFactorials()
        {
            // Verify that every precalculated Catalan constant in Math._catalans is actually
            // a correct Catalan number. For values that can be computed locally within 10 seconds
            // using the formula C(n) = (2n)! / ((n+1)! * n!), an independent BigInteger computation
            // is used. For values that take longer, the expected value is fetched from OEIS A000108
            // (https://oeis.org/A000108) via HTTP.
            for (ulong n = 0; n <= Math.MaximumCatalanIndex; n++)
            {
                var computed = ComputeCatalanWithTimeLimit(n);
                BigInteger expected;
                if (computed is null)
                {
                    // Computation exceeded 10 seconds — verify against OEIS A000108.
                    Assert.True(OeisCatalans.TryGetValue(n, out expected),
                        $"OEIS A000108 did not contain a value for n={n}");
                }
                else
                {
                    expected = computed.Value;
                }
                var precalculated = Math.Catalan<ulong>(n);
                Assert.Equal((ulong)expected, precalculated);
            }
        }
    }
}
