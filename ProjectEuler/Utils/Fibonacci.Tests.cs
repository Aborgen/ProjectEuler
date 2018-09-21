using Xunit;

namespace ProjectEuler.Utils.Tests
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 8)]
        [InlineData(8, 34)]
        [InlineData(10, 89)]
        [InlineData(15, 987)]
        [InlineData(50, 20365011074)]
        public void CheckFibIndex(int index, long value, int length = 50)
        {
            var fibList = Fibonacci.Generate(length);
            var valueAtIndex = fibList[index - 1];
            Assert.Equal(value, valueAtIndex);
        }
    }
}
