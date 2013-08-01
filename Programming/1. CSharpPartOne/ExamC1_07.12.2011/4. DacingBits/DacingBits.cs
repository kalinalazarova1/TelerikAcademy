using System;
using System.Text;

class DacingBits
{
    static void Main()
    {
        ushort dancerLenght = 0;
        ushort dancerCounter = 0;
        byte[] dancingBits = new byte[25601];
        ushort lastIndex = 0;
        ushort k = ushort.Parse(Console.ReadLine());
        ushort n = ushort.Parse(Console.ReadLine());
        ushort j = 0;
        for (ushort i = 0; i < n; i++)
        {
            uint number = uint.Parse(Console.ReadLine());
            for (sbyte pow = (sbyte)(Math.Log(number,2)); pow >= 0; j++, pow--)
            {
                dancingBits[j] = (byte)((number >> pow) & 1);
            }
            if (i == n - 1)
            {
                lastIndex = j;
                dancingBits[j] = 3;
            }
        }
        for (ushort i = 0; i < lastIndex + 1 - k;)
        {
            byte temp = dancingBits[i];
            dancerLenght = 0;
            for (; temp == dancingBits[i]; i++)
            {
                dancerLenght++;
            }

            if (dancerLenght == k)
            {
                dancerCounter++;
            }
        }
        Console.WriteLine(dancerCounter);
    }
}
