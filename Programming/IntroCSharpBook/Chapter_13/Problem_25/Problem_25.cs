using System;
using System.Text;

class Problem_25
{
    static void Main()
    {
        char[] separators = {' ', ','};
        Console.WriteLine("Please input a list of words separated by commas:");
        string input = Console.ReadLine();
        string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}
