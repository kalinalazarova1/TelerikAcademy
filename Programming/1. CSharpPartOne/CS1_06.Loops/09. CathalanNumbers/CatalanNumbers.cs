//In the combinatorial mathematics the Catalan numbers are calculated by the following formula:
// Cn=(2n)!/(n+1)!n! for n>=0
//Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Numerics;


class CathalanNumbers
{
    static BigInteger GetFactoriel(uint start, uint end)
    {
        BigInteger factoriel = 1;
        for (uint i = start; i <= end; i++)
        {
            factoriel = factoriel * i;
        }
        return factoriel;
    }
    static void Main()              //The following transformation is used to increase the program efficiency:
    {                               // Cn=(2n)!/(n+1)!n!=
        uint n;                     //   =(n+1)!*((n+2)*(n+3)*..*2n)/(n+1)!n!=
        bool isValid;               //   =((n+2)*(n+3)*..*2n)/n!
        do
        {
            Console.WriteLine("Please input the number of the Catalan sequence member:");
            isValid = uint.TryParse(Console.ReadLine(), out n);
        }
        while (!isValid);
        Console.WriteLine("The {0} Catalan number is: {1}", n, GetFactoriel(n + 2, 2 * n) / GetFactoriel(1, n));
    }
}
