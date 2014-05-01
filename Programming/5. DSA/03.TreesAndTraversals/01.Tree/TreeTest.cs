//1. You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node),
//each in the range (0..N-1). Example:
// 7
// 2 4
// 3 2
// 5 0
// 3 5
// 5 6
// 5 1
// Write a program to read the tree and find:
// a) the root node
// b) all leaf nodes
// c) all middle nodes
// d) the longest path in the tree
// e)* all paths in the tree with given sum S of their nodes
// f)* all subtrees with given sum S of their nodes

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int s = 6;
        var nodes = new Node<int>[n];
        for (int i = 0; i < n; i++)
        {
            nodes[i] = new Node<int>(i);
        }

        for (int i = 0; i < n - 1; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            nodes[int.Parse(input[0])].AddChild(nodes[int.Parse(input[1])]);
        }

        Console.WriteLine("The tree structure is:");
        var tree = new Tree<int>(GetRoot(nodes));
        tree.TraverseDFS();
        //task 1 a):
        Console.WriteLine("The root is: {0}", GetRoot(nodes).Value);
        //task 1 b):
        Console.WriteLine("The leafs are: {0}", string.Join(", ", GetLeaves(nodes).Select(node => node.Value)));
        //task 1 c):
        Console.WriteLine("The middle nodes are: {0}", string.Join(", ", GetMiddleNodes(nodes).Select(node => node.Value)));
        //task 1 d):
        Console.WriteLine("The longest path in the tree from the root is {0} steps", FindLongestPathDFS(GetRoot(nodes)));
        //task 1 e*):
        Console.WriteLine("The paths with sum {0} are:", s);
        foreach (var node in nodes)
        {
            AllPathsFromNode(node);
            var output = string.Join(Environment.NewLine, allPaths.Where(x => x.Sum(y => y.Value) == s).Select(x => string.Join("->", x.Select(y => y.Value))));
            if(output != string.Empty)
            {
                Console.WriteLine(output);
            }
            allPaths.Clear();
            currentPath.Clear();
        }
        //task 1 f*):
        var subTreesRoots = new List<Node<int>>();
        foreach (var node in nodes)
        {
            var subTree = new Tree<int>(node);
            if(subTree.TraverseBFS().Sum(x => x.Value) == s)
            {
                subTreesRoots.Add(node);
            }
        }
        Console.WriteLine("The subtrees with sum {0} have roots:", s);
        Console.WriteLine(string.Join(", ", subTreesRoots.Select(x => x.Value)));
    }

    static Node<int> GetRoot(Node<int>[] nodes)
    {
        return nodes.First(node => !node.HasParent);
    }

    static IEnumerable<Node<int>> GetLeaves(Node<int>[] nodes)
    {
        return nodes.Where(node => node.Children.Count == 0);
    }

    static IEnumerable<Node<int>> GetMiddleNodes(Node<int>[] nodes)
    {
        return nodes.Where(node => node.Children.Count != 0 && node.HasParent);
    }

    static int FindLongestPathDFS(Node<int> root)
    {
        int longestPath = 0;
        if (root.Children.Count == 0)
        {
            return 0;
        }
        foreach (var child in root.Children)
        {
            longestPath = Math.Max(longestPath, FindLongestPathDFS(child));
        }

        return longestPath + 1;
    }

    static List<List<Node<int>>> allPaths = new List<List<Node<int>>>();
    static List<Node<int>> currentPath = new List<Node<int>>();

    static void AllPathsFromNode(Node<int> node)
    {
        currentPath.Add(node);
        if (node.Children.Count == 0)
        {
            allPaths.Add(currentPath.GetRange(0, currentPath.Count));
            return;
        }

        foreach (var child in node.Children)
        {  
            AllPathsFromNode(child);
            currentPath.RemoveAt(currentPath.Count - 1);
            bool isFound = false;
            for (int i = 0; i < allPaths.Count; i++)
            {
                if (Enumerable.SequenceEqual(currentPath.GetRange(0, currentPath.Count), allPaths[i].GetRange(0, allPaths[i].Count)))
                {
                    isFound = true;
                }
            }
            if(!isFound)
            {
                allPaths.Add(currentPath.GetRange(0, currentPath.Count));
            }
        }
    }
}