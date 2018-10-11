using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem9Tests
    {
        private Problem9 CreateProblem9()
        {
            return new Problem9();
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem9();
            var product = unitUnderTest.PythagoreanTripletProduct(goal: 1000);
            Assert.Equal(31875000, product);
        }
    }
}
