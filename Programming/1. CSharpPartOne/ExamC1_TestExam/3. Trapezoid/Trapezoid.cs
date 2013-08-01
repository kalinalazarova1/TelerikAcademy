using System;

class Trapezoid
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}", new string('.', n), new string('*', n));
        for (byte i = 0; i < n - 1; i++)
			{
			 Console.WriteLine("{0}{1}{2}{1}", new string('.', n - 1 - i), '*', new string('.', n - 1 + i));
			}
        Console.WriteLine("{0}", new string('*', 2 * n));
    }
}
