using System;
using System.Collections.Generic;
using System.Text;

class BullsAndCows    
{
    static void Main()
    {
        ushort combCount = 0;
        string secretNumber = Console.ReadLine();
        byte bulls = byte.Parse(Console.ReadLine());
        byte cows = byte.Parse(Console.ReadLine());
        for (ushort i = 1111; i <= 9999; i++)
        {
            bool isZero = false;
            byte currCows = 0;
            byte currBulls = 0;
            bool[] isUsedSecret = new bool[4];
            bool[] isUsedGuess = new bool[4];
            for (byte j = 0; j < 4; j++)
            {
                if (i.ToString()[j] == '0')
                {
                    isZero = true;
                    break;
                }
                if (i.ToString()[j] == secretNumber[j])
                {
                    currBulls++;
                    isUsedSecret[j] = true;
                    isUsedGuess[j] = true;
                }
            }
            if (currBulls != bulls)
            {
                continue;
            }
            for (byte j = 0; j < 4; j++)
            {
                for (byte p = 0; p < 4; p++)
                {
                    if (!isUsedSecret[p] && !isUsedGuess[j] && i.ToString()[j] == secretNumber[p])
                    {
                        currCows++;
                        isUsedSecret[p] = true;
                        isUsedGuess[j] = true;
                    }
                }
            }
            if (!isZero && currCows == cows)
            {
                Console.Write("{0} ", i);
                combCount++;
            }
        }
        if (combCount == 0)
        {
            Console.WriteLine("No");
        }
    }
}
