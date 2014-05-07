using System;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerable<T> where T : IComparable
{
    private const int InitialSize = 16;

    private T[] data;
    private int count;

    public PriorityQueue(int capacity)
    {
        this.data = new T[capacity];
        this.count = 0;
    }

    public PriorityQueue()
        : this(InitialSize)
    {
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public void Enqueue(T value)
    {
        if (this.count == this.data.Length)
        {
            this.Resize();
        }

        this.data[this.count] = value;
        int current = this.count;
        while (current >= 0 && this.data[current].CompareTo(this.data[(current - 1) / 2]) > 0)
        {
            this.Swap(current, (current - 1) / 2);
            current = (current - 1) / 2;
        }

        this.count++;
    }

    public T Dequeue()
    {
        T result = this.data[0];
        this.count--;
        this.data[0] = this.data[this.count];
        var current = 0;
        var max = this.MaxChildIndex(current);
        while (max > 0 && current < max)
        {
            this.Swap(current, max);
            current = max;
            max = this.MaxChildIndex(current);
        }

        return result;
    }

    public void Clear()
    {
        this.data = new T[InitialSize];
        this.count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.count; i++)
        {
            yield return this.data[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private int MaxChildIndex(int parentIndex)
    {
        var leftChildIndex = (parentIndex * 2) + 1;
        var rightChildIndex = (parentIndex * 2) + 2;
        if (rightChildIndex >= this.count)
        {
            if (leftChildIndex >= this.count)
            {
                return -1;
            }
            else
            {
                return leftChildIndex;
            }
        }
        else
        {
            if (this.data[leftChildIndex].CompareTo(this.data[rightChildIndex]) > 0)
            {
                return leftChildIndex;
            }
            else
            {
                return rightChildIndex;
            }
        }
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        T temp = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = temp;
    }

    private void Resize()
    {
        T[] resizedArray = new T[this.data.Length * 2];
        Array.Copy(this.data, resizedArray, this.data.Length);
        this.data = resizedArray;
    }
}
