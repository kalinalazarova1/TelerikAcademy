using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class CardWars
{
    static int GetCardValue(string s)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == s)
            {
                return i;
            }
        }
        return 0;
    }

    static string[] cards = { "", "A", "10", "9", "8", "7", "6", "5", "4", "3", "2", "J", "Q", "K" };
    static void Main()
    {
        byte totalGames = byte.Parse(Console.ReadLine());
        BigInteger[] playerScore = new BigInteger[2];
        byte[] gamesWon = new byte[2];
        bool[] isWinner = { false, false };
        for (int i = 0; i < totalGames; i++)
        {
            int[] handValue = new int[2];
            for (int p = 0; p < 2; p++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string card = Console.ReadLine();
                    int valueCard = GetCardValue(card);
                    if (valueCard != 0)
                    {
                        handValue[p] += valueCard;
                    }
                    else
                    {
                        if (card == "Z")
                        {
                            playerScore[p] *= 2;
                        }
                        else if (card == "X")
                        {
                            isWinner[p] = true;
                        }
                        else if (card == "Y")
                        {
                            playerScore[p] -= 200;
                        }
                    }
                }
            }
            if (isWinner[0] && isWinner[1])
            {
                playerScore[0] += 50;
                playerScore[1] += 50;
                isWinner[0] = false;
                isWinner[1] = false;
                //continue;
            }
            else if (isWinner[0] && !isWinner[1] || !isWinner[0] && isWinner[1])
            {
                break;
            }
            if (handValue[0] > handValue[1])
            {
                playerScore[0] += handValue[0];
                gamesWon[0]++;
            }
            else if (handValue[0] < handValue[1])
            {
                playerScore[1] += handValue[1];
                gamesWon[1]++;
            }
        }
        if (!isWinner[0] && !isWinner[1])
        {
            if (playerScore[0] > playerScore[1])
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", playerScore[0]);
                Console.WriteLine("Games won: {0}", gamesWon[0]);
            }
            else if (playerScore[1] > playerScore[0])
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", playerScore[1]);
                Console.WriteLine("Games won: {0}", gamesWon[1]);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", playerScore[0]);
            }
        }
        else
        {
            if (isWinner[0])
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
        }
    }
}