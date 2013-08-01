using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem_26
{
    static void Main()
    {
        string input = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        bool isOpenTag = false;
        StringBuilder result = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '<')
            {
                isOpenTag = true;
            }
            else if (input[i] == '>')
            {
                isOpenTag = false;
                if ((i < input.Length - 1) && (input[i + 1] != '<') && (result.Length != 0))
                {
                    result.Append(' ');
                }
            }
            else if (!isOpenTag && (Char.IsLetter(input[i]) || Char.IsPunctuation(input[i]) || Char.IsNumber(input[i]) || Char.IsWhiteSpace(input[i])))
            {
                result.Append(input[i]);
            }
        }
        Console.WriteLine(result);
    }
}
