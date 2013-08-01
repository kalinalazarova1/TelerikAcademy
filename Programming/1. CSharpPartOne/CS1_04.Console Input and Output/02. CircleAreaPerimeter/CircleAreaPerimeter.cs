//Write a program that reads the radius r of a circle and prints its area and perimeter

using System;

class CircleAreaPerimeter
{
    static void Main()
    {
        double radius;
        bool isValid;
        do
        {
            Console.WriteLine("Please input the radius of the circle:");
            isValid = double.TryParse(Console.ReadLine(), out radius);
        }
        while (!isValid || radius < 0);
        Console.WriteLine("The area of the circle is: {0:0.00}",radius * radius * Math.PI);
        Console.WriteLine("The perimeter of the circle is: {0:0.00}", radius * 2 * Math.PI);
    }
}
