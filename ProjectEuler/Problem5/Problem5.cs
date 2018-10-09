using System;

namespace ProjectEuler
{
    class Problem5
    {
        public int SmallestMultiple(int maxMultiple)
        {
            var IsAllMultiple = Bridge(maxMultiple);
            int possibleAnswer = maxMultiple;
            while (true)
            {
                if (IsAllMultiple(possibleAnswer))
                {
                    break;
                }

                possibleAnswer += maxMultiple;
            }
            return possibleAnswer;

        }

        private Func<int, bool> Bridge(int maxMultiple)
        {
            return num => MultipleInRange(num, maxMultiple);
        }

        private bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        private bool MultipleInRange(int num, int maxMultiple)
        {
            int temp = maxMultiple;
            while (temp > 1)
            {
                if (num % temp != 0)
                {
                    return false;
                }

                temp--;
            }

            return true;
        }
    }
}

// Check:
//  Is the number even 
//  Is the number divisible by the largest multiple of 3
//  Is the number divisible by the largest multiple of 4
//  Does the number end in a 0

// The number must be even, must end in a 0

// Factor out the largest multiple of 3, 4, 7
