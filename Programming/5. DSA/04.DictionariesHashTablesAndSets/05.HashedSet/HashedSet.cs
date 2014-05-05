using System.Collections.Generic;

public class HashedSet<T> : IEnumerable<T>
{
    private HashTable<int, T> data;

    public HashedSet()
    {
        this.data = new HashTable<int, T>();
    }

    public HashedSet(int capacity)
    {
        this.data = new HashTable<int, T>(capacity);
    }

    public int Count
    {
        get
        {
            return this.data.Count;
        }
    }

    public void Add(T value)
    {
        this.data.Add(value.GetHashCode(), value);
    }

    public bool Find(T value)
    {
        if (this.data.ContainsKey(value.GetHashCode()))
        {
            return true;
        }

        return false;
    }

    public void Remove(T value)
    {
        this.data.Remove(value.GetHashCode());
    }

    public void Clear()
    {
        this.data.Clear();
    }

    public HashedSet<T> Union(HashedSet<T> other)
    {
        var result = new HashedSet<T>();
        foreach (var item in this.data)
        {
            result.Add(item.Value);
        }

        foreach (var item in other.data)
        {
            if (!result.data.ContainsKey(item.Key))
            {
                result.Add(item.Value);
            }
        }

        return result;
    }

    public HashedSet<T> Intersect(HashedSet<T> other)
    {
        var result = new HashedSet<T>();
        foreach (var itemFirst in this.data)
        {
            foreach (var itemSecond in other.data)
            {
                if (itemFirst.Key == itemSecond.Key)
                {
                    result.Add(itemSecond.Value);
                }
            }
        }

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.data)
        {
            yield return item.Value;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
