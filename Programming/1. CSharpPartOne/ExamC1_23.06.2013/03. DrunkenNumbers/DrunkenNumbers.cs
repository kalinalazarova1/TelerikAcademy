using System;
using System.Collections.Generic;
using System.Text;

class DrunkenNumbers
{
    static void Main()
    {
        uint[] totalBeers = new uint[2];
        byte numberRounds = byte.Parse(Console.ReadLine());
        for (byte i = 0; i < numberRounds; i++)
        {
            int input = int.Parse(Console.ReadLine());
            string drunkNumber = Math.Abs(input).ToString();
            for (byte j = 0; j < drunkNumber.Length; j++)
            {
                if (j < drunkNumber.Length / 2)
                {
                    totalBeers[0] += uint.Parse(drunkNumber[j].ToString());
                }
                else
                {
                    if (drunkNumber.Length % 2 == 0)
                    {
                        totalBeers[1] += uint.Parse(drunkNumber[j].ToString());
                    }
                    else if (j != drunkNumber.Length / 2)
                    {
                        totalBeers[1] += uint.Parse(drunkNumber[j].ToString());
                    }
                    else
                    {
                        totalBeers[0] += uint.Parse(drunkNumber[j].ToString());
                        totalBeers[1] += uint.Parse(drunkNumber[j].ToString());
                    }
                }
            }
        }
        if (totalBeers[0] == totalBeers[1])
        {
            Console.WriteLine("No {0}", totalBeers[0] + totalBeers[1]);
        }
        else if (totalBeers[0] > totalBeers[1])
        {
            Console.WriteLine("M {0}", totalBeers[0] - totalBeers[1]);
        }
        else
        {
            Console.WriteLine("V {0}", totalBeers[1] - totalBeers[0]);
        }
    }
}
