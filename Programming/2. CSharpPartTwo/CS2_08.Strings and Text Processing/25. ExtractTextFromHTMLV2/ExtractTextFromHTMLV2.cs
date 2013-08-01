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
using System.Text.RegularExpressions;

class ExtractTextFromHTMLV2                     //this version uses regular expressions
{
    static void Main()
    {
        string input = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
        MatchCollection partitions = Regex.Matches(input, @"(?<=>).*?(?=<)");  //matches the text between > and <, but excludes them;
        foreach (Match partition in partitions)
        {
            if (partition.Value != "")
            {
                Console.WriteLine(partition);
            }
        }
    }
}
