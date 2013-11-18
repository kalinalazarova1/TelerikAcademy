// 3.Define a class InvalidRangeException<T> that holds information about an error condition related
//to invalid range. It should hold error message and a range definition [start … end].
//Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
//by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013]

using System;

namespace InvalidRangeException
{
    public static class InvalidRangeExceptionTest
    {
        static int ReadIntNumber(int start, int end)
        {
            Console.WriteLine("Please enter number between {0} and {1} including", start, end);
            int number = int.Parse(Console.ReadLine());
            if (number > end || number < start)
            {
                throw new InvalidRangeException<int>(string.Format("The input number was not in the range [{0}..{1}]", start, end), start, end);
            }
            else
            {
                Console.WriteLine("The input number is correct!");
            }
            return number;
        }

        static DateTime ReadDate(DateTime start, DateTime end)
        {
            Console.WriteLine("Please enter date between {0} and {1} including", start.ToShortDateString(), end.ToShortDateString());
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter date in the format d.m.yyyy between {0} and {1} including", start.ToShortDateString(), end.ToShortDateString());
            }
            if (date > end || date < start)
            {
                throw new InvalidRangeException<DateTime>(string.Format("The input date was not in the range [{0}..{1}]!", start.ToShortDateString(), end.ToShortDateString()), start, end);
            }
            else
            {
                Console.WriteLine("The input date is correct!");
            }
            return date;
        }

        static void Main()
        {
            try
            {
                ReadIntNumber(1, 100);
                ReadDate(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
            catch(InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
            }
        }
    }
}
