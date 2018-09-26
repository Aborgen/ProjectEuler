using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
namespace ProjectEuler.Tests
{
    public class Problem3Tests
    {
        private Problem3 CreateProblem3()
        {
            return new Problem3();
        }

        public Problem3Tests()
        {
            PrimeGen.Reset();
        }

        [Fact]
        public void Given__All_Prime_Factors()
        {
            var unitUnderTest = CreateProblem3();
            List<int> primeFactors = unitUnderTest.FindPrimeFactors(13195);
            List<int> expectedPrimeFactors = new List<int>() { 5, 7, 13, 29 };
            Assert.Equal(expectedPrimeFactors, primeFactors);
        }

        [Fact]
        public void Given__Largest_Prime_Factor()
        {
            var unitUnderTest = CreateProblem3();
            int primeFactor = unitUnderTest.FindLargestPrimeFactor(13195);
            Assert.Equal(29, primeFactor);
        }

        [Theory]
        [InlineData(600851475143, new long[] { 71, 839, 1471, 6857 })]
        public void Solved__All_Prime_Factors(long value, long[] correctAnswer)
        {
            var unitUnderTest = CreateProblem3();
            List<long> primeFactor = unitUnderTest.FindPrimeFactors(value);
            Assert.Equal(correctAnswer.ToList(), primeFactor);
        }

        [Theory]
        [InlineData(600851475143, 6857)]
        public void Solved__Largest_Prime_Factor(long value, int correctAnswer)
        {
            var unitUnderTest = CreateProblem3();
            long primeFactor = unitUnderTest.FindLargestPrimeFactor(value);
            Assert.Equal(correctAnswer, primeFactor);
        }

    }
}
