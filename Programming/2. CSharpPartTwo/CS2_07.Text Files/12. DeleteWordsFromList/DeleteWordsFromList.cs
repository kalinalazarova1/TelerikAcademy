//12. Write a program that removes from a text file all words listed in given another text file. 
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

class DeleteWordsFromList
{
    static void Main()
    {
        try
        {
            using (StreamReader list = new StreamReader("list.txt"))
            {
                for (string word = list.ReadLine(); word != null; word = list.ReadLine())   //the format of the listed words is not define, so I assume the file contains one word on each line
                {
                    using (StreamWriter output = new StreamWriter("test.tmp"))
                    {
                        using (StreamReader input = new StreamReader("test.txt"))
                        {
                            for (string line = input.ReadLine(); line != null; line = input.ReadLine())
                            {
                                output.WriteLine(Regex.Replace(line, string.Format("\\b{0}\\b", word), ""));
                            }
                        }
                    }
                    File.Copy("test.tmp", "test.txt", true);
                    File.Delete("test.tmp");
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentException e)
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
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ObjectDisposedException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
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
