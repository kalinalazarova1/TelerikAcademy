using System;

class Poker
{
    static void Main()
    {
        string[] cardSigns = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
        int[] countSigns = new int[cardSigns.GetLength(0)];
        string[] curDeal = new string[5];
        int bestCount = 0;
        int secondBestCount = 0;
        int counter = 0;
        int longestLine = 0;
        bool isRepeated = false;
        for (int i = 0; i < 5; i++)
        {
            curDeal[i] = Console.ReadLine();
            for (int j = 0; j < cardSigns.GetLength(0); j++)
            {
                if (cardSigns[j] == curDeal[i])
                {
                    countSigns[j]++;
                }
            }
        }
        for (int i = 0; i < countSigns.Length; i++)
        {
            if (countSigns[i] > bestCount)
            {
                secondBestCount = bestCount;
                bestCount = countSigns[i];
            }
            else if (countSigns[i] > secondBestCount)
            {
                secondBestCount = countSigns[i];
            }
        }
        switch (bestCount)
        {
            case 5: Console.WriteLine("Impossible"); break;
            case 4: Console.WriteLine("Four of a Kind"); break;
            case 3:
                if (secondBestCount == 2)
                {
                    Console.WriteLine("Full House");
                }
                else
                {
                    Console.WriteLine("Three of a Kind");
                }
                break;
            case 2:
                if (secondBestCount == 2)
                {
                    Console.WriteLine("Two Pairs");
                }
                else
                {
                    Console.WriteLine("One Pair");
                }
                break;
            case 1:
                for (int i = 0; i < countSigns.Length; i++)
                {
                    if (countSigns[i] == 1)
                    {
                        counter++;
                        if ((i == countSigns.Length - 1 ) && !isRepeated)
                        {
                            i = -1;
                            isRepeated = true;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                    if (counter > longestLine)
                    {
                        longestLine = counter;
                    }
                }
                if (longestLine == 5)
                {
                    Console.WriteLine("Straight");
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
                break;
        }
    }
}
