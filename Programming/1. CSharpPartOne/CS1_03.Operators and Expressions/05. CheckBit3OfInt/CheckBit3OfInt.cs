//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 0 or 1.

using System;

class CheckBit3OfInt
{
    static void Main()
    {
        int pos = 3;        //position of the checked bit
        int mask = 1;
        mask <<= pos;
        Console.WriteLine("Please input a number:");
        int i = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The bit {0} of the number {1} is: {2}", pos, i, (i & mask) >> pos);
    }
}
