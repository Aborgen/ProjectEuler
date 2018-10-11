using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem009Tests
    {
        private Problem009 CreateProble009()
        {
            return new Problem009();
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProble009();
            var product = unitUnderTest.PythagoreanTripletProduct(goal: 1000);
            Assert.Equal(31875000, product);
        }
    }
}
