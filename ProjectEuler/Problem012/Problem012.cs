using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler
{
    class Problem012
    {
        public int? FindUniqueTriangleDivisors(int upperLimit)
        {
            var triangleGen = new TriangleNumber();
            var factorization = new FactorizationStation();
            int divisors = 0;
            int triangle = 0;
            while (divisors < upperLimit)
            {
                triangleGen.Next();
                var nextTriangle = triangleGen.GetSum();
                if (nextTriangle > int.MaxValue)
                {
                    return null;
                }

                triangle = (int)nextTriangle;
                divisors = factorization.FindUniqueDivisors(triangle).Count;
            }

            return triangle;
        }
    }
}
