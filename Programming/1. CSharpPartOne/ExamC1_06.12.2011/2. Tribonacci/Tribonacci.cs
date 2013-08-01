using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger tribMinus3 = BigInteger.Parse(Console.ReadLine());
        BigInteger tribMinus2 = BigInteger.Parse(Console.ReadLine());
        BigInteger tribMinus1 = BigInteger.Parse(Console.ReadLine());
        BigInteger tribCurrent;
        ushort n = ushort.Parse(Console.ReadLine());
        for (ushort i = 1; i < n; i++)
        {
            tribCurrent = tribMinus3 + tribMinus2 + tribMinus1;
            tribMinus3 = tribMinus2;
            tribMinus2 = tribMinus1;
            tribMinus1 = tribCurrent;
        }
        Console.WriteLine(tribMinus3);
    }
}

