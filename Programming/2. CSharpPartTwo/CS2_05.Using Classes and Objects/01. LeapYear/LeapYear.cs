//1. Write a program that reads an year from the console and checks whether it is a leap.
//Use DateTime.

using System;

class LeapYear
{
    static void Main()
    {
        try
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
        catch(ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
