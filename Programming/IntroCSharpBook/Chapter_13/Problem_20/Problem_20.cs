using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

class Problem_20
{
    static void Main()
    {
        string text = @"I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
        string pattern = @"[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{4}\.";
        MatchCollection dates = Regex.Matches(text, pattern);
        foreach (var date in dates)
        {
            Console.WriteLine("{0}",date);
        }
    }
}
