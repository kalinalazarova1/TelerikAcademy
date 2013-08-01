using System;
using System.Text;

class Problem_4
{
    static void Main()
    {
        string s = "one\two\three";
        s = s.Replace("\t","*t");
        string[] splitted = s.Split('*');
        for (int i = 0; i < splitted.Length; i++)
        {
            Console.WriteLine(splitted[i]);
        }
    }
}
