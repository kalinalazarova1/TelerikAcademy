using System;
using System.Text;

class Problem_8
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] symbols = input.ToCharArray();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < symbols.GetLength(0); i++)
        {
            result.Append(string.Format("\\u{0:x4}", (ushort)symbols[i]));
        }
        Console.WriteLine(result);
    }
}
