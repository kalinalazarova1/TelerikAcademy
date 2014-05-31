// 5.Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
// Example: n=3, k=2, set = {hi, a, b} =>
// (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

namespace _05.Variations
{
    using System;

    internal class Variations
    {
        internal static void Main()
        {
            // int n = 3; this variable is useless, because it is equal to set.Length
            int k = 2;
            string[] set = { "hi", "a", "b" };
            GetVariations(0, new string[k], set);
        }

        private static void GetVariations(int startIndex, string[] vars, string[] set)
        {
            if (startIndex == vars.Length)
            {
                Console.Write("({0}), ", string.Join(" ", vars));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                vars[startIndex] = set[i];
                GetVariations(startIndex + 1, vars, set);
            }
        }
    }
}
