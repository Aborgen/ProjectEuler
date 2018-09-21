using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    static class PrimeGen
    {
        private static int currentPrime { get; set; }

        public static int Next()
        {
            if (currentPrime == 0)
            {
                currentPrime = 2;
            }
            else
            {
                int nextPrime = currentPrime + 1;
                while(!isPrime(nextPrime))
                {
                    ++nextPrime;
                }

                currentPrime = nextPrime;
            }

            return currentPrime;
        }

        private static bool isPrime(int num, int accuracy = 5)
        {
            return true;
        }

        // This method will divide an odd (number - 1) an arbitrary number of times
        // until the resulting number is odd. It returns a tuple containing
        // the odd number as well as the number of times the number has been reduced.
        internal static Tuple<int, int> ReduceToOdd(int num)
        {
            if (isEven(num))
            {
                throw new InvalidOperationException("Even integers are not supported");
            }

            int reducedNum   = num - 1;
            int timesReduced = 0;
            while (true)
            {
                int remainder;
                int quotient = Math.DivRem(reducedNum, 2, out remainder);

                if (remainder == 1)
                {
                    break;
                }

                reducedNum = quotient;
                ++timesReduced;
            }

            return new Tuple<int, int>(reducedNum, timesReduced);
        }

        private static bool isEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
