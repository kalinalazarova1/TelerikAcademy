using System;
using System.Collections.Generic;

public class TrieNode
{
    public TrieNode(char letter)
    {
        this.Children = new Dictionary<char, TrieNode>();
        this.Value = letter;
        this.IsWord = false; // used when Trie is build from keywords
        this.Count = 0;      // used when Trie is build from the whole text
    }

    public char Value { get; set; }

    public Dictionary<char, TrieNode> Children { get; set; }

    public bool IsWord { get; set; }

    public int Count { get; set; }
}