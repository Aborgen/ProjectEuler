using System;
using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem012Tests
    {
        private Problem012 CreateProblem012()
        {
            return new Problem012();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem012();
            var result = unitUnderTest.FindUniqueTriangleDivisors(5);

            // The first triangle number to have over 5 divisors is 28
            Assert.Equal(28, result);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem012();
            var result = unitUnderTest.FindUniqueTriangleDivisors(500);

            // The first triangle number to have over 500 divisors is 76576500
            Assert.Equal(76576500, result);
        }
    }
}
