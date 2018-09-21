using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem1Tests
    {
        private Problem1 CreateProblem1()
        {
            return new Problem1();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem1();
            var sum = unitUnderTest.SumNumbersBelow(10);
            Assert.Equal(23, sum);
        }

        [Theory]
        [InlineData(1000, 233168)]
        public void Solved(int value, int correctResult)
        {
            var unitUnderTest = CreateProblem1();
            var sum = unitUnderTest.SumNumbersBelow(value);
            Assert.Equal(correctResult, sum);
        }
    }
}
