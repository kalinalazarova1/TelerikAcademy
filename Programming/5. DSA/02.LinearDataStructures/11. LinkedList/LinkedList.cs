using System;
using System.Text;
public class LinkedList<T> where T : IComparable
{
    private class ListItem
    {
        public T Value { get; set; }
        public ListItem NextItem { get; set; }
        public ListItem(T itemValue)
        {
            this.Value = itemValue;
            this.NextItem = null;
        }
    }

    private ListItem FisrtElement { get; set; }

    public LinkedList()
    {
        this.FisrtElement = null;
    }

    public void AddLast(T item)
    {
        if (this.FisrtElement == null)
        {
            this.FisrtElement = new ListItem(item);
        }
        else
        {
            var current = this.FisrtElement;
            while (current.NextItem != null)
            {
                current = current.NextItem;
            }
            current.NextItem = new ListItem(item);
        }
    }

    public void AddFirst(T item)
    {
        var current = new ListItem(item);
        current.NextItem = this.FisrtElement;
        this.FisrtElement = current;
    }

    public void Remove(T item)
    {
        if (this.FisrtElement == null) return;
        ListItem current = this.FisrtElement;
        if (current.Value.CompareTo(item) == 0)
        {
            this.FisrtElement = current.NextItem;
        }
        while (current.NextItem != null)
        {
            if (current.NextItem.Value.CompareTo(item) == 0)
            {
                current.NextItem = current.NextItem.NextItem;
                return;                                 //if we remove this return the method will remove all items with the specified value
            }
            current = current.NextItem;
        }
    }

    public void Clear()
    {
        this.FisrtElement = null;
    }

    public T this[int index]
    {
        get
        {
            if (this.FisrtElement == null) throw new NullReferenceException();
            var current = this.FisrtElement;
            if (index < 0) throw new IndexOutOfRangeException();
            for (int i = 0; i < index; i++, current = current.NextItem)
            {
                if (current == null) throw new IndexOutOfRangeException();
            }
            return current.Value;
        }
        set
        {
            if (this.FisrtElement == null) throw new NullReferenceException();
            var current = this.FisrtElement;
            if (index < 0) throw new IndexOutOfRangeException();
            for (int i = 0; i < index; i++, current = current.NextItem)
            {
                if (current == null) throw new IndexOutOfRangeException();
            }
            current.Value = value;
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        if (this.FisrtElement == null) return String.Empty;
        ListItem current = this.FisrtElement;
        output.AppendFormat("{0} ", current.Value.ToString());
        while (current.NextItem != null)
        {
            output.AppendFormat("{0} ", current.NextItem.Value.ToString());
            current = current.NextItem;
        }
        return output.ToString();
    }
}
