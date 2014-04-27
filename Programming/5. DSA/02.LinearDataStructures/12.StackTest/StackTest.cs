//12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to
// add/ insert a new element).

using System;

class StackTest
{
    static void Main()
    {
        var test = new Stack<int>();
        test.Push(1);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(2);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(3);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(4);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(5);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(6);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Push(7);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The stack count: {0}", test.Count);
        test.Pop();
        test.Pop();
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The stack count: {0}", test.Count);
        Console.WriteLine(test.Peek());
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The stack count: {0}", test.Count);
        test.Clear();
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The stack count: {0}", test.Count);
        //test.Pop();                           //if uncommented this line should throw exception
    }
}
