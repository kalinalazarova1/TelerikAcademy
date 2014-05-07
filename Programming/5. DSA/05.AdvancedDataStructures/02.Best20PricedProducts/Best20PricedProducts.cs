// 2. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b].
// Test for 500 000 products and 10 000 price searches.
// Hint: you may use OrderedBag<T> and sub-ranges.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

internal class Program
{
    internal static void Main()
    {
        var myStore = new OrderedBag<Product>();
        var ran = new Random();
        for (int i = 0; i < 500000; i++)
        {
            myStore.Add(new Product("prod." + ran.Next(1, 500001), ran.Next(1, 10011) / 100m));
        }

        var result = new StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            var prodList = myStore.Range(new Product(string.Empty, i + 1), true, new Product(string.Empty, i + 2), true);
            var counter = 0;
            foreach (var item in prodList)
            {
                if (counter == 20)
                {
                    break;
                }

                result.AppendFormat("{3}. Product: {0} Price: {1} BGN {2}", item.Name, item.Price, Environment.NewLine, counter + 1);
                counter++;
            }
        }

        Console.WriteLine(result);
    }
}
