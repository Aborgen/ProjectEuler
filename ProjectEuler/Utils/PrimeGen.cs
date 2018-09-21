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
                while(!IsPrime(nextPrime))
                {
                    ++nextPrime;
                }

                currentPrime = nextPrime;
            }

            return currentPrime;
        }

        public static bool IsPrime(int num, int accuracy = 5)
        {
            if (num != 2 && IsEven(num))
            {
                return false;
            }
            else if (num == 2 || num == 3)
            {
                return true;
            }

            bool isComposite = MillerRabinPrimality(num, accuracy);
            return !isComposite;
        }

        // Returns true if the passed-in number is definitely composite
        // and returns false if the number is probably prime.
        private static bool MillerRabinPrimality(int num, int accuracy)
        {

            Random r = new Random();
            var (reducedNum, timesReduced) = ReduceToOdd(num);
            int randNum;
            for (int _ = 0; _ < accuracy; _++)
            {
                randNum = r.Next(2, num - 2);
                // If a number in the range [2, n-2] to the power
                // of n factored until n is odd mod n is odd,
                // n is probably prime. Continue loop for
                // greater confidence that this is the case.
                double x = Math.Pow(randNum, reducedNum) % num;
                if (x == 1 || x == num - 1)
                {
                    continue;
                }
                else if (!Something(x, num, timesReduced))
                {
                    continue;
                }

                return true;
            }

            return false;
        }

        private static bool Something(double x, int num, int timesReduced)
        {
            double temp = x;
            for (int _ = 0; _ < timesReduced; _++)
            {
                // The second case where the tested number could
                // possibly be prime.
                temp = Math.Pow(temp, 2) % num;
                if (temp == num - 1)
                {
                    return false;
                }
            }

            return true;
        }

        // This method will divide an odd (number - 1) an arbitrary number of times
        // until the resulting number is odd. It returns a tuple containing
        // the odd number as well as the number of times the number has been reduced.
        internal static Tuple<int, int> ReduceToOdd(int num)
        {
            if (IsEven(num))
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

        private static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
