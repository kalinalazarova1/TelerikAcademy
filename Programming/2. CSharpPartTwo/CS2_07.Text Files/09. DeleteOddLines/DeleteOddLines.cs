//9. Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        StringBuilder text = new StringBuilder();
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            int lineNumber = 1;
            for (string line = reader.ReadLine(); line != null; lineNumber++, line = reader.ReadLine())
            {
                if ((lineNumber & 1) == 0)
                {
                    text.AppendLine(line);
                }
            }
        }
        using (StreamWriter writer = new StreamWriter("test.txt"))
        {
            writer.Write(text);
        }
    }
}
