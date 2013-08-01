//9. We are given a string containing a list of forbidden words and a text containing some of these
//words. Write a program that replaces the forbidden words with asterisks.
//Example: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
//Words: "PHP, CLR, Microsoft"
//The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Text;

class ReplaceForbiddenWords
{
    static void Main()
    {
        string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string forbiddenWords = "PHP, CLR, Microsoft";
        char[] separator = {' ',','};
        string[] forbidden = forbiddenWords.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        int forbiddenWordIndex = 0;
        for (int j = 0; j < forbidden.Length; j++)
        {
            for (int i = 0; i < input.Length; i  = forbiddenWordIndex + forbidden[j].Length)
            {
                forbiddenWordIndex = input.IndexOf(forbidden[j], i);
                if (forbiddenWordIndex != -1
                    && (forbiddenWordIndex - 1 == -1 || !Char.IsLetter(input[forbiddenWordIndex - 1]))
                    && (forbiddenWordIndex + forbidden[j].Length == input.Length || !Char.IsLetter(input[forbiddenWordIndex + forbidden[j].Length])))
                {
                    input = input.Replace(forbidden[j], new string('*', forbidden[j].Length));
                }
                else
                {
                    break;
                }
            }
        }
        Console.WriteLine(input);
    }
}
