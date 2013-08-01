using System;
using System.Text;

class Problem_9
{
    static void Main()
    {
        Console.WriteLine("Please input a string for coding:");
        string input = Console.ReadLine();
        Console.WriteLine("Please input a key for coding:");
        string key = Console.ReadLine();
        StringBuilder codedInput = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            codedInput.Append((char)(input[i] ^ key[i % key.Length]));
            Console.Write("\\u{0:x4}",(ushort)codedInput[i]);
        }
        Console.WriteLine();
    }
}
