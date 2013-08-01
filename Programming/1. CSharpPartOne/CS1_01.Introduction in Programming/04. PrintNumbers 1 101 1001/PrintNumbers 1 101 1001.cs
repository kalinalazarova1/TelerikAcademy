using System;

class PrintNumbers_1_101_1001   //Print the numbers 1, 101 and 1001
{
    static void Main()
    {
        int i = 1;
        Console.WriteLine(i);
        for (i = 100; i <= 1000; i *= 10)
        {
            Console.WriteLine(i + 1);
        }
    }
}

