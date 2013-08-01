using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem_24
{
    static void Main()
    {
        string input = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder result = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] != input[i + 1])
            {
                result.Append(input[i]);
            }  
        }
        result.Append(input[input.Length - 1]);
        Console.WriteLine(result);
    }
}
