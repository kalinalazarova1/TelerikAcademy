//10. Write a program that converts a string to a sequence of C# Unicode character literals. 
//Use format strings.
//Sample input: "Hi!".
//Expected output: "\u0048\u0069\u0021".

using System;
using System.Text;

class ConvertToUnicodeChar
{
    static void Main()
    {
        string input = "Hi!";
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            result.Append(string.Format("\\u{0:x4}", (ushort)input[i]));
        }
        Console.WriteLine(result);
    }
}
