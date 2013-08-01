//Write an expression that checks if given integer is odd or even

using System;

class OddOrEvenInt
{
    static void Main()
    {
        Console.WriteLine("Please input a number:");
        int i = Int32.Parse(Console.ReadLine());
        if ((i & 1) == 0)
            Console.WriteLine("The number is even.");
        else
            Console.WriteLine("The number is odd.");
    }
}
