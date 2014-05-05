// 3. Write a program that counts how many times each word from given text file words.txt appears in it.
// The character casing differences should be ignored. The result words should be ordered by their number 
// of occurrences in the text. Example:
// "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?"
//  is -> 2 times
//  the -> 2 times
//  this -> 3 times
//  text -> 6 times

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    internal static void Main()
    {
        var reader = new StreamReader(@"..\..\words.txt");
        char[] separators = { ' ', '.', ',', '!', '?', '–' };

        using (reader)
        {
            string all = reader.ReadToEnd();
            string[] words = all.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var result = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (result.ContainsKey(words[i].ToLower()))
                {
                    result[words[i].ToLower()]++;
                }
                else
                {
                    result[words[i].ToLower()] = 1;
                }
            }

            foreach (var item in result.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} -> {1} {2}", item.Key, item.Value, item.Value == 1 ? "time" : "times");
            }
        }
    }
}
