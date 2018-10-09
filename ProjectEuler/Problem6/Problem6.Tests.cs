using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem6Tests
    {
        private Problem6 CreateProblem6()
        {
            return new Problem6();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem6();
            var difference = unitUnderTest.SumSquareDifference(10);
            Assert.Equal(2640, difference);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem6();
            var difference = unitUnderTest.SumSquareDifference(100);
            Assert.Equal(25164150, difference);
        }
    }
}
