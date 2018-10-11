using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem006Tests
    {
        private Problem006 CreateProblem006()
        {
            return new Problem006();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem006();
            var difference = unitUnderTest.SumSquareDifference(10);
            Assert.Equal(2640, difference);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem006();
            var difference = unitUnderTest.SumSquareDifference(100);
            Assert.Equal(25164150, difference);
        }
    }
}
