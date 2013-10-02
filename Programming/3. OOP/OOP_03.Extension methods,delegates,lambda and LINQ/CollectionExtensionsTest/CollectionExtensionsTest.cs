//2. Implement a set of extension methods for IEnumerable<T> that implement the following group
//functions: sum, product, min, max, average.

using System;
using System.Collections.Generic;

namespace CollectionExtensions
{
    static class CollectionExtensionsTest
    {
        static void Main()
        {    
            try
            {
                Random ran = new Random();
                List<string> test = new List<string>();

                Console.WriteLine(new string('_', 60));
                Console.WriteLine("Test with string:");             //test with string
                for (int i = 0; i < 10; i++)
                {
                    test.Add(new string((char)(ran.Next(0, 26) + 'A'), ran.Next(1, 10)));
                    Console.WriteLine(test[i]);
                }
                Console.WriteLine("Min: {0}", test.Min<string>());  //the other methods will not work for string
                Console.WriteLine("Max: {0}", test.Max<string>());

                Console.WriteLine(new string('_', 60));
                Console.WriteLine("Test with double:");
                List<double> test1 = new List<double>();             //test with double
                for (int i = 0; i < 10; i++)
                {
                    test1.Add(Math.Round((double)ran.Next(0, 101) / ran.Next(1, 10), 3));
                    Console.WriteLine(test1[i]);
                }
                Console.WriteLine("Sum: {0}", test1.Sum<double>());
                Console.WriteLine("Min: {0}", test1.Min<double>());
                Console.WriteLine("Max: {0}", test1.Max<double>());
                Console.WriteLine("Average: {0}", test1.Average<double>());
                Console.WriteLine("Product: {0}", test1.Product<double>());

                Console.WriteLine(new string('_', 60));
                Console.WriteLine("Test with integer:");
                List<int> test2 = new List<int>();             //test with int
                for (int i = 0; i < 10; i++)
                {
                    test2.Add(ran.Next(1, 101));
                    Console.WriteLine(test2[i]);
                } 
                Console.WriteLine("Sum: {0}", test2.Sum<int>());
                Console.WriteLine("Min: {0}", test2.Min<int>());
                Console.WriteLine("Max: {0}", test2.Max<int>());
                Console.WriteLine("Average: {0}", test2.Average<int>());
                Console.WriteLine("Product: {0}", test2.Product<int>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
