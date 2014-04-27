//10.* We are given numbers N and M and the following operations:
//a) N = N+1
//b) N = N+2
//c) N = N*2
//Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. 
//Hint: use a queue.
//Example: N = 5, M = 16
//Sequence: 5 -> 7 -> 8 -> 16

using System;
using System.Collections.Generic;
using System.Linq;

class ShortestSeqFromMtoN       //this implementation uses the hint from the task condition
{
    static void Main()
    {
        int n = 0;
        int m = 10;
        var seq = new Queue<Item>();
        var result = new Stack<int>();
        var all = new HashSet<int>();
        if (m > n)
            seq.Enqueue(new Item(n, null));
        else
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        all.Add(n);
        Item cur = null;
        while (true)
        {
            cur = seq.Dequeue();
            if(!all.Contains(cur.Value + 1) && cur.Value + 1 < m)
            seq.Enqueue(new Item(cur.Value + 1, cur));
            if (cur.Value + 1 == m) break;
            if (!all.Contains(cur.Value + 2) && cur.Value + 2 < m)
            seq.Enqueue(new Item(cur.Value + 2, cur));
            if (cur.Value + 2 == m) break;
            if (!all.Contains(cur.Value * 2) && cur.Value * 2 < m)
            seq.Enqueue(new Item(cur.Value * 2, cur));
            if (cur.Value * 2 == m) break;
        }
        Console.WriteLine("The sequence is:");
        for(result.Push(m); cur != null; cur = cur.Previous)
        {
            result.Push(cur.Value);
        }
        Console.WriteLine(string.Join(" ", result));
    }
        
    public class Item
    {
        public int Value {get; private set;}
        public Item Previous { get; private set;}
        public Item(int number, Item pointer)
        {
            this.Value = number;
            this.Previous = pointer;
        }
    }
}
