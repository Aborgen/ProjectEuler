using System;
using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem002Tests
    {
        private Problem002 CreateProblem002()
        {
            return new Problem002();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem002();
            var sum = unitUnderTest.SumOfEvenFib(100);
            Assert.Equal(44, sum);
        }

        [Theory]
        [InlineData(4000000, 4613732)]
        public void Solved(int maxValue, int correctAnswer)
        {
            var unitUnderTest = CreateProblem002();
            var sum = unitUnderTest.SumOfEvenFib(maxValue);
            Assert.Equal(correctAnswer, sum);
        }
    }
}
