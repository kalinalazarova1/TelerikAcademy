//24. Write a program that reads a list of words, separated by spaces and prints the 
//list in an alphabetical order.

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class SortListOfWords
{
    static void Main()
    {
        string input = "write program reads list words separated spaces prints alphabetical order";
        string[] words = input.Split(' ');
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
