//25. Write a program that extracts from given HTML file its title
//(if available), and its body text without the HTML tags. Example:
 //   <html>
 //     <head><title>News</title></head>
 //     <body><p><a href="http://academy.telerik.com">TelerikAcademy</a>
 //       aims to provide free real-world practical
 //       training for young people who want to turn into
 //       skillful .NET software engineers.</p></body>
 //   </html>

using System;
using System.Text;

class ExtractTextFromHTML
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
                    result.Append('\n');
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
