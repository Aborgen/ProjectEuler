using System;
using System.Numerics;

namespace ProjectEuler
{
    class Problem9
    {
        private enum Operation
        {
            SUM,
            PRODUCT
        }

        public BigInteger PythagoreanTripletProduct(int goal)
        {
            int a = 1;
            Tuple<int, int, int> specialSeries;
            while (true)
            {
                var seriesOrNull = InnerLoop(a, goal);
                if (seriesOrNull != null)
                {
                    specialSeries = seriesOrNull;
                    break;
                }

                if (a == int.MaxValue)
                {
                    throw new Exception("Hmm...");
                }

                a++;
            }

            BigInteger product = OperateOnSeries(specialSeries,
                Operation.PRODUCT);
            return product;
        }

        private Tuple<int, int, int> InnerLoop(int a, int goal)
        {
            // If a is 0 or less, c will never be greater than b.
            if (a < 1)
            {
                return null;
            }

            int b = a + 1;
            int c = FindHypotenuse(a, b);
            while (true)
            {
                var series = new Tuple<int, int, int>(a, b, c);
                var sum = OperateOnSeries(series, Operation.SUM);
                if (IsPythagoreanTriple(series) && sum == goal)
                {
                    return series;
                }

                if (sum > goal)
                {
                    break;
                }

                b++;
                c = FindHypotenuse(a, b);
            }

            return null;
        }

        private BigInteger OperateOnSeries(
            Tuple<int, int, int> series, Operation type)
        {
            var (a, b, c) = series;
            BigInteger total;
            switch (type)
            {
                case Operation.SUM:
                    total = a + b + c;
                    break;
                case Operation.PRODUCT:
                    total = a * b * c;
                    break;
                default:
                    total = -1;
                    break;
            }

            return total;
        }

        private int FindHypotenuse(int a, int b)
        {
            BigInteger c = (BigInteger) ( Math.Pow(a, 2) + Math.Pow(b, 2) );
            // https://docs.microsoft.com/en-us/dotnet/api/system.numerics.biginteger.log?view=netframework-4.7.2
            double square = Math.Exp(BigInteger.Log(c) / 2);
            return Convert.ToInt32(square);
        }

        private bool IsPythagoreanTriple(Tuple<int, int, int> series)
        {
            var (a, b, c) = series;
            return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
        }
    }
}
