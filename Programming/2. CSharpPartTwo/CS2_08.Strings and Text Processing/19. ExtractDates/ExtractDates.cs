//19.  Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.


using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        
        string text = @"I was born at 14.06.1980. My sister was born at 03.07.1984. In 5/1999 I graduated my high school. The law says (see section 77.13.1112) that we are allowed to do this (section 7.4.2.9).";
        string pattern = @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}";
        MatchCollection dates = Regex.Matches(text, pattern);
        foreach (Match date in dates)
        {
            DateTime currentDate;
            if (DateTime.TryParseExact(date.Value.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentDate))
            {
                Console.WriteLine(currentDate.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }
}
