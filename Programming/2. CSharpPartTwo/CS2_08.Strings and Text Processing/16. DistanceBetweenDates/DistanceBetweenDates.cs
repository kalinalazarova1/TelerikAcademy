//16.Write a program that reads two dates in the format: day.month.year and calculates the number of 
//days between them.Example:
//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2006
//Distance: 4 days

using System;
using System.Globalization;

class DistanceBetweenDates
{
    static void Main()
    {
        Console.WriteLine("Please input first date in the form day.month.year:");
        string input = Console.ReadLine();
        string format = "d.M.yyyy";
        DateTime firstDate = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        Console.WriteLine("Please input second date in the form day.month.year:");
        input = Console.ReadLine();
        DateTime secondDate = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        Console.WriteLine("There are {0:0} days between the two dates.", firstDate.Subtract(secondDate).Duration().TotalDays);
    }
}
