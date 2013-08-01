//Write an expression that checks if given point (x, y) is within a circle K (0, 5)

using System;

class PointInCircle
{
    static void Main()
    {
        Console.WriteLine("Please input x:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Please input y:");
        double y = double.Parse(Console.ReadLine());
        if ((x * x + y * y) <= 5 * 5)
            Console.WriteLine("The point ({0}, {1}) is within the circle K(0, 5)", x, y);
        else
            Console.WriteLine("The point ({0}, {1}) is outside the circle K(0, 5)", x, y);
    }
}
