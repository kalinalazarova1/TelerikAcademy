using System;
using System.Text;

class Carpets
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        StringBuilder carpet = new StringBuilder();
        carpet.Capacity = n + 2;
        carpet.Append('.', n/2 - 1);
        carpet.Append("/\\");
        carpet.Append('.', n/2 - 1);
        Console.WriteLine(carpet);
        for (byte i = 0; i < n/2 - 1; i++)
        {
            if((i & 1) == 0)
            {
                carpet.Insert(n/2, "  ");
            }
            else
            {
                carpet.Insert(n/2, "/\\");
            }
            carpet.Remove(n + 1, 1);
            carpet.Remove(0, 1);
            Console.WriteLine(carpet);
        }
        carpet.Replace('/','\\', 0, n/2);
        carpet.Replace('\\','/', n/2, n/2);
        Console.WriteLine(carpet);
        for (byte i = 0; i < n / 2 - 1; i++)
        {
            carpet.Remove(n / 2 - 1, 2);
            carpet.Append('.', 1);
            carpet.Insert(0, '.');
            Console.WriteLine(carpet);
        }
    }
}
