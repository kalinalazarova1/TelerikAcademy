//Write a program that prints all the possible cards from a standard deck of 52 cards (without jokers)
//The cards should be printed with their English names. Use nested for loops and switch case.

using System;

class CardsFromDeck
{
    static void Main()
    {
        string cardType = null;
        string cardColor = null;
        for (int i = 2; i <= 14; i++)
        {
            switch (i)
            {
                case 2: cardType = "Two"; break;
                case 3: cardType = "Three"; break;
                case 4: cardType = "Four"; break;
                case 5: cardType = "Five"; break;
                case 6: cardType = "Six"; break;
                case 7: cardType = "Seven"; break;
                case 8: cardType = "Eight"; break;
                case 9: cardType = "Nine"; break;
                case 10: cardType = "Ten"; break;
                case 11: cardType = "Ace"; break;
                case 12: cardType = "Jack"; break;
                case 13: cardType = "Queen"; break;
                case 14: cardType = "King"; break;
            }
            for (int j = 0; j < 4; j++)
            {
                switch (j)
                {
                    case 0: cardColor =" of clubs"; break;
                    case 1: cardColor =" of diamonds"; break;
                    case 2: cardColor =" of hearts"; break;
                    case 3: cardColor = " of spades"; break;
                }
                Console.WriteLine(cardType + cardColor);
            }
        }
    }
}
