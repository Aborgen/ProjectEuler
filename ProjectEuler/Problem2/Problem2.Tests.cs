using System;
using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem2Tests
    {
        private Problem2 CreateProblem2()
        {
            return new Problem2();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem2();
            var sum = unitUnderTest.SumOfEvenFib(100);
            Assert.Equal(44, sum);
        }

        [Theory]
        [InlineData(4000000, 4613732)]
        public void Solved(int maxValue, int correctAnswer)
        {
            var unitUnderTest = CreateProblem2();
            var sum = unitUnderTest.SumOfEvenFib(maxValue);
            Assert.Equal(correctAnswer, sum);
        }
    }
}
