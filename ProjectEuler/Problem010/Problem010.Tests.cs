using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem010Tests
    {
        private Problem010 CreateProblem010()
        {
            return new Problem010();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem010();
            var sum = unitUnderTest.SumPrimesBelowN(upperBound: 10);
            Assert.Equal(17, sum);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem010();
            var sum = unitUnderTest.SumPrimesBelowN(upperBound: 2000000); // 2,000,000
            Assert.Equal(142913828922, sum);
        }
    }
}
