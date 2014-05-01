using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    private Node<T> root;

    public Tree(T value)
    {
        this.root = new Node<T>(value);
    }

    public Tree(Node<T> node)
    {
        this.root = node;
    }

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    private void TraverseDFS(Node<T> root, string spaces)
    {
        if (this.root == null)
        {
            return;
        }

        Console.WriteLine(spaces + root.Value);

        foreach (var child in root.Children)
        {
            TraverseDFS(child, spaces + "   ");
        }
    }

    public void TraverseDFS()
    {
        this.TraverseDFS(this.root, string.Empty);
    }

    public List<Node<T>> TraverseBFS()
    {
        var result = new List<Node<T>>();
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(this.root);
        while (queue.Count > 0)
        {
            Node<T> currentNode = queue.Dequeue();
            result.Add(currentNode);
            foreach (var child in currentNode.Children)
            {
                queue.Enqueue(child);
            }
        }
        return result;
    }

    public List<Node<T>> TraverseDFSWithStack()
    {
        var result = new List<Node<T>>();
        var stack = new Stack<Node<T>>();
        stack.Push(this.root);
        while (stack.Count > 0)
        {
            Node<T> currentNode = stack.Pop();
            result.Add(currentNode);
            foreach (var child in currentNode.Children)
            {
                stack.Push(child);
            }
        }
        return result;
    }
}
