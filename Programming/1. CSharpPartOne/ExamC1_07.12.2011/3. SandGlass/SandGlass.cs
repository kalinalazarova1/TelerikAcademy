using System;

class SandGlass
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', i), new string('*', n - i * 2));
        }
        for (int i = n / 2 - 1; i >=0; i--)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', i), new string('*', n - i * 2));
        }
    }
}
