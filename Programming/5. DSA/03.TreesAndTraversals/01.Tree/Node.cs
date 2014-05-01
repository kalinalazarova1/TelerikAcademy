using System;
using System.Collections.Generic;

public class Node<T> 
{
    private List<Node<T>> children;
    public Node()
    {
        this.children = new List<Node<T>>();
        this.HasParent = false;
    }
    public Node(T value)
        : this()
    {
        this.Value = value;
    }

    public List<Node<T>> Children 
    {
        get
        {
            return this.children;
        }
            
    }

    public T Value { get; set; }

    public bool HasParent { get; private set; }

    public void AddChild(Node<T> child)
    {
        this.Children.Add(child);
        child.HasParent = true;
    }
}
