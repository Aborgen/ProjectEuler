using System.Collections.Generic;
using Xunit;

namespace ProjectEuler.Utils.Tests
{
    public class FactorizationStationTests
    {
        private FactorizationStation CreateFactorizationStation()
        {
            return new FactorizationStation();
        }

        [Theory]
        [MemberData(nameof(AllData))]
        public void FindAllDivisors(int principle, List<int> expectedDivisors)
        {
            var unitUnderTest = CreateFactorizationStation();
            var result = unitUnderTest.FindAllDivisors(principle, true);

            Assert.Equal(expectedDivisors, result);
        }

        [Theory]
        [MemberData(nameof(UniqueData))]
        public void FindUniqueDivisors(int principle, List<int> expectedDivisors)
        {
            var unitUnderTest = CreateFactorizationStation();
            var result = unitUnderTest.FindUniqueDivisors(principle, isSorted: true);

            Assert.Equal(expectedDivisors, result);
        }

        public static IEnumerable<object[]> AllData =>
        new List<object[]>
        {
            new object[] {
                3,
                new List<int>() { 1, 3 }
            },
            new object[] {
                4,
                new List<int>() { 1, 2, 2, 4 }
            },
            new object[] {
                100,
                new List<int>() { 1, 2, 4, 5, 10, 10, 20, 25, 50, 100 }
            },
        };

        public static IEnumerable<object[]> UniqueData =>
        new List<object[]>
        {
            new object[] {
                3,
                new List<int>() { 1, 3 }
            },
            new object[] {
                4,
                new List<int>() { 1, 2, 4 }
            },
            new object[] {
                10,
                new List<int>() { 1, 2, 5, 10 }
            },
            new object[] {
                28,
                new List<int>() { 1, 2, 4, 7, 14, 28 }
            },
            new object[] {
                100,
                new List<int>() { 1, 2, 4, 5, 10, 20, 25, 50, 100 }
            },
        };
    }
}
