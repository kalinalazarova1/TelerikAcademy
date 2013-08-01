//22. Write a program that reads a string from the console and lists all different words in the string
//along with information how many times each word is found.

using System;

class ExtractWordsFromStringV2
{
    static void Main()          //this version uses only arrays;
    {
        string previousWord = string.Empty;
        uint wordCount = 1;
        string text = "The palindrom is a word that is the same when is read backwards. For example: level or pop. Of course the total list could be quite long especially when include my word appa and laval. Laval actually means nothing.";
        char[] separator = { ' ', '.', ':', ',', ';', '!', '?', '"' };
        text = text.ToLower();
        string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i - 1] != words[i])
            {
                Console.WriteLine("{0} is found {1} times.", words[i - 1], wordCount);
                if (i == words.Length - 1)
                {
                    Console.WriteLine("{0} is found 1 time.", words[i]);
                }
                wordCount = 1;
            }
            else
            {
                wordCount++;
                if (i == words.Length - 1)
                {
                    Console.WriteLine("{0} is found {1} times.", words[i], wordCount);
                }
            }
        }

    }
}
