//2. Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatenateFiles
{
    static void Main()
    {
        using (StreamReader reader1 = new StreamReader("test1.txt"))
        {
            using (StreamReader reader2 = new StreamReader("test2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("result.txt", true))
                {
                    writer.Write(reader1.ReadToEnd());
                    writer.Write(reader2.ReadToEnd());
                }
            }
        }
    }
}
