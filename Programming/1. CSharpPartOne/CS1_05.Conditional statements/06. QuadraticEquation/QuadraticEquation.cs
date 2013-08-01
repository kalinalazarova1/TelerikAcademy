//Write a program that enters the coefficients a, b and c of quadratic equation: ax2 + bx +c = 0 and
//prints it real roots. Note that a quadratic equation may have 0, 1 or 2 real roots.

using System;

class QuadraticEquation
{
    static void Main()
    {
        double a, b, c;
        bool isValid;
        do
        {
            Console.WriteLine("Please input the coefficent a:");
            isValid = double.TryParse(Console.ReadLine(), out a);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please input the coefficent b:");
            isValid = double.TryParse(Console.ReadLine(), out b);
        }
        while (!isValid);
        do
        {
            Console.WriteLine("Please input the coefficent c:");
            isValid = double.TryParse(Console.ReadLine(), out c);
        }
        while (!isValid);
        double d = b * b - 4 * a * c;
        if (d < 0)
            Console.WriteLine("The equation has no real roots.");
        else if (d == 0)
            Console.WriteLine("The equation has one root: {0}", -b / (2 * a));
        else
            Console.WriteLine("The equation has two real roots: {0}, {1}", (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a));

    }
}
