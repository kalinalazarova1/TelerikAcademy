//Write a program to print the first 100 members the sequence of Fibonacci: 0,1,1,2,3,5,8,13,21,34,...

using System;
using System.Numerics;

class Fibonacchi100
{
    static void Main()
    {
        BigInteger fibN_2 = 0L;     //member n-2, use BigInteger, because ulong goes out of range
        BigInteger fibN_1 = 1L;     //member n-1
        BigInteger fibNumber;       //member n
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("{0,21}", fibN_2);
            fibNumber = fibN_2 + fibN_1;
            fibN_2 = fibN_1;
            fibN_1 = fibNumber;
        }
    }
}
