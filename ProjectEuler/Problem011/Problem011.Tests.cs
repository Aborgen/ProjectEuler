using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem011Tests
    {
        private Problem011 CreateProblem011()
        {
            return new Problem011();
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest  = CreateProblem011();
            var largestProduct = unitUnderTest.LargestProductInSquareGrid(20, 4);
            Assert.Equal(70600674, largestProduct);
        }
    }
}
