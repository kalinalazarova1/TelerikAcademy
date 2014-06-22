// 1.Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, each has weight Wi and costs Ci
// and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. The numbers N, M, Wi
// and Ci are integers in the range [1..500]. Example: M=10 kg, N=6, products:
// beer – weight=3, cost=2
// vodka – weight=8, cost=12
// cheese – weight=4, cost=5
// nuts – weight=1, cost=4
// ham – weight=2, cost=3
// whiskey – weight=8, cost=13
namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class KnapsackProblem
    {
        internal static void Main(string[] args)
        {
            int m = 10;
            var knapsack = new List<Product>();
            var all = new List<Product>();
            all.Add(new Product("beer", 3, 2));
            all.Add(new Product("vodka", 8, 12));
            all.Add(new Product("cheese", 4, 5));
            all.Add(new Product("nuts", 1, 4));
            all.Add(new Product("ham", 2, 3));
            all.Add(new Product("whiskey", 8, 13));

            var productsByValue = all.OrderByDescending(p => p.Price / p.Weight).ThenByDescending(p => p.Weight);
            foreach (var product in productsByValue)
            {
                if (knapsack.Sum(p => p.Weight) + product.Weight <= m)
                {
                    knapsack.Add(product);
                }
            }

            Console.WriteLine("Knapsack:\n" + string.Join(Environment.NewLine, knapsack));
            Console.WriteLine("Total: weight=" + knapsack.Sum(p => p.Weight) + ", cost=" + knapsack.Sum(p => p.Price));
        }
    }
}
