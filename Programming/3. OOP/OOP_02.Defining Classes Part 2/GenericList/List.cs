using System;
using System.Text;

namespace GenericList
{
    public class List<T> where T : IComparable  //the generic class variable T must apply IComparable interface
                                                //the methods Min() and Max() use method CompareTo()
    {
        private T[] items;                      //no property for this field because it must not be accessed outside the class
        private int count;                      //contains the number of the elements in the list

        const int defaultCapacity = 5;          //the default capacity is set to only 5 in order to test the EnsureCapacity() method

        public int Count 
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public List(int capacity)
        {
            this.items = new T[capacity];
            this.Count = 0;
        }

        public List() : this(defaultCapacity)
        {
        }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.EnsureCapacity(); 
            }
            this[this.Count] = item;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                this.Count--;
                while (index < this.Count)
                {
                    items[index] = items[index + 1];
                    index++;
                }
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)        //insertion is possible after the last element of the list
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (this.Count == this.items.Length)
                {
                    this.EnsureCapacity();
                }
                int pointer = this.Count;
                this.Count++;
                while (pointer > index)
                {
                    this.items[pointer] = this.items[pointer - 1];
                    pointer--;
                }
                this.items[index] = item;
            }
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.items, item);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                output.Append(this.items[i]);
                output.Append(' ');
            }
            return output.ToString();
        }
        
        private void EnsureCapacity()
        {
            T[] temp = new T[this.items.Length * 2];
            Array.Copy(this.items, temp, this.items.Length);
            items = new T[this.items.Length * 2];
            Array.Copy(temp, this.items, temp.Length);
        }
        
        public T Min()
        {
            T temp = this[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this[i].CompareTo(temp) == -1)
                {
                    temp = this[i];
                }
            }
            return temp;
        }

        public T Max()
        {
            T temp = this[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this[i].CompareTo(temp) == 1)
                {
                    temp = this[i];
                }
            }
            return temp;
        }
    }
}
