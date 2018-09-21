using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Tests
{
    public class Problem3Tests
    {
        private Problem3 CreateProblem3()
        {
            return new Problem3();
        }

        [Fact]
        public void Given__All_Prime_Factors()
        {
            var unitUnderTest = CreateProblem3();
            List<int> primeFactors = unitUnderTest.FindPrimeFactors(13195);
            List<int> expectedPrimeFactors = new List<int>() { 5, 7, 13, 29 };
            Assert.StrictEqual(expectedPrimeFactors, primeFactors);
        }

        [Fact]
        public void Given__Largest_Prime_Factor()
        {
            var unitUnderTest = CreateProblem3();
            int primeFactor = unitUnderTest.FindLargestPrimeFactor(13195);
            Assert.Equal(29, primeFactor);
        }

        [Theory]
        [InlineData(600851475143, new int[] { 6857, 50 })]
        public void Solved__All_Prime_Factors(int value, IEnumerable<int> correctAnswer)
        {
            var unitUnderTest = CreateProblem3();
            List<int> primeFactor = unitUnderTest.FindPrimeFactors(value);
            Assert.StrictEqual(correctAnswer, primeFactor);
        }

        [Theory]
        [InlineData(600851475143, 6857)]
        public void Solved__Largest_Prime_Factor(int value, int correctAnswer)
        {
            var unitUnderTest = CreateProblem3();
            int primeFactor = unitUnderTest.FindLargestPrimeFactor(value);
            Assert.Equal(correctAnswer, primeFactor);
        }

    }
}
