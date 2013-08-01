// Write an expression that calculates the rectangle's area by given width and height

using System;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("Please input rectangle width:");
        double rectangleWidth = double.Parse(Console.ReadLine());
        Console.WriteLine("Please input rectangle heigth:");
        double rectangleHeight = double.Parse(Console.ReadLine());
        Console.WriteLine("The rectangle area is: {0}", rectangleHeight * rectangleWidth);
    }
}
