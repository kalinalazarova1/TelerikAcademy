using System;

class Problem_1
{
    static void Main()
    {
        Console.WriteLine("Please input an year:");
        int year = int.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("The year is leap.");
        }
        else
        {
            Console.WriteLine("The year is not leap.");
        }
    }
}
