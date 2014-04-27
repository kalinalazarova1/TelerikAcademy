using System;

public class Stack<T>
{
    private const int INITIAL_SIZE = 4;
    private T[] InnerArray { get; set; }
    private int StackTop { get; set; }
    public int Count 
    {
        get
        {
            return this.StackTop;
        }
    }

    public Stack()
    {
        this.InnerArray = new T[INITIAL_SIZE];
        this.StackTop = 0;
    }

    public T Pop()
    {
        if (this.StackTop == 0) throw new InvalidOperationException("Stack is empty!");
        this.StackTop--;
        return this.InnerArray[this.StackTop];
    }

    public void Push(T item)
    {
        if(this.StackTop == this.InnerArray.Length)
        {
            T[] resizedArray = new T[this.InnerArray.Length * 2];
            Array.Copy(this.InnerArray, resizedArray, this.InnerArray.Length);
            this.InnerArray = resizedArray;
        }
        this.InnerArray[this.StackTop] = item;
        this.StackTop++;
    }

    public T Peek()
    {
        if (this.StackTop == 0) throw new InvalidOperationException("Stack is empty!");
        return this.InnerArray[this.StackTop - 1];
    }

    public void Clear()
    {
        this.StackTop = 0;
        this.InnerArray = new T[4];
    }

    public T[] ToArray()
    {
        var result = new T[this.StackTop];
        Array.Copy(this.InnerArray, result, result.Length);
        return result;
    }
}
