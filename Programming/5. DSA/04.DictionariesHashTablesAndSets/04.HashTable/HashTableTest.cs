// 4. Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists
// of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load
// runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties:
// Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to 
// support iterating over its elements with foreach.

using System;

internal class HashTableTest
{
    internal static void Main()
    {
        var myLetters = new HashTable<string, int>();
        myLetters.Add("a", 1);
        myLetters.Add("b", 1);
        myLetters.Add("c", 1);
        myLetters.Add("d", 1);
        myLetters.Add("e", 1);
        myLetters.Add("f", 1);
        myLetters.Add("g", 1);
        myLetters.Add("h", 1);
        myLetters.Add("i", 1);
        myLetters.Add("j", 1);
        myLetters.Add("k", 1);
        myLetters.Add("l", 1);
        myLetters.Add("m", 1);
        myLetters.Add("n", 1);
        myLetters.Add("o", 1);
        myLetters.Add("p", 1);
        myLetters.Add("q", 1);
        myLetters.Add("r", 1);
        myLetters.Add("s", 1);
        Console.WriteLine(string.Join(", ", myLetters));
        Console.WriteLine();
        myLetters["o"] = 6;
        Console.WriteLine("Now we change letter \"{0}\"  to {1} times.", "o", myLetters["o"]);
        Console.WriteLine(string.Join(", ", myLetters));
        Console.WriteLine();
        myLetters.Remove("q");
        Console.WriteLine("After removal of letter \"q\": {0}", string.Join(", ", myLetters));
        Console.WriteLine();
        Console.WriteLine("MyLetters contain \"z\"? {0}", myLetters.ContainsKey("z"));
        Console.WriteLine("MyLetters contain \"a\"? {0}", myLetters.ContainsKey("a"));
        Console.WriteLine();
        Console.WriteLine("Keys: {0}", string.Join(", ", myLetters.Keys()));
        Console.WriteLine();
        myLetters.Clear();
        Console.WriteLine("MyLetters after clear: {0}", string.Join(", ", myLetters));
    }
}
