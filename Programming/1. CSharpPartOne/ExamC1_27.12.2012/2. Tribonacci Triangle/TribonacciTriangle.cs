using System;
using System.Numerics;

class TribonacciTriangle
{
    static void Main()
    {
        BigInteger[] tribonacci = new BigInteger[213];
        tribonacci[0] = BigInteger.Parse(Console.ReadLine());
        tribonacci[1] = BigInteger.Parse(Console.ReadLine());
        tribonacci[2] = BigInteger.Parse(Console.ReadLine());
        int lines = int.Parse(Console.ReadLine());
        for (int i = 1; i <= lines; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                tribonacci[j + (i * (i - 1)) / 2 + 2] = tribonacci[j + 1 + (i * (i - 1)) / 2] + tribonacci[j + (i * (i - 1)) / 2] + tribonacci[j - 1 + (i * (i - 1)) / 2];
                if (j != i)
                {
                    Console.Write("{0} ", tribonacci[j - 1 + (i * (i - 1)) / 2]);
                }
                else
                {
                    Console.Write("{0}", tribonacci[j - 1 + (i * (i - 1)) / 2]);
                }
            }
            Console.WriteLine();
        }
    }
}