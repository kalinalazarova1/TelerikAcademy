// 5.Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements.
// Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.

using System;

internal class Program
{
    internal static void Main()
    {
        HashedSet<int> test = new HashedSet<int>();
        HashedSet<int> other = new HashedSet<int>();
        test.Add(1);
        test.Add(2);
        test.Add(3);
        test.Add(4);
        test.Add(5);
        test.Add(6);
        other.Add(4);
        other.Add(5);
        other.Add(6);
        other.Add(7);
        other.Add(8);
        Console.WriteLine("Initial hash set:");
        Console.WriteLine(string.Join(", ", test));
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("After removal of 3:");
        test.Remove(3);
        Console.WriteLine(string.Join(", ", test));
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Is 1 found? {0}", test.Find(1));
        Console.WriteLine("Is 3 found? {0}", test.Find(3));
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("First hash set:");
        Console.WriteLine(string.Join(", ", test));
        Console.WriteLine("Member count: {0}", test.Count);
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Second hash set:");
        Console.WriteLine(string.Join(", ", other));
        Console.WriteLine("Member count: {0}", other.Count);
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Intersect of the first and second:");
        Console.WriteLine(string.Join(", ", test.Intersect(other)));
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Union of the first and second:");
        Console.WriteLine(string.Join(", ", test.Union(other)));
        Console.WriteLine("--------------------------------------------------------------");
        test.Clear();
        Console.WriteLine("First hash set after clear:");
        Console.WriteLine(string.Join(", ", test));
    }
}