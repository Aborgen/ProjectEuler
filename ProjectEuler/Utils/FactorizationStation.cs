using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    class FactorizationStation
    {
        public List<int> FindAllDivisors(int num, bool isSorted = false)
        {
            var listOfdivisors = FindDivisors(num, onlyUnique: false);
            if (isSorted)
            {
                listOfdivisors.Sort();
            }

            return listOfdivisors;
        }

        public List<int> FindUniqueDivisors(int num, bool isSorted = false)
        {
            var listOfdivisors = FindDivisors(num, onlyUnique: true);
            if (isSorted)
            {
                listOfdivisors.Sort();
            }

            return listOfdivisors;
        }

        private List<int> FindDivisors(int num, bool onlyUnique)
        {
            int length = Convert.ToInt32(Math.Sqrt(num));
            var listOfDivisors = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                int quotient = Math.DivRem(num, i, out int remainder);
                if (remainder == 0)
                {
                    // If we are looking for unique divisors,
                    // we make sure to only add each divisor once.
                    if (onlyUnique && quotient == i)
                    {
                        listOfDivisors.Add(quotient);
                    }
                    else
                    {
                        listOfDivisors.Add(i);
                        listOfDivisors.Add(quotient);
                    }
                }
            }

            return listOfDivisors;
        }
    }
}
