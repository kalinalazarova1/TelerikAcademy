//1. Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class WriteToFileOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("test.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            for (int lineCount = 1; line != null; lineCount++)
            {
                if ((lineCount & 1) == 1)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
            }
        }
    }
}
