using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem008Tests
    {
        private Problem008 CreateProblem008()
        {
            return new Problem008();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem008();
            var sum = unitUnderTest.LargestProductInSeries(subSeriesLength:4);
            Assert.Equal(5832, sum);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem008();
            var sum = unitUnderTest.LargestProductInSeries(subSeriesLength:13);
            Assert.Equal(23514624000, sum);
        }
    }
}
