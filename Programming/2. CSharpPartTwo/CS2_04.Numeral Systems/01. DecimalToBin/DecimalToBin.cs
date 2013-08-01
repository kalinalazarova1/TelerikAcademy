//1. Write a program to convert decimal numbers to their binary representation.

using System;

class DecimalToBin
{
    /*static void Main()            //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input decimal number:");
        Console.WriteLine(Convert.ToString(Int32.Parse(Console.ReadLine()), 2));
    }*/

    static void Main()              //this conversion uses array to store the binary number;
    {
        int decNumber;
        int[] arr = new int[32];
        int i;
        Console.WriteLine("Please input decimal number:");
        decNumber = Int32.Parse(Console.ReadLine());
        Console.Write("The binary equivalent of {0} is: ", decNumber);
        for (i = 0; decNumber > 0; i++)
        {
            arr[i] = decNumber % 2;
            decNumber /= 2;
        }
        while (i > 0)
        {
            i--;
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }
}
