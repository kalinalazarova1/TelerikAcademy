//We are given integer number n, value v (0 or 1) and a position p. Write a sequence of operators
//that modifies n to hold the value v on a position p from the binary representation of n
//e.g. n=5, p=3, v=1 -> 13, n=5, p=2, v=0 -> 1

using System;

class ChangeBitPositionP
{
    static void Main()
    {
        int mask = 1; 
        Console.WriteLine("Please input a number:");
        int n = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input bit position starting from 0:");
        int p = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input a value of the bit:");
        int v = Int32.Parse(Console.ReadLine());
        mask <<= p;
        if (((n & mask) >> p) != v)         //checks if the bit on position p is equal to v
            n ^= mask;
        Console.WriteLine("The new number is: {0}", n);
    }
}
