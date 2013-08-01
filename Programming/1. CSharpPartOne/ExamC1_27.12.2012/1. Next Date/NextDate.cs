using System;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        day++;
        if (day > 31) 
        {
            month++;
            day = 1;
        }
        else if (day > 30)
        {
            if(month == 4 || month == 6 || month == 9 || month == 11)
            {
            month++;
            day = 1;
            }
        }
        else if (day > 29 && month == 2 && year % 4 == 0) 
        {
            month++;
            day = 1;
        }
        else if (day > 28 && month == 2 && year % 4 != 0)
        {
            month++;
            day = 1;
        }
        if (month > 12)
        {
            year++;
            month = 1;
        }
        Console.WriteLine("{0}.{1}.{2}", day, month, year);
    }
}
