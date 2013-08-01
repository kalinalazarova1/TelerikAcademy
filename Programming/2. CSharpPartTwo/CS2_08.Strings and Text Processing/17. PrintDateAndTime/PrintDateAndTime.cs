//17. Write a program that reads a date and time given in the format: day.month.year 
//hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format)
//along with the day of week in Bulgarian.

using System;
using System.Text;
using System.Globalization;

class PrintDateAndTime
{
    static void Main()
    {
        Console.WriteLine("Please input first date in the form day.month.year hour:min:second");
        string input = Console.ReadLine();
        string format = "d.M.yyyy HH:mm:ss";
        DateTime date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        Console.WriteLine("6 hours and 30 minitues later is: {0:dd.MM.yyyy HH:mm:ss}", date.AddMinutes(390));
        Console.WriteLine(date.AddMinutes(390).ToString("dddd", new CultureInfo("bg-BG")));
    }
}
