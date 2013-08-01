//6. Write a program that reads a text file containing a list of strings, 
//sorts them and saves them to another text file. Example:
//
//      Ivan                George
//      Peter       ->      Ivan
//      Maria               Maria
//      George              Peter

using System;
using System.IO;

class SortStringsFromFile
{
    static void Main()
    {
        string[] arr;
        char[] separator = {'\n','\r',' '};
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            string all = reader.ReadToEnd();
            arr = all.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
        Array.Sort(arr);
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            for (int i = 0; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
        }
    }
}
