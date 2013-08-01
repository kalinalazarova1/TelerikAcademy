// Which of the following values can be assigned to float and which to double:
//34.567839023, 12.345, 8923.1234857, 3456.091

using System;

class AssignFloatAndDouble
{
    static void Main()
    {
        double a = 34.567839023;
        float b = 12.345f;
        double c = 8923.1234857;
        float d = 3456.091f;
        Console.WriteLine("{0}, {1}, {2}, {3}", a, b, c, d);
    }
}
