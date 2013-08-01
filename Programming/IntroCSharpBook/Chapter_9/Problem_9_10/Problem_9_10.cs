using System;
using System.Numerics;

class Problem_9_10
{
    static BigInteger GetFactoriel(int n)
    {
        BigInteger factoriel = 1;
        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
        }
        return factoriel;
    }
    static void Main()
    {
        Console.WriteLine("Please input number between 1 and 100:");
        int n = Int32.Parse(Console.ReadLine());
        Console.WriteLine("{0}! = {1}", n, GetFactoriel(n)); 
    }
}
