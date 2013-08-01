using System;

class Problem_4
{
    static void Main()
    {
        int time = Environment.TickCount / 1000;
        Console.WriteLine("This computer has been working for {0} days, {1} hours and {2} minutes",
            time / (24 * 60 * 60), (time % (24 * 60 * 60)) / (60 * 60), ((time % (24 * 60 * 60)) % (60 * 60)) / 60);
    }
}
