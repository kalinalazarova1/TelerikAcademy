using System;

class Problem_6
{
    static double GetTriangleArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    static double GetTriangleArea(double a, double h)
    {
        return a * h / 2;
    }

    static double GetTriangleArea(double a, double b, int angle)    //angle is in degrees
    {
        return a * b * Math.Sin(angle * Math.PI / 180) / 2;         //angle is converted to radians
    }

    static void Main()
    {
        Console.WriteLine(@"Please enter choice a, b or c for the triangle area calculation:
                            a) by three sides;
                            b) by side and its heigth;
                            c) by two sides and angle between them in degrees");
        switch (Console.ReadLine())
        {
            case "a":
                {
                    Console.WriteLine("Please enter side a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter side b:");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter side c:");
                    double c = double.Parse(Console.ReadLine());
                    Console.WriteLine("The area of the triangle is: {0:0.000}", GetTriangleArea(a, b, c));
                    break;
                }
            case "b":
                {
                    Console.WriteLine("Please enter side a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter heigth h:");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine("The area of the triangle is: {0:0.000}", GetTriangleArea(a, h));
                    break;
                }
            case "c":
                {
                    Console.WriteLine("Please enter side a:");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter side b:");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter angle between them in degrees:");
                    int angle= int.Parse(Console.ReadLine());
                    Console.WriteLine("The area of the triangle is: {0:0.000}", GetTriangleArea(a, b, angle));
                    break;
                }
            default:
                break;
        }
    }
}
