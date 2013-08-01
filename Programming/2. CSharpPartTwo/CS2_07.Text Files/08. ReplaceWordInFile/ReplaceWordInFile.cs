//8. Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;

class ReplaceWordInFile
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("input.txt"))
        {
            using (StreamWriter output = new StreamWriter("output1.txt"))
            {
                for (string line = input.ReadLine(); line != null; line = input.ReadLine())
                {
                    for (int index = line.IndexOf("start"); index != -1; index = line.IndexOf("start", index + 1))
                    {
                        if ((index - 1 < 0 || !Char.IsLetter(line[index - 1])) && (index + 5 >= line.Length || !Char.IsLetter(line[index + 5])))
                        {
                            line = line.Insert(index, "finish").Remove(index + 6, 5);
                        }
                    }
                    output.WriteLine(line);
                }
            }
        }
    }
}
