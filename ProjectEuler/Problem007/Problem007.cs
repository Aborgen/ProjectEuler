using ProjectEuler.Utils;

namespace ProjectEuler
{
    class Problem007
    {
        public int NthPrime(int index)
        {
            int prime = 0;
            for (int i = 0; i < index; i++)
            {
                PrimeGen.Next(ref prime);
            }

            return prime;
        }
    }
}
