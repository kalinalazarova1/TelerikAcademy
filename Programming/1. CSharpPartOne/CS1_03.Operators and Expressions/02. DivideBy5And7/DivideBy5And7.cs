//Write a boolean expression that checks for given integer
//if it can be divided (without remainder) by 5 and 7 at the same time;

using System;

class DivideBy5And7
{
    static void Main()
    {
        Console.WriteLine("Please input a number:");
        int i = Int32.Parse(Console.ReadLine());
        if ((i % 5) + (i % 7) == 0)
            Console.WriteLine("The number could be divided by 5 and 7 without a remainder.");
        else
            Console.WriteLine("The number could NOT be divided by 5 and 7 without a remainder.");
    }
}
