using System;

class Sheets
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        for (byte i = 0; i < 11; i++)
        {
            if (((n >> i) & 1) == 0)
            {
                Console.WriteLine("A{0}", 10 - i);
            }
        }
    }
}
