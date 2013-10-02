using System;
using System.Collections.Generic;
using System.Text;

class Crossword
{
    static bool IsValid(string[] crossword, List<string> words)
    {
        StringBuilder vert = new StringBuilder(crossword.Length);
        for (int i = 0; i < crossword.Length; i++)
        {
            for (int j = 0; j < crossword.Length; j++)
            {
                vert.Append(crossword[j][i]);
            }
            if (words.IndexOf(vert.ToString()) < 0) return false;
            vert.Clear();
        }
        return true;
    }

    static void GetCrossword(string[] crossword, List<string> words, int start)
    {
        if (start >= crossword.Length)
        {
            if (IsValid(crossword, words))
            {
                for (int i = 0; i < crossword.Length; i++)
                {
                    Console.WriteLine(crossword[i]);
                }
                Environment.Exit(0);
            }
            return;
        }
        foreach (string word in words)
        {
            crossword[start] = word;
            GetCrossword(crossword, words, start + 1);
        }
    }

    static void Main()
    {
        List<string> words = new List<string>();
        int n = int.Parse(Console.ReadLine());
        string[] crossword = new string[n];
        for (int i = 0; i < n * 2; i++)
        {
            words.Add(Console.ReadLine());
        }
        words.Sort();
        GetCrossword(crossword, words, 0);
        Console.WriteLine("NO SOLUTION!");
    }
}
