using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colours = { "пика", "купа", "каро", "спатия" };
            string[] cards = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };
            for (int i = 0; i < colours.Length; i++)
            {
                for (int n = 0; n < cards.Length; n++)
                {
                    Console.Write(cards[n] + " " + colours[i] + ", ");
                }
            }
        }
    }
}
