using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    static class PrimeGen
    {
        // Returns the next prime
        public static void Next(int startingPoint, out int result)
        {
            int nextPrime = startingPoint + 1;
            while(!IsPrime(nextPrime))
            {
                ++nextPrime;
            }

            result = nextPrime;
        }

        public static void Next(ref int result)
        {
            int startingPoint = result;
            int nextPrime = startingPoint + 1;
            while (!IsPrime(nextPrime))
            {
                ++nextPrime;
            }

            result = nextPrime;
        }

        public static void Next(long startingPoint, out long result)
        {
            long nextPrime = startingPoint + 1;
            while(!IsPrime(nextPrime))
            {
                ++nextPrime;
            }

            result = nextPrime;
        }

        public static void Next(ref long result)
        {
            long startingPoint = result;
            long nextPrime = startingPoint + 1;
            while (!IsPrime(nextPrime))
            {
                ++nextPrime;
            }

            result = nextPrime;
        }

        public static bool IsPrime(int num, int accuracy = 5)
        {
            if (num < 2)
            {
                return false;
            }
            else if (num != 2 && IsEven(num))
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

        public static bool IsPrime(long num, int accuracy = 5)
        {
            if (num < 2)
            {
                return false;
            }
            else if (num != 2 && IsEven(num))
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
            var (reducedNum, timesReduced) = ReduceToOdd(num);
            Random r = new Random();
            for (int _ = 0; _ < accuracy; _++)
            {
                // Random.Next(): minValue is inclusive and maxValue is
                // exclusive. The range we actually want is [2, num - 2]
                int randNum = r.Next(2, num - 1);
                // If a number in the range [2, n-2] to the power
                // of n factored until n is odd mod n is odd,
                // n is probably prime. Continue loop for
                // greater confidence that this is the case.
                var x = BigInteger.ModPow(randNum, reducedNum, num);
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

        private static bool MillerRabinPrimality(long num, int accuracy)
        {
            var (reducedNum, timesReduced) = ReduceToOdd(num);
            int safeNum = num > int.MaxValue ? int.MaxValue : Convert.ToInt32(num);
            Random r = new Random();
            for (int _ = 0; _ < accuracy; _++)
            {
                // Random.Next(): minValue is inclusive and maxValue is
                // exclusive. The range we actually want is [2, num - 2]
                int randNum = r.Next(2, safeNum - 1);
                // If a number in the range [2, n-2] to the power
                // of n factored until n is odd mod n is odd,
                // n is probably prime. Continue loop for
                // greater confidence that this is the case.
                var x = BigInteger.ModPow(randNum, reducedNum, num);
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

        private static bool Something(BigInteger x, int num, int timesReduced)
        {
            BigInteger temp = x;
            for (int _ = 0; _ < timesReduced; _++)
            {
                // The second case where the tested number could
                // possibly be prime.
                temp = BigInteger.ModPow(temp, 2, num);
                if (temp == 1)
                {
                    break;
                }
                else if (temp == num - 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Something(BigInteger x, long num, int timesReduced)
        {
            BigInteger temp = x;
            for (int _ = 0; _ < timesReduced; _++)
            {
                // The second case where the tested number could
                // possibly be prime.
                temp = BigInteger.ModPow(temp, 2, num);
                if (temp == 1)
                {
                    break;
                }
                else if (temp == num - 1)
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

        internal static Tuple<long, int> ReduceToOdd(long num)
        {
            if (IsEven(num))
            {
                throw new InvalidOperationException("Even integers are not supported");
            }

            long reducedNum = num - 1;
            int timesReduced = 0;
            while (true)
            {
                long remainder;
                long quotient = Math.DivRem(reducedNum, 2, out remainder);

                if (remainder == 1)
                {
                    break;
                }

                reducedNum = quotient;
                ++timesReduced;
            }

            return new Tuple<long, int>(reducedNum, timesReduced);
        }

        private static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        private static bool IsEven(long num)
        {
            return num % 2 == 0;
        }
    }
}
