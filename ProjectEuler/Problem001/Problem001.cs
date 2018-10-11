using System.Collections.Generic;
using System.Linq;

// Find the sum of all the multiples of 3 or 5 below 1000.
namespace ProjectEuler
{
    public class Problem001
    {

        public int SumNumbersBelow(int maxLimit)
        {
            List<int> list = new List<int>();
            this.AddRange(maxLimit, ref list);
            var filteredList = list.Where(x => this.PreferredCandidate(x));
            return filteredList.Sum();
        }

        private bool PreferredCandidate(int number)
        {
            return number % 3 == 0 || number % 5 == 0;
        }

        private void AddRange(int maxLimit, ref List<int> list)
        {
            for (int i = 1; i < maxLimit; i++)
            {
                list.Add(i);
            }
        }
    }
}
