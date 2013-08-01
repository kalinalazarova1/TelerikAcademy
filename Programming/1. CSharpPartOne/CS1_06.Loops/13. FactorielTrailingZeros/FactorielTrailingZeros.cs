//*Write a program that calculates for given N how many trailing zeroes present
//at the end of the number N! Examples:
//  N = 10 -> 10! = 3628800 -> 2; 
//  N = 20 -> 20! = 2432902008176640000 -> 4;
//Does your program work for N = 50000;
//Hint: The trailing zeroes at the and of N! are equal to the number of its prime divisors of value 5. Think why!

using System;

class FactorielTrailingZeros
{
    static void Main()
    {
        int trailingZeros = 0;
        int n = 50000;
        for (int i = 5; (n / i) > 0; i *= 5)        //using the hint:
        {                                           //zeroes are calculated by the formula: n/5+n/5^2+n/5^3...while 5^n is not greater than n
            trailingZeros = trailingZeros + n / i;
        }
        Console.WriteLine("The number of trailing zeroes at the end of {0}! is: {1}", n, trailingZeros);
    }
}
