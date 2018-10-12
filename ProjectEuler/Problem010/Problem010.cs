using ProjectEuler.Utils;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Problem010
    {
        public long SumPrimesBelowN(int upperBound)
        {
            var listOfPrimes = new List<int>();
            int currentPrime = 0;
            while (true)
            {
                int nextPrime = currentPrime;
                PrimeGen.Next(ref nextPrime);
                if (nextPrime > upperBound)
                {
                    break;
                }

                listOfPrimes.Add(nextPrime);
                currentPrime = nextPrime;
            }

            long sum = 0;
            // Using IEnumerable's sum() method results in an overflow
            listOfPrimes.ForEach(n => sum += n);
            return sum;
        }
    }
}
