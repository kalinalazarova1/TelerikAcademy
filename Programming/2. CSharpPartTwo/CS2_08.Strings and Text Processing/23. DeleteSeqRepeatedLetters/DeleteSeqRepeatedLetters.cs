//23. Write a program that reads a string from the console and replaces all series of
//consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

using System;
using System.Text;

class DeleteSeqRepeatedLetters
{
    static void Main()
    {
        string input = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder output = new StringBuilder();
        output.Append(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1] || !Char.IsLetter(input[i]))
            {
                output.Append(input[i]);
            }
        }
        Console.WriteLine(output);
    }
}
