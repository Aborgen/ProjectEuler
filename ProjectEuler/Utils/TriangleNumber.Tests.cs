using ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace ProjectEuler.Utils.Tests
{
    public class TriangleNumberTests
    {
        private TriangleNumber CreateTriangleNumber()
        {
            return new TriangleNumber();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 10)]
        [InlineData(100, 5050)]
        public void Returns_Nth_Triangle(int index, int expected)
        {
            var unitUnderTest = new TriangleNumber();
            var result = unitUnderTest.NthNumber(index);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(125)]
        public void Stores_List_Of_Numbers_Used_In_Sum(int number)
        {
            var unitUnderTest = new TriangleNumber();
            unitUnderTest.NthNumber(number);
            var testList = unitUnderTest.CurrentSeries;
            var actualList = Enumerable.Range(1, number).ToList();

            Assert.Equal(actualList, testList);
        }

        [Fact]
        public void Generates_List_Of_Triangle_Numbers()
        {
            int length = 15;
            var unitUnderTest = new TriangleNumber();
            var testList = unitUnderTest.GenerateList(length);
            var actualList = new List<BigInteger>()
            {
                1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120
            };

            Assert.Equal(actualList, testList);
        }
    }
}
