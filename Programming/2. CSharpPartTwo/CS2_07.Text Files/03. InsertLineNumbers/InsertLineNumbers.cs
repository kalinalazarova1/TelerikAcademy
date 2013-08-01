//3. Write a program that reads a text file and inserts line numbers in front
//of each of its lines. The result should be written to another text file.

using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("..\\..\\InsertLineNumbers.cs"))
        {
            using (StreamWriter writer = new StreamWriter("..\\..\\result.txt"))
            {
                string line = reader.ReadLine();
                for (int lineCount = 1; line != null; lineCount++)
                {
                    writer.WriteLine("{0}: {1}", lineCount, line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
