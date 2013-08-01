//13. Write a program that reverses the words in given sentence. Example:
//C# is not C++, not PHP and not Delphi!
//Delphi not and PHP, not C++ not is C#!

using System;
using System.Text;

class ReverseWordsInSentence
{
    static bool isWord(char[] punctuation, char c)
    {
        return Array.IndexOf(punctuation, c) < 0 ? true : false;
    }

    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi!";
        StringBuilder result = new StringBuilder(input.Length);
        char[] separator = {'!','-',',','.','\"',':',';','?',' '};
        string[] words = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        int wordIndex = words.Length - 1;
        for (int i = 0; i < input.Length; i++)
        {
            if (isWord(separator, input[i]))
            {
                result.Append(words[wordIndex]);
                wordIndex--;
                while (i < input.Length && isWord(separator, input[i]))
                {
                    i++;
                }
            }
            result.Append(input[i]);
        }
        Console.WriteLine(result);
    }
}
