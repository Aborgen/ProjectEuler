using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem5Tests
    {
        private Problem5 CreateProblem5()
        {
            return new Problem5();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem5();
            int smallestPositiveNumber = unitUnderTest.SmallestMultiple(maxMultiple:10);
            Assert.Equal(2520, smallestPositiveNumber);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem5();
            int smallestPositiveNumber = unitUnderTest.SmallestMultiple(maxMultiple:20);
            Assert.Equal(232792560, smallestPositiveNumber);
        }
    }
}
