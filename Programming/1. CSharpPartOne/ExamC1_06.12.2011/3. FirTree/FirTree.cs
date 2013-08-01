using System;

class FirTree
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        for (byte i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}{1}{0}",new string('.', n - 2 - i),new string('*', 1 + i * 2));
        }
        Console.WriteLine("{0}{1}{0}", new string('.', n - 2), '*');
    }
}
