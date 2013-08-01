//15.Write a program that finds all prime numbers in the range [1...10 000 000]. Use
//the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class PrimeNumbersSieveEratosthenes
{
    static void Main()
    {
        int maxValue = 10000000;
        bool[] isDivisible = new bool[maxValue + 1];
        isDivisible[0] = isDivisible[1] = true;
        for (int i = 2; i <= Math.Sqrt(maxValue); i++)
        {
            if (!isDivisible[i])
            {
                for (int j = i + i; j <= maxValue; j += i)
                {
                    isDivisible[j] = true;
                }
            }
        }
        for (int i = 0; i < 20000; i++)       //prints only the first 20000, because the prime numbers are too many
        {
            if (!isDivisible[i])
            {
                Console.Write("{0}, ", i);
            }
        }
    }
}
