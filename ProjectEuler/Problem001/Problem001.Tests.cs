using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem001Tests
    {
        private Problem001 CreateProblem001()
        {
            return new Problem001();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem001();
            var sum = unitUnderTest.SumNumbersBelow(10);
            Assert.Equal(23, sum);
        }

        [Theory]
        [InlineData(1000, 233168)]
        public void Solved(int value, int correctResult)
        {
            var unitUnderTest = CreateProblem001();
            var sum = unitUnderTest.SumNumbersBelow(value);
            Assert.Equal(correctResult, sum);
        }
    }
}
