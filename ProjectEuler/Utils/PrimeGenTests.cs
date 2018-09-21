using ProjectEuler.Utils;
using System;
using Xunit;

namespace ProjectEuler.Utils.Tests
{
    public class PrimeGenTests
    {
        [Theory]
        [InlineData(11)]
        [InlineData(3)]
        [InlineData(101)]
        [InlineData(257)]
        public void Reduces_Number_Until_Odd(int input)
        {
            int result = PrimeGen.ReduceToOdd(input).Item1;
            Assert.True(result % 2 == 1);
        }

        [Theory]
        [InlineData(11, 5, 1)]
        [InlineData(3, 1, 1)]
        [InlineData(101, 25, 2)]
        [InlineData(257, 1, 8)]
        public void Result_Matches_Expectations(int input, int reducedNum, int timesReduced)
        {
            var (result, reduced) = PrimeGen.ReduceToOdd(input);
            Assert.Equal(reducedNum, result);
            Assert.Equal(timesReduced, reduced);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(3)]
        [InlineData(101)]
        [InlineData(257)]
        public void Resulting_Number_Can_Be_Reconstructed(int input)
        {
            var (result, reduced) = PrimeGen.ReduceToOdd(input);
            var reconstruction = Math.Pow(2, reduced) * result;
            Assert.Equal(reconstruction, input - 1);
        }
    }
}
