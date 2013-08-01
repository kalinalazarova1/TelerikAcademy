//7.  Write a program that replaces all occurrences of the substring "start"
//with the substring "finish" in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;

class ReplaceSubstringInFile
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("input.txt"))
        {
            using (StreamWriter output = new StreamWriter("output.txt"))
            {
                for (string line = input.ReadLine(); line != null; line = input.ReadLine())
                {
                    output.WriteLine(line.Replace("start", "finish"));
                }
            }
        }
    }
}
