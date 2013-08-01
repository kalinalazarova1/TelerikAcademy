//Write an expression that checks for given integer if its third digit (right to left) is 7
//e.g. 1732 -> true

using System;

class ThirdDigit7Check
{
    static void Main()
    {
        Console.WriteLine("Please input a number:");
        int i = Int32.Parse(Console.ReadLine());
        Console.WriteLine(Math.Abs((i / 100) % 10) == 7);   //Math.Abs is used for corect result when the int is less than 0
    }
}
