//7. Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. The encoding/decoding is done by performing
//XOR (exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;

class CodeDecodeString
{
    static void Main()
    {
        Console.WriteLine("Please input a string for coding:");
        string input = Console.ReadLine();
        Console.WriteLine("Please input a key for coding:");
        string key = Console.ReadLine();
        StringBuilder codedInput = new StringBuilder();
        StringBuilder decodedInput = new StringBuilder();
        Console.Write("Coded string: ");
        for (int i = 0; i < input.Length; i++)
        {
            codedInput.Append((char)(input[i] ^ key[i % key.Length]));
            Console.Write(codedInput[i]);
        }
        Console.WriteLine();
        Console.Write("Decoded string: ");
        for (int i = 0; i < input.Length; i++)
        {
            decodedInput.Append((char)(codedInput[i] ^ key[i % key.Length]));
            Console.Write(decodedInput[i]);
        }
        Console.WriteLine();

    }
}
