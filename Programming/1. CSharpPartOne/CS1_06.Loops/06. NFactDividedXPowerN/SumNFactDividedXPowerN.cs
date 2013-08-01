//Write a program that, for a given two integer number N and X, calculates the sum S=1+1!/X+2!/X^2+...+N!/X^N

using System;
using System.Numerics;

class SumNFactDividedXPowerN
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
        int n = 3;
        int x = 5;
        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum = sum + (double)GetFactoriel(i) / Math.Pow(x, i);
        }
        Console.WriteLine("The sum S=1+1!/X+2!/X^2+...+N!/X^N for N={0} and X={1} is: {2}", n, x, sum);
    }
}
