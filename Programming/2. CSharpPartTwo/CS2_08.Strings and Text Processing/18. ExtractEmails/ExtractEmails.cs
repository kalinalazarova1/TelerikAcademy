//18. Write a program for extracting all email addresses from given text. All substrings that match
//the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
        string pattern = @"([a-zA-Z0-9_]+([\.a-zA-Z0-9_\-]){0,49})@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+[a-zA-Z]{2,4})";
        MatchCollection emails = Regex.Matches(text, pattern);
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }

    }
}
