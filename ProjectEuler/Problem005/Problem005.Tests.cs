using Xunit;

namespace ProjectEuler.Tests
{
    public class Problem005Tests
    {
        private Problem005 CreateProblem005()
        {
            return new Problem005();
        }

        [Fact]
        public void Given()
        {
            var unitUnderTest = CreateProblem005();
            int smallestPositiveNumber = unitUnderTest.SmallestMultiple(maxMultiple:10);
            Assert.Equal(2520, smallestPositiveNumber);
        }

        [Fact]
        public void Solved()
        {
            var unitUnderTest = CreateProblem005();
            int smallestPositiveNumber = unitUnderTest.SmallestMultiple(maxMultiple:20);
            Assert.Equal(232792560, smallestPositiveNumber);
        }
    }
}
