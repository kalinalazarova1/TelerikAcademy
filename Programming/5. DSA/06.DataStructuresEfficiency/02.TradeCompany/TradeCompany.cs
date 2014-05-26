// 2. A large trade company has millions of articles, each described by barcode, vendor, title and price. 
// Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
// Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.TradeCompany
{
    class TradeCompany
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<decimal, Article> store = new OrderedMultiDictionary<decimal, Article>(true);
            store.Add(1.00m, new Article(1234567890, "Savona", "Liquid soap"));
            store.Add(1.50m, new Article(1234567890, "Savona", "Sponge"));
            store.Add(1.60m, new Article(1234567890, "Clarion", "Sponge"));
            store.Add(1.07m, new Article(1234567890, "Clarion", "Magic Cream"));
            store.Add(1.11m, new Article(1234567890, "Savona", "Shampoo"));
            store.Add(1.23m, new Article(1234567890, "Clarion", "Shampoo"));
            store.Add(1.40m, new Article(1234567890, "Savona", "Shower gel"));
            store.Add(1.27m, new Article(1234567890, "Hunny", "Liquid soap"));
            store.Add(1.33m, new Article(1234567890, "Hunny", "Shower gel"));
            var filteredAtricles = store.Range(1.20m, true, 1.40m, true);
            foreach (var article in filteredAtricles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
