using System;
using System.Text;
using System.Globalization;

    class Problem_17
    {
        static void Main()
        {
            Console.WriteLine("Please input first date in the form day.month.year:");
            string input = Console.ReadLine();
            string format = "dd.MM.yyyy";
            DateTime firstDate = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
            Console.WriteLine("Please input second date in the form day.month.year:");
            input = Console.ReadLine();
            DateTime secondDate = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
            Console.WriteLine("There are {0:0} days between the two dates.", firstDate.Subtract(secondDate).Duration().TotalDays);
        }
    }
