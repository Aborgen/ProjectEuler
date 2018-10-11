
// By considering the terms in the Fibonacci sequence 
// whose values do not exceed four million, find
// the sum of the even-valued terms.

namespace ProjectEuler
{
    class Problem002
    {
        public int SumOfEvenFib(int maxValue)
        {
            var fibList = Utils.Fibonacci.Generate(maxIndex:40);
            int sum = 0;
            for (int i = 0; i < fibList.Count; i++)
            {
                if (fibList[i] > maxValue)
                {
                    break;
                }

                if (fibList[i] % 2 != 0)
                {
                    continue;
                }

                int newSum = sum + (int)fibList[i];
                sum = newSum;
            }

            return sum;
        }
    }
}
