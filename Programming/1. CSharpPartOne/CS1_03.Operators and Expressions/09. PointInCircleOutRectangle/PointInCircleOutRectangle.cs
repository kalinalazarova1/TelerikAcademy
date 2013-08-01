//Write an expression that checks for given point(x, y) if it is within the circle K(1, 1)
//and out of the rectangle R(top = 1, left = -1, width = 6, height = 2)

using System;

class PointInCircleOutRectangle
{
    static void Main()
    {
        bool InCircle = false;
        bool OutRectangle = false;
        Console.WriteLine("Please input x:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Please input y:");
        double y = double.Parse(Console.ReadLine());
        if (((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 3 * 3)
            InCircle = true;
        if ((x < -1) || (x > 5) || (y > 1) || (y < -1))
            OutRectangle = true;
        if (InCircle && OutRectangle)
            Console.WriteLine("The point ({0}, {1}) is inside the circle K (-1, 1) and outside the rectangle R((-1,1), 6, 2)", x, y);
        else
            Console.WriteLine("The point ({0}, {1}) is NOT inside the circle K (-1, 1) and outside the rectangle R((-1,1), 6, 2) at the same time.", x, y);
    }
}
