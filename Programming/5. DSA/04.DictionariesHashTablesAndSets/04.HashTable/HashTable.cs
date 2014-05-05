using System;
using System.Collections.Generic;
using System.Linq;

public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
{
    private const int InitialSize = 16;
    private const float CapacityLimit = 0.75f;

    private LinkedList<KeyValuePair<K, T>>[] data;
    private int elementsCount;
    private int dataOccupiedCount;

    public HashTable(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("The capacity of the hash table could not be negative or zero!");
        }

        this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
        this.elementsCount = 0;
        this.dataOccupiedCount = 0;
    }

    public HashTable()
        : this(InitialSize)
    {
    }

    public int Count
    {
        get
        {
            return this.elementsCount;
        }
    }

    public T this[K key]
    {
        get
        {
            return this.Find(key);
        }

        set
        {
            if (!this.Find(key).Equals(value))
            {
                this.Remove(key);
                this.Add(key, value);
            }
        }
    }

    public void Add(K key, T value)
    {
        var current = Math.Abs(key.GetHashCode() % this.data.Length);
        if ((float)this.dataOccupiedCount / this.data.Length >= CapacityLimit)
        {
            this.ResizeHashTable();
        }

        if (this.data[current] == null)
        {
            this.data[current] = new LinkedList<KeyValuePair<K, T>>();
            this.data[current].AddLast(new KeyValuePair<K, T>(key, value));
            this.elementsCount++;
            this.dataOccupiedCount++;
        }
        else
        {
            this.data[current].AddLast(new KeyValuePair<K, T>(key, value));
            this.elementsCount++;
        }
    }

    public bool ContainsKey(K key)
    {
        try
        {
            this.Find(key);
        }
        catch (KeyNotFoundException)
        {
            return false;
        }

        return true;
    }

    public T Find(K key)
    {
        var current = this.data[Math.Abs(key.GetHashCode() % this.data.Length)];
        if (current == null || current.Count == 0)
        {
            throw new KeyNotFoundException();
        }

        if (current.Count == 1)
        {
            return current.First.Value.Value;
        }
        else
        {
            foreach (var item in current)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException();
        }
    }

    public void Remove(K key)
    {
        var current = this.data[Math.Abs(key.GetHashCode() % this.data.Length)];
        if (current == null || current.Count == 0)
        {
            throw new KeyNotFoundException();
        }

        this.elementsCount--;
        if (current.Count > 1)
        {
            current.Remove(new KeyValuePair<K, T>(key, this.Find(key)));
        }
        else
        {
            current.RemoveFirst();
            this.dataOccupiedCount--;
        }
    }

    public void Clear()
    {
        this.data = new LinkedList<KeyValuePair<K, T>>[InitialSize];
        this.dataOccupiedCount = 0;
        this.elementsCount = 0;
    }

    public IEnumerable<K> Keys()
    {
        return this.Select(p => p.Key);
    }

    public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
    {
        foreach (var list in this.data)
        {
            if (list != null)
            {
                foreach (var pair in list)
                {
                    yield return pair;
                }
            }
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void ResizeHashTable()
    {
        var resized = new LinkedList<KeyValuePair<K, T>>[this.data.Length * 2];
        for (int i = 0; i < this.data.Length; i++)
        {
            if (this.data[i] != null)
            {
                var temp = new LinkedList<KeyValuePair<K, T>>();
                foreach (var pair in this.data[i])
                {
                    temp.AddLast(pair);
                }

                resized[Math.Abs(temp.Last.Value.Key.GetHashCode() % resized.Length)] = temp;
            }
        }

        this.data = resized;
    }
}
