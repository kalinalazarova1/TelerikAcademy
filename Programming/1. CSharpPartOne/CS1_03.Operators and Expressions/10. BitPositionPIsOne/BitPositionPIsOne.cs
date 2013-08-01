//Write a boolean expression that returns if the bit at position p (counting from 0) of
//a given integer number v has a value 1. e.g. v=5, p=1 -> false

using System;

class BitPositionPIsOne
{
    static void Main()
    {
        int mask = 1;       
        Console.WriteLine("Please input a number:");
        int v = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input bit position starting from 0:");
        int p = Int32.Parse(Console.ReadLine());
        mask <<= p;
        Console.WriteLine("The bit {0} of the number {1} is 1: {2}", p, v, ((v & mask) >> p) == 1);
    }
}
