using System.Collections.Generic;

namespace ProjectEuler.Utils
{
    static class Fibonacci
    {
        public static List<long> Generate(int maxIndex)
        {
            long a = 0;
            long b = 1;
            List<long> list = new List<long>();
            for (int i = 0; i < maxIndex; i++)
            {
                list.Add(Next(ref a, ref b));
            }

            return list;
        }

        private static long Next(ref long a, ref long b)
        {
            long sum = a + b;
            a = b;
            b = sum;
            return sum;
        }
    }
}
