//6. Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinToHex
{
    /*static void Main()                //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input binary number:");
        Console.WriteLine(Convert.ToString(Convert.ToInt64(Console.ReadLine(), 2),16).ToUpper());
    }*/

    static void Main()
    {
        char[] hexDigits = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
        string[] binDigits = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        Console.WriteLine("Please input binary number:");
        string bin = Console.ReadLine();
        Console.WriteLine("The hexadecimal representation is: ");
        bin = bin.Insert(0,new string('0', (4 - bin.Length % 4) % 4));      //adds zeroes at the begining of the binary number in order to reach digit count divisible by 4
        for (int i = 0; i < bin.Length; i += 4)
        {
            Console.Write(hexDigits[Array.IndexOf(binDigits, string.Format("{0}{1}{2}{3}", bin[i], bin[i + 1], bin[i + 2], bin[i + 3]))]);
        }
        Console.WriteLine();
    }
}
