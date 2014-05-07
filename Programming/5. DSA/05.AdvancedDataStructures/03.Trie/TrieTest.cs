// 3. Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
// Print how many times each word occurs in the text.
// Hint: you may find a C# trie in Internet.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

internal class Program
{
    internal static void Main()
    {
        string[] separators = { " ", ",", ".", "!", "?", "\"", "/", "[", "]", "{", "}", "(", ")", ":", ";", "|", "<", ">", "*", "\t", "-", "_" };
        var keywords = new Trie(new TrieNode('#'));
        var wordsReader = new StreamReader(@"..\..\keywords.txt");
        var textReader = new StreamReader(@"..\..\text.txt");
        var writer = new StreamWriter(@"../../output1.txt");
        var result = new Dictionary<string, int>();
        string all;
        var time = new Stopwatch();

        // first variant builds trie from the keywords and checks each word from the text if it is present in the Trie
        time.Start();
        using (wordsReader)
        {
            for (var w = wordsReader.ReadLine(); w != null; w = wordsReader.ReadLine())
            {
                keywords.Add(w.ToLower());
            }
        }

        using (textReader)
        {
            all = textReader.ReadToEnd().ToLower();
        }

        StringBuilder word = new StringBuilder();
        for (int i = 0; i < all.Length; i++)
        {
            if (char.IsLetter(all[i]))
            {
                word.Append(all[i]);
            }
            else
            {
                if (keywords.Contains(word.ToString()))
                {
                    if (result.ContainsKey(word.ToString()))
                    {
                        result[word.ToString()]++;
                    }
                    else
                    {
                        result[word.ToString()] = 1;
                    }
                }

                word.Clear();
            }
        }

        using (writer)
        {
            writer.Write(string.Join(Environment.NewLine, result));
        }

        time.Stop();
        Console.WriteLine("Elapsed time in seconds: {0:0.0000}", time.ElapsedMilliseconds / 1000f);

        // Second variant bilds a Trie with the text and checks each keyword in it - 3 times slower due to too large trie
        time.Reset();

        var text = new Trie(new TrieNode('#'));
        time.Start();

        int wordCount = 0;
        textReader = new StreamReader(@"..\..\text.txt");
        using (textReader)
        {
            all = textReader.ReadToEnd().ToLower();
            for (int i = 0; i < all.Length; i++)
            {
                if (char.IsLetter(all[i]))
                {
                    word.Append(all[i]);
                }
                else
                {
                    text.Add(word.ToString());
                    word.Clear();
                }
            }
        }

        word.Clear();
        writer = new StreamWriter(@"../../output2.txt");
        wordsReader = new StreamReader(@"..\..\keywords.txt");
        using (wordsReader)
        {
            using (writer)
            {
                for (var w = wordsReader.ReadLine(); w != null; w = wordsReader.ReadLine())
                {
                    if (text.TryFindCount(w.ToLower(), out wordCount))
                    {
                        writer.WriteLine("[{0}, {1}]", w, wordCount);
                    }
                }
            }
        }

        time.Stop();
        Console.WriteLine("Elapsed time in seconds: {0:0.0000}", time.ElapsedMilliseconds / 1000f);
        time.Reset();
    }
}