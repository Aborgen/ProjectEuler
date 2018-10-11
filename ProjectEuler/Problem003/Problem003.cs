using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler
{
    class Problem003
    {
        public List<int> FindPrimeFactors(int value)
        {
            var primeFactors = new List<int>();
            int temp = value;
            int currentPrime = 0;
            while (!PrimeGen.IsPrime(temp))
            {
                PrimeGen.Next(ref currentPrime);
                int remainder;
                int quotient = Math.DivRem(temp, currentPrime, out remainder);
                if (remainder == 0)
                {
                    primeFactors.Add(currentPrime);
                    temp = quotient;
                }
            }

            primeFactors.Add(temp);
            return primeFactors;
        }

        public List<long> FindPrimeFactors(long value)
        {
            var primeFactors = new List<long>();
            long temp = value;
            long currentPrime = 0;
            while (!PrimeGen.IsPrime(temp))
            {
                PrimeGen.Next(ref currentPrime);
                long remainder;
                long quotient = Math.DivRem(temp, currentPrime, out remainder);
                if (remainder == 0)
                {
                    primeFactors.Add(currentPrime);
                    temp = quotient;
                }
            }

            primeFactors.Add(temp);
            return primeFactors;
        }

        public int FindLargestPrimeFactor(int value)
        {
            var primeFactors = FindPrimeFactors(value);
            return primeFactors[primeFactors.Count - 1];
        }

        public long FindLargestPrimeFactor(long value)
        {
            var primeFactors = FindPrimeFactors(value);
            return primeFactors[primeFactors.Count - 1];
        }
    }
}
