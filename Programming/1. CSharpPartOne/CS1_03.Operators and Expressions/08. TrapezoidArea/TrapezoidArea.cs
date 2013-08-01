//Write an expression that calculates the trapezoid's area by given sides a, b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Please input first side of the trapezoid:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Please input second side of the trapezoid:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Please input the height of the trapezoid:");
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine("The trapezoid area is: {0}", (a + b) * h / 2 );
    }
}
