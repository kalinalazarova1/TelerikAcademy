//Write an expression that extracts from a given integer i the value of a given bit number b
// e.g. i = 5, b = 2 -> value = 1

using System;

class BitPositionPValue
{
    static void Main()
    {
        int mask = 1;
        Console.WriteLine("Please input a number:");
        int i = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input bit position starting from 0:");
        int b = Int32.Parse(Console.ReadLine());
        mask <<= b;
        Console.WriteLine("The bit {0} of the number {1} has a value: {2}", b, i, (i & mask) >> b);
    }
}
