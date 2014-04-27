using System;

class LinkedQueueTest
{
    static void Main()
    {
        var test = new LinkedQueue<int>();
        test.Enqueue(1);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(2);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(3);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(4);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(5);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(6);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        test.Enqueue(7);
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The queue count: {0}", test.Count);
        test.Dequeue();
        test.Dequeue();
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The queue count: {0}", test.Count);
        Console.WriteLine(test.Peek());
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The queue count: {0}", test.Count);
        test.Clear();
        Console.WriteLine(string.Join(" ", test.ToArray()));
        Console.WriteLine("The queue count: {0}", test.Count);
        //test.Dequeue();                           //if uncommented this line should throw exception
    }
}
