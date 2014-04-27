//11. Implement the data structure linked list. Define a class ListItem<T> that has two fields:
//value (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T>
//with a single field FirstElement (of type ListItem<T>).

using System;
using System.Text;

class Program
{
    static void Main()
    {
        var test = new LinkedList<string>();
        test.AddFirst("apple");
        Console.WriteLine(test);
        test.AddLast("banana");
        Console.WriteLine(test);
        test.AddLast("orange");
        Console.WriteLine(test);
        test.AddLast("kiwi");
        Console.WriteLine(test);
        test.AddFirst("ananas");
        Console.WriteLine(test);
        test.Remove("orange");
        Console.WriteLine(test);
        test[1] = "melon";
        Console.WriteLine(test);
        Console.WriteLine(test[0]);
        test.Clear();
        Console.WriteLine(test);
    }
}
