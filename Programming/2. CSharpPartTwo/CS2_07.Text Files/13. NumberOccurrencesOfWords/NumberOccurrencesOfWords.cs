//13. Write a program that reads a list of words from a file words.txt and finds how many times
//each of the words is contained in another file test.txt. 
//The result should be written in the file result.txt and 
//the words should be sorted by the number of their occurrences in descending order.
//Handle all possible exceptions in your methods.

using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Security;

class NumberOccurrencesOfWords
{
    static string[] GetWords(string text)
    {
        char[] separator = {' ','.',',','!','?','-',':',';','"','(',')','\t','\r','\n' };
        string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return words;
    }

    static void Main()
    {
        try
        {
            string[] words = GetWords(File.ReadAllText("words.txt"));
            int[] counts = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                counts[i] = Regex.Matches(File.ReadAllText("test.txt"), string.Format(@"\b{0}\b", words[i])).Count;
            }
            Array.Sort(counts, words);
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                for (int i = words.Length - 1; i >=0 ; i--)
                {
                    writer.WriteLine("{0}: {1} times", words[i], counts[i]);
                }
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (RegexMatchTimeoutException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
