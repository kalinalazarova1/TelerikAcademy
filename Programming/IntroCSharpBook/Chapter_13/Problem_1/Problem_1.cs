using System;
using System.Text;

class Problem_1
{
    static void Main()
    {
        Console.WriteLine("Please input a string:");
        
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder(input.Length);
        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            sb.Append(input[i]);
        }
        Console.WriteLine(sb);
    }
}
