//2. Write a program to convert binary numbers to their decimal representation.

using System;

class BinToDecimal
{
    /*static void Main()            //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input binary number:");
        Console.WriteLine(Convert.ToInt64(Console.ReadLine(), 2));
    }*/

    static void Main()          //this conversion uses a string to store the binary number
    {
        long decNumber = 0;
        long powerOfTwo = 1;
        Console.WriteLine("Please input binary number:");
        string bin = Console.ReadLine();
        Console.Write("The decimal equivalent is: ");
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            if (bin[i] == '1')
            {
                decNumber += powerOfTwo;
            }
            powerOfTwo *= 2;
        }
        Console.Write(decNumber);
        Console.WriteLine();
    }
}
