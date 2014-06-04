// 4.*Write a program to compare the performance of insertion sort, selection sort, quicksort for int, double and string values.
// Check also the following cases: random values, sorted values, values sorted in reversed order.

namespace SortingComparison
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class SortingComparison
    {
        internal static void Main()
        {
            int collectionCount = 10000;
            var randomInt = new int[collectionCount];
            var reversedInt = new int[collectionCount];
            var sortedInt = new int[collectionCount];
            Random ran = new Random();

            for (int i = 0; i < collectionCount; i++)
            {
                randomInt[i] = ran.Next();
                reversedInt[reversedInt.Length - 1 - i] = i;
                sortedInt[i] = i;
            }

            Console.WriteLine("Integers:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Selection sort results:");
            TestAllSortingMethods<int>(randomInt, reversedInt, sortedInt, new SelectionSorter<int>());
            Console.WriteLine();
            Console.WriteLine("Insertion sort results:");
            TestAllSortingMethods<int>(randomInt, reversedInt, sortedInt, new InsertionSorter<int>());
            Console.WriteLine();
            Console.WriteLine("Quick sort results:");
            TestAllSortingMethods<int>(randomInt, reversedInt, sortedInt, new Quicksorter<int>());
            Console.WriteLine();

            var randomDouble = new double[collectionCount];
            var reversedDouble = new double[collectionCount];
            var sortedDouble = new double[collectionCount];

            for (int i = 0; i < collectionCount; i++)
            {
                randomDouble[i] = ran.Next() * 1.01;
                reversedDouble[reversedInt.Length - 1 - i] = i;
                sortedDouble[i] = i;
            }

            Console.WriteLine("Doubles:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Selection sort results:");
            TestAllSortingMethods<double>(randomDouble, reversedDouble, sortedDouble, new SelectionSorter<double>());
            Console.WriteLine();
            Console.WriteLine("Insertion sort results:");
            TestAllSortingMethods<double>(randomDouble, reversedDouble, sortedDouble, new InsertionSorter<double>());
            Console.WriteLine();
            Console.WriteLine("Quick sort results:");
            TestAllSortingMethods<double>(randomDouble, reversedDouble, sortedDouble, new Quicksorter<double>());
            Console.WriteLine();

            var randomString = new string[collectionCount];
            var reversedString = new string[collectionCount];
            var sortedString = new string[collectionCount];
            var sample = "ieksmdjfue";
            for (int i = 0; i < collectionCount; i++)
            {
                randomString[i] = sample.Substring(ran.Next(0, 10));
                sortedString[i] = randomString[i];
            }

            Array.Sort(sortedString);
            reversedString = sortedString.Reverse().ToArray();
            Console.WriteLine("Strings:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Selection sort results:");
            TestAllSortingMethods<string>(randomString, reversedString, sortedString, new SelectionSorter<string>());
            Console.WriteLine();
            Console.WriteLine("Insertion sort results:");
            TestAllSortingMethods<string>(randomString, reversedString, sortedString, new InsertionSorter<string>());
            Console.WriteLine();
            Console.WriteLine("Quick sort results:");
            TestAllSortingMethods<string>(randomString, reversedString, sortedString, new Quicksorter<string>());
            Console.WriteLine();
        }

        private static void TestAllSortingMethods<T>(T[] random, T[] reversed, T[] sorted, ISorter<T> sorter) where T : IComparable<T>
        {
            Stopwatch sw = new Stopwatch();
            var collection = new SortableCollection<T>(random);
            sw.Start();
            collection.Sort(sorter);
            sw.Stop();
            Console.WriteLine("Random: {0} seconds.", sw.ElapsedMilliseconds / 1000.0);
            collection = new SortableCollection<T>(sorted);
            sw.Reset();
            sw.Start();
            collection.Sort(sorter);
            sw.Stop();
            Console.WriteLine("Sorted: {0} seconds.", sw.ElapsedMilliseconds / 1000.0);
            collection = new SortableCollection<T>(reversed);
            sw.Reset();
            sw.Start();
            collection.Sort(sorter);
            sw.Stop();
            Console.WriteLine("Reversed: {0} seconds.", sw.ElapsedMilliseconds / 1000.0);
        }
    }
}
