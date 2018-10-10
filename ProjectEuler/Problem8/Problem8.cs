using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Problem8
    {
        public BigInteger LargestProductInSeries(int subSeriesLength)
        {
            var r = new StreamReader("Problem8/1000Digits.txt");
            string line = r.ReadLine();
            r.Close();
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new Exception("1000Digits.txt seems to be empty!");
            }

            var series = line.Select(n => int.Parse(n.ToString())).ToList();
            var product = ShuffleSubSeriesProduct(series, subSeriesLength);
            return product;
        }

        private BigInteger ShuffleSubSeriesProduct(List<int> series, int offset)
        {
            BigInteger largestProduct = 0;
            int length = series.Count - offset;
            for (int i = 0; i <= length; i++)
            {
                var subSeries = series.GetRange(i, offset);
                BigInteger product = ProductOfSeries(subSeries);
                if (product > largestProduct)
                {
                    largestProduct = product;
                }
            }

            return largestProduct;
        }
        private BigInteger ProductOfSeries(List<int> series)
        {
            BigInteger product = 1;
            series.ForEach( n => product *= n );
            return product;
        }
    }
}
