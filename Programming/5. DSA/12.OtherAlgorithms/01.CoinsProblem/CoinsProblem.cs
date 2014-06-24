// 1. You are given a set of infinite number of coins (1, 2 and 5) and end value – N. Write an algorithm
// that gives the number of coins needed so that the sum of the coins equals N.
// Example: N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1
namespace _01.CoinsProblem
{
    using System;
    using System.Linq;

    internal class CoinsProblem
    {
        internal static void Main()
        {
            int[] coinValues = { 5, 2, 1 };
            int[] coinsCount = new int[coinValues.Length];
            int sum = 33;
            int rest = sum;
            for (int i = 0; i < coinValues.Length && rest > 0; i++)
            {
                coinsCount[i] = rest / coinValues[i];
                Console.WriteLine("{0} coin/coins of value {1}", coinsCount[i], coinValues[i]);
                rest -= coinValues[i] * coinsCount[i];
            }

            Console.WriteLine("We need total {0} coins to make the sum {1}.", coinsCount.Sum(), sum);
        }
    }
}
