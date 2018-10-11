using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem004
    {
        public int FindLargestPalindrome(int digitLength)
        {
            int a = RepeatedNine(digitLength);
            int currentPalindrome = 0;
            while (a > 1)
            {
                int palindrome = InnerLoop(a);
                if (palindrome > currentPalindrome)
                {
                    currentPalindrome = palindrome;
                }

                a--;
            }

            return currentPalindrome;
        }

        private int InnerLoop(int a)
        {
            int b = a - 1;
            int currentPalindrome = 0;
            while (b > 1)
            {
                int product = a * b;
                if (IsPalindrome(product) && product > currentPalindrome)
                {
                    currentPalindrome = product;
                }

                b--;
            }

            return currentPalindrome;
        }

        internal bool IsPalindrome(int num)
        {
            int temp = num;
            int reversedNum = 0;
            while (temp > 0)
            {
                int rightMostDigit = temp % 10;
                reversedNum = reversedNum * 10 + rightMostDigit;
                temp /= 10;
            }

            return reversedNum == num;
        }

        private int RepeatedNine(int digitLength)
        {
            int principle = 9;
            int multiplier = 10;
            int expandedNumber = 0;
            for (int i = 0; i < digitLength - 1; i++)
            {
                expandedNumber += principle * multiplier;
                multiplier *= 10;
            }

            expandedNumber += principle;
            return expandedNumber;
        }
    }
}
