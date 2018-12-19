using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Utils
{
    public interface INumberGenerator
    {
        int CurrentNumber { get; }

        List<BigInteger> GenerateList(int length);
        BigInteger NthNumber(int index);
        void Next();
    }
}