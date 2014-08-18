namespace _04.RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        internal static void Main()
        {
            var initial = int.Parse(Console.ReadLine());
            var final = int.Parse(Console.ReadLine());
            var weight = new int[] { 1, 10, 100, 1000, 10000 };
            var n = int.Parse(Console.ReadLine());
            var forbidden = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                forbidden.Add(int.Parse(Console.ReadLine()));
            }

            var newComb = new Queue<CombinationInfo>();
            newComb.Enqueue(new CombinationInfo(initial, 0));
            while (newComb.Count > 0)
            {
                var current = newComb.Dequeue();
                for (int i = 0; i < 5; i++)
                {
                    var generatedDigit = ((current.Comb / weight[i]) % 10 + 1) % 10;
                    var generatedComb = current.Comb + (generatedDigit - current.Comb / weight[i] % 10) * weight[i];
                    if (generatedComb == final)
                    {
                        Console.WriteLine(current.Pressed + 1);
                        return;
                    }

                    if (!forbidden.Contains(generatedComb))
                    {
                        newComb.Enqueue(new CombinationInfo(generatedComb, current.Pressed + 1));
                        forbidden.Add(generatedComb);
                    }

                    generatedDigit = ((current.Comb / weight[i]) % 10 + 9) % 10;
                    generatedComb = current.Comb + (generatedDigit - current.Comb / weight[i] % 10) * weight[i];
                    if (generatedComb == final)
                    {
                        Console.WriteLine(current.Pressed + 1);
                        return;
                    }

                    if (!forbidden.Contains(generatedComb))
                    {
                        newComb.Enqueue(new CombinationInfo(generatedComb, current.Pressed + 1));
                        forbidden.Add(generatedComb);
                    }
                }
            }

            Console.WriteLine(-1);
        }
    }
}
