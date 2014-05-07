using System;
using System.Collections.Generic;
using System.Linq;

public class Trie
{
    public Trie(TrieNode root)
    {
        this.Root = root;
    }

    public TrieNode Root { get; set; }

    public void Add(string word)
    {
        this.Insert(word, this.Root);
    }

    public bool Contains(string word)
    {
        return this.IsFound(word, this.Root);
    }

    public bool TryFindCount(string word, out int count)
    {
        return this.TryFind(word, this.Root, out count);
    }

    private void Insert(string word, TrieNode root)
    {
        root.Count++;
        if (word == string.Empty)
        {
            root.IsWord = true;
            return;
        }

        if (!root.Children.ContainsKey(word[0]))
        {
            root.Children[word[0]] = new TrieNode(word[0]);
        }

        this.Insert(word.Length == 1 ? string.Empty : word.Substring(1), root.Children[word[0]]);
    }

    private bool IsFound(string word, TrieNode root)
    {
        if (word == string.Empty)
        {
            if (root.IsWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (!root.Children.ContainsKey(word[0]))
        {
            return false;
        }

        return this.IsFound(word.Length == 1 ? string.Empty : word.Substring(1), root.Children[word[0]]);
    }

    private bool TryFind(string word, TrieNode root, out int count)
    {
        if (word == string.Empty)
        {
            if (root.IsWord)
            {
                count = root.Count - root.Children.Sum(ch => ch.Value.Count);
                return true;
            }
            else
            {
                count = 0;
                return false;
            }
        }

        if (!root.Children.ContainsKey(word[0]))
        {
            count = 0;
            return false;
        }

        return this.TryFind(word.Length == 1 ? string.Empty : word.Substring(1), root.Children[word[0]], out count);
    }
}