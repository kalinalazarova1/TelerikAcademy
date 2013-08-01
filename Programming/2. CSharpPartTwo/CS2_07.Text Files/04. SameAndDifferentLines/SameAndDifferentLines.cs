//4. Write a program that compares two text files line by line and prints the number 
//of lines that are the same and the number of lines that are different. 
//Assume the files have equal number of lines.

using System;
using System.Text;
using System.IO;

class SameAndDifferentLines
{
    static void Main()
    {
        int sameLines = 0;
        int differentLines = 0;
        using (StreamReader reader1 = new StreamReader("test1.txt"))
        {
            using (StreamReader reader2 = new StreamReader("test2.txt"))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();
                for (; line1 != null || line2 != null; line1 = reader1.ReadLine(), line2 = reader2.ReadLine())
                {
                    if (line1 == line2)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                }
            }  
        }
        Console.WriteLine("Same lines count: {0}, Different lines count: {1}", sameLines, differentLines);
    }
}
