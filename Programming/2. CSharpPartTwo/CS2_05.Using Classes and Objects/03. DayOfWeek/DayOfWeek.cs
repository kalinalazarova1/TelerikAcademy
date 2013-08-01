//3. Write a program that prints to the console which day of week is today. Use System.DateTime.

using System;

class DayOfWeek
{
    static void Main()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine("Today is {0}.", date.DayOfWeek);
    }
}
