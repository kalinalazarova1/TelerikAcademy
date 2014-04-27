using System;
using System.Collections.Generic;

public class LinkedQueue<T>
{
    private LinkedList<T> items { get; set; }

    public LinkedQueue()
    {
        this.items = new LinkedList<T>();
    }

    public int Count 
    {
        get
        {
            return this.items.Count;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0) throw new InvalidOperationException("Queue is empty!");
        T result = items.Last.Value;
        items.RemoveFirst();
        return result;   
    }

    public void Enqueue(T item)
    {
        this.items.AddLast(item);
    }

    public T Peek()
    {
        if (this.Count == 0) throw new InvalidOperationException("Queue is empty!");
        T result = items.First.Value;
        return result; 
    }

    public void Clear()
    {
        this.items.Clear();
    }

    public T[] ToArray()
    {
        var result = new T[this.items.Count];
        int counter = 0;
        foreach (var item in this.items)
        {
            result[counter] = item;
            counter++;
        }
        return result;
    }
}
