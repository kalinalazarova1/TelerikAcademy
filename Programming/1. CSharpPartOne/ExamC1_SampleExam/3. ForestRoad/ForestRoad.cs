using System;

class ForestRoad
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        for (byte i = 0; i < 2 * n - 1; i++)
        {
            if(i < n)
                Console.WriteLine("{0}{1}{2}", new string('.', i), '*', new string('.', n - 1 - i));
            else
                Console.WriteLine("{0}{1}{2}", new string('.', 2 * n - 2 - i), '*', new string('.', i - n + 1 ));
        }
    }
}
