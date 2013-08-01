//4. Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexToDecimal
{
    /*static void Main()            //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input hexadecimal number:");
        Console.WriteLine(Convert.ToInt64(Console.ReadLine(), 16));
    }*/

    static void Main()
    {
        long decNumber = 0;
        long powerOfSixteen = 1;
        Console.WriteLine("Please input heximal number:");
        string hex = Console.ReadLine();
        Console.Write("The decimal equivalent of {0} is: ", hex);
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            switch (hex[i])
            {
                case '0': break;
                case '1': decNumber += powerOfSixteen * 1; break;
                case '2': decNumber += powerOfSixteen * 2; break;
                case '3': decNumber += powerOfSixteen * 3; break;
                case '4': decNumber += powerOfSixteen * 4; break;
                case '5': decNumber += powerOfSixteen * 5; break;
                case '6': decNumber += powerOfSixteen * 6; break;
                case '7': decNumber += powerOfSixteen * 7; break;
                case '8': decNumber += powerOfSixteen * 8; break;
                case '9': decNumber += powerOfSixteen * 9; break;
                case 'A': decNumber += powerOfSixteen * 10; break;
                case 'B': decNumber += powerOfSixteen * 11; break;
                case 'C': decNumber += powerOfSixteen * 12; break;
                case 'D': decNumber += powerOfSixteen * 13; break;
                case 'E': decNumber += powerOfSixteen * 14; break;
                case 'F': decNumber += powerOfSixteen * 15; break;
            }
            powerOfSixteen *= 16;
        }
        Console.Write(decNumber);
        Console.WriteLine();

    }
}
