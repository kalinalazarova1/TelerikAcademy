using System;
using System.Text;

class Problem_14
{
    static string ReverseString(string s)
    {
        StringBuilder sb = new StringBuilder(s.Length);
        for (int i = s.Length - 1; i >= 0; i--)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }

    static void Main()
    {
        string input = "C# is not C++ and PHP is not Delphi";
        input = ReverseString(input);
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            Console.Write("{0} ", ReverseString(words[i]));
        }
        Console.WriteLine();
    }
}
