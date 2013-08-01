using System;
using System.Text;
using System.Globalization;

class Problem_18
{
    static void Main()
    {
        Console.WriteLine("Please input first date in the form day.month.year hour:min :");
        string input = Console.ReadLine();
        string format = "dd.MM.yyyy hh:mm";
        DateTime date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        Console.WriteLine("6 hours and 30 minitues later is: {0:dd.MM.yyyy hh:mm}", date.AddMinutes(390));
    }
}
