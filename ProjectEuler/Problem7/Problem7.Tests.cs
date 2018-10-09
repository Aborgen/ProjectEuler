using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem7Tests
    {
        private Problem7 CreateProblem7()
        {
            return new Problem7();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem7();
            int primeNum = unitUnderTest.NthPrime(index:6);
            Assert.Equal(13, primeNum);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem7();
            int primeNum = unitUnderTest.NthPrime(index:10001);
            Assert.Equal(104743, primeNum);
        }
    }
}
