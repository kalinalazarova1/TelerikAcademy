//5. Write a method that calculates the number of workdays between
// today and given date, passed as parameter. Consider that workdays
//are all days from Monday to Friday except a fixed
//list of public holidays specified preliminary as array.

using System;

class Workdays
{
    static void Main()
    {
        int workDays = 0;
        DateTime[] officialHolidays = { new DateTime(2013,1,1), new DateTime(2013,5,1), new DateTime(2013,5,2),
                                        new DateTime(2013,5,3), new DateTime(2013,5,6),
                                        new DateTime(2013,5,24), new DateTime(2013,9,6), new DateTime(2013,12,24),
                                        new DateTime(2013,12,25), new DateTime(2013,12,26), new DateTime(2013,12,31)};
        DateTime[] workingSaturdays = { new DateTime(2013,5,18), new DateTime(2013,12,14)};
        Console.WriteLine("Please input month for calculation:");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Please input day of the month for calculation:");
        int day = int.Parse(Console.ReadLine());
        DateTime finalDate = new DateTime(2013, month, day);
        DateTime startDate = DateTime.Now.Date;
        while (finalDate >= startDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Sunday && startDate.DayOfWeek != DayOfWeek.Saturday)
            {
                workDays++;                         //adds workdays of the week;
            }
            foreach (var date in officialHolidays)
            {
                if (startDate == date)
                {
                    workDays--;                      //substracts the official holidays which are on workdays
                }
            }
            foreach (var date in workingSaturdays)
            {
                if (startDate == date)
                {
                    workDays++;                       //adds these Saturdays which are official workdays
                }
            }
            startDate = startDate.AddDays(1);
        }
        Console.WriteLine("The working days from today till {0}.{1}.2013 are: {2}", finalDate.Day, finalDate.Month, workDays);
    }
}
