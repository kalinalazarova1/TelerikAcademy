// 90/100 BgCoder
namespace _07.Circles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Circles
    {
        private static HashSet<string> necklaces = new HashSet<string>();
        private static int counter = 0;
        private static char[] comb;

        internal static void Main()
        {
            var set = Console.ReadLine().ToCharArray();
            var keys = set.GroupBy(x => x).Select(g => g.Key).ToArray();
            var values = set.GroupBy(x => x).Select(g => g.Count()).ToArray();

            if (set.Length == keys.Length && set.Length > 2)
            {
                var fact = 1;
                for (int i = 0; i < set.Length; i++)
                {
                    fact *= i + 1;
                }

                Console.WriteLine(fact / (set.Length * 2));
                return;
            }

            comb = new char[set.Length];
            GetPerm(values, keys, 0);
            Console.WriteLine(counter);
        }

        private static void GetPerm(int[] values, char[] keys, int index)
        {
            if (index == comb.Length)
            {
                if (!(necklaces.Contains(string.Join(string.Empty, comb)) || necklaces.Contains(string.Join(string.Empty, comb.Reverse<char>()))))
                {
                    // Console.WriteLine("{{{0}}}", string.Join(", ", comb));
                    necklaces.Add(string.Join(string.Empty, comb));
                    counter++;
                    var cur = comb.ToList();
                    for (int i = 0; i < comb.Length; i++)
                    {
                        char temp = cur[0];
                        cur.RemoveAt(0);
                        cur.Add(temp);
                        necklaces.Add(string.Join(string.Empty, cur));
                    }

                    return;
                }
            }

            for (int i = 0; i < keys.Length; i++)
            {
                if (values[i] > 0)
                {
                    comb[index] = keys[i];
                    values[i]--;
                    GetPerm(values, keys, index + 1);
                    values[i]++;
                }
            }
        }
    }
}