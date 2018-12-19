using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public class TriangleNumber : INumberGenerator
    {
        private BigInteger _triangleSum;
        private bool IsSumUpToDate { get; set; } = true;

        public List<int> CurrentSeries { get; private set; }
        public int CurrentNumber { get; private set; } = 0;

        public TriangleNumber()
        {
            CurrentSeries = new List<int>();
        }

        public BigInteger GetSum()
        {
            if (!IsSumUpToDate)
            {
                SetSum(CurrentSeries.Sum());
                IsSumUpToDate = true;
            }
            
            return _triangleSum;
        }

        private void SetSum(BigInteger value)
        {
            _triangleSum = value;
        }

        public List<BigInteger> GenerateList(int length)
        {
            var listOfSums = new List<BigInteger>(length);
            for (int i = 0; i < length; i++)
            {
                Next();
                listOfSums.Add(GetSum());
            }

            return listOfSums;
        }

        public BigInteger NthNumber(int index)
        {
            var triangleSeries = new List<long>(index);
            for (int i = 0; i < index; i++)
            {
                Next();
            }

            return GetSum();
        }

        public void Next()
        {
            if (CurrentNumber == int.MaxValue)
            {
                var error = "Reached maximum value of 32bit integer.";
                throw new OverflowException(error);
            }

            var nextNumber = ++CurrentNumber;
            CurrentSeries.Add(nextNumber);
            IsSumUpToDate = false;
        }
    }
}
