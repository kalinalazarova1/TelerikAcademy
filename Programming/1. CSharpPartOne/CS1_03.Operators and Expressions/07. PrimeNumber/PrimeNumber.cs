//Write an expression that checks if given positive integer number n <= 100 is prime. e.g. 37 is prime

using System;

class PrimeNumber
{
    static void Main()
    {
        bool primeNumber = true;
        byte n;
        do
        {
            Console.WriteLine("Please input positive number equal or less than 100:");
            n = byte.Parse(Console.ReadLine());
        }
        while ((n < 0) || (n > 100));
        if ((n & 1) == 0 || (n % 3) == 0 || (n % 5) == 0 ||(n % 7) == 0)          
            primeNumber = false;
        Console.WriteLine(primeNumber ? "The number is prime" : "The number is not prime");
    }
}