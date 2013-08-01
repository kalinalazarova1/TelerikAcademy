using System;
using System.Collections;

class OneTaskIsNotEnough
{
    static string GetBounded(string s)
    {
        short x = 0;
        short y = 0;
        sbyte dir = 0;
        sbyte[] moveX = { 0, 1, 0, -1 };
        sbyte[] moveY = { 1, 0, -1, 0 };
        for (byte j = 0; j < 4; j++)
        {
            for (ushort i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                {
                    dir = (sbyte)((dir + 3) % 4);
                }
                else if (s[i] == 'R')
                {
                    dir = (sbyte)((dir + 1) % 4);
                }
                else
                {
                    x = (short)(x + moveX[dir]);
                    y = (short)(y + moveY[dir]);
                }
            } 
        }
        if (x == 0 && y == 0)
        {
            return "bounded";
        }
        else
        {
            return "unbounded";
        }
    }
    static uint GetLastLamp(uint end)
    {
        uint litLampCounter = 0;
        end = end / 2;
        uint maxDarkLamp = end;
        uint[] lamps = new uint[end];
        for (int i = 0; i < end; i++)
        {
                lamps[i] = (uint)(i + 1) * 2;
        }
        for (uint i = 3;; i++)
        { 
            uint n = 0;
            for (uint j = 0; j < end; j++)
            {
                if (i > end)
                {
                    return lamps[end - 1];
                }
                if (j % i == 0)
                {
                    litLampCounter++;
                }
                else
                {
                    lamps[n] = lamps[j];
                    n++;
                }
            }
            end = maxDarkLamp - litLampCounter;
        }
    }

    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        if ((n & 1) == 1)
        {
            n--;
        }
        string firstInput = Console.ReadLine();
        string secondInput = Console.ReadLine();
        if (n != 0)
        {
            Console.WriteLine(GetLastLamp(n));
        }
        else
        {
            Console.WriteLine(1);
        }
        Console.WriteLine(GetBounded(firstInput));
        Console.WriteLine(GetBounded(secondInput));
    }
}
