//22. Write a program that reads a string from the console and lists all different words in the string
//along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractWordsFromString        //this version uses dictionary<>, linq and regular expression
{
    static void Main()
    {
        string text = "The palindrom is a word that is the same when is read backwards. For example: level or pop. Of course the total list could be quite long especially when include my word appa and laval. Laval actually means nothing.";
        MatchCollection words = Regex.Matches(text.ToLower(), @"\b\w+\b");
        string[] singleWords = new string[words.Count];
        Dictionary<string, int> allWords = new Dictionary<string, int>();
        foreach (Match word in words)
        {
            if(allWords.ContainsKey(word.Value))
            {
                allWords[word.Value]++;
            }
            else
            {
                allWords.Add(word.Value, 1);
            }
        }
        foreach (var word in allWords.OrderByDescending(k => k.Value))
        {
            Console.WriteLine("{0} is found {1} times.", word.Key, word.Value);
        }
    }
}
