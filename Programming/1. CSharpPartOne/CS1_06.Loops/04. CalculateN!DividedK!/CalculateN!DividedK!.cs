//Write a program that calculates N!/K! for given N and K (1 < K < N).

using System;
using System.Numerics;

class CalculateNFactDividedKFact
{
    static BigInteger GetFactoriel(BigInteger count)
    {
        BigInteger factoriel = 1;
        for (int i = 0; i < count; i++)
        {
            factoriel = factoriel * (i + 1);
        }
        return factoriel;
    }
    static void Main()
    {
        int n = 47;
        int k = 5;
        Console.WriteLine("N! / K! = {0}", GetFactoriel(n) / GetFactoriel(k));
    }
}
