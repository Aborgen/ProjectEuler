using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem8Tests
    {
        private Problem8 CreateProblem8()
        {
            return new Problem8();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem8();
            var sum = unitUnderTest.LargestProductInSeries(subSeriesLength:4);
            Assert.Equal(5832, sum);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem8();
            var sum = unitUnderTest.LargestProductInSeries(subSeriesLength:13);
            Assert.Equal(23514624000, sum);
        }
    }
}
