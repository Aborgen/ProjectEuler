using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem007Tests
    {
        private Problem007 CreateProblem007()
        {
            return new Problem007();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem007();
            int primeNum = unitUnderTest.NthPrime(index:6);
            Assert.Equal(13, primeNum);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem007();
            int primeNum = unitUnderTest.NthPrime(index:10001);
            Assert.Equal(104743, primeNum);
        }
    }
}
