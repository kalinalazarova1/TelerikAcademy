//Write a program that calculates N!*K!/(K - N)! for given N and K (1 < N < K).

using System;
using System.Numerics;

class CalculateNFactKFactDividedDiffKNFact
{
    static BigInteger GetFactoriel(int start, int end)   //this program returns the product of all the numbers from start to end
    {
        BigInteger factoriel = 1;
        for (int i = start; i <= end; i++)
        {
            factoriel = factoriel * i;
        }
        return factoriel;
    }

    static void Main()  //N!*K!/(K-N)!=N!(K-N)!*(K-N+1*K-N+2*...*K)/(K-N)!=N!*(K-N+1*K-N+2*...*K) because (K-N)! eliminate each other
    {                   //this saves the double calculation of (K-N)! and improves the efficiency of the program
        int n = 3;
        int k = 6;
        Console.WriteLine("N! * K! / (K - N)! = {0}", GetFactoriel(1, n) * GetFactoriel(k - n + 1, k)); 
    }
}
