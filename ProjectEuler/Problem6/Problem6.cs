using System;

namespace ProjectEuler
{
    class Problem6
    {
        private enum Type
        {
            SUM_OF_SQUARES,
            SQUARE_OF_SUMS
        };

        public int SumSquareDifference(int upperBound)
        {
            int squareSums  = RecursiveSum(upperBound, Type.SUM_OF_SQUARES);
            int sumsSquared = RecursiveSum(upperBound, Type.SQUARE_OF_SUMS);
            return sumsSquared - squareSums;
        }

        private int RecursiveSum(int upperBound, Type type)
        {
            int total = 0;
            if (type == Type.SUM_OF_SQUARES)
            {
                for (int i = 1; i <= upperBound; i++)
                {
                    double squared = Math.Pow(i, 2);
                    total += Convert.ToInt32(squared);
                }
            }
            else
            {
                for (int i = 1; i <= upperBound; i++)
                {
                    total += i;
                }

                double squared = Math.Pow(total, 2);
                total = Convert.ToInt32(squared);
            }
            
            return total;
        }
    }
}
