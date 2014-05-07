// 1. Implement a class PriorityQueue<T> based on the data structure "binary heap".

using System;

internal class Program
{
    internal static void Main()
    {
        var test = new PriorityQueue<int>();
        var ran = new Random();
        for (int i = 0; i < 30; i++)
        {
            test.Enqueue(ran.Next(1, 101));
        }

        Console.WriteLine(string.Join(", ", test));
        Console.WriteLine("The queue count is: {0}", test.Count);
        for (int i = 0; i < 30; i++)
        {
            Console.WriteLine("Dequeue: {0}, Count: {1}", test.Dequeue(), test.Count);
        }
    }
}
