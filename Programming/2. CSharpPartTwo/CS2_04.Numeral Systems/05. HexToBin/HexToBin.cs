//5. Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexToBin
{
    /*static void Main()                //this is alternative solution of the problem;
    {
        Console.WriteLine("Please input hexadecimal number:");
        Console.WriteLine(Convert.ToString(Convert.ToInt64(Console.ReadLine(), 16),2));
    }*/

    static void Main()
    {
        char[] hexDigits = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
        string[] binDigits = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        Console.WriteLine("Please input hexadecimal number:");
        string hex = Console.ReadLine();
        Console.WriteLine("The hexadecimal representation is: ");
        for (int i = 0; i < hex.Length; i++)
        {
            Console.Write(binDigits[Array.IndexOf(hexDigits, hex[i])]);
        }
        Console.WriteLine();
    }
}
