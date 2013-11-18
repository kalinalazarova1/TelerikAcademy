using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Binary_Search_Tree
{
    public class BST<T> : ICloneable, IEnumerable<T> where T : IComparable<T>
    {
        //properties:
        private TreeNode<T> Root { get; set; }

        //constructors:
        public BST(T value)
        {
            this.Root = new TreeNode<T>(value); 
        }

        public BST()
        {
            this.Root = null;
        }
        //methods
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("The value for insertion could not be null!");
            }
            if (this.Root == null)
            {
                this.Root = new TreeNode<T>(value);
            }
            else
            {
                this.Root = Insert(value, null, this.Root);
            }
        }

        private TreeNode<T> Insert(T value, TreeNode<T> parent, TreeNode<T> current)
        {
            if (current == null)
            {
                current = new TreeNode<T>(value, parent);
            }
            else
            {
                if (value.CompareTo(current.Value) < 0)
                {   
                    current.LeftChild = Insert(value, current, current.LeftChild);
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    current.RightChild = Insert(value, current, current.RightChild);
                }
            }
            return current;
        }

        //private internal class visible only in BST class and encapsulated for the outer world
        private class TreeNode<V> : IComparable<TreeNode<V>> where V : IComparable<V>
        {
            public T Value { get; set; }
            public TreeNode<V> LeftChild { get; set; }
            public TreeNode<V> RightChild { get; set; }
            public TreeNode<V> Parent { get; set; }

            public TreeNode(T value, TreeNode<V> parent)
            {
                this.Value = value;
                this.Parent = parent;
            }

            public TreeNode(T value) : this(value, null)
            {
            }


            public int CompareTo(TreeNode<V> other)
            {
                return this.Value.CompareTo(other.Value);
            }

            public override bool Equals(Object obj)
            {
                TreeNode<V> node = obj as TreeNode<V>;
                if ((object)node == null)
                {
                    return false;
                }
                else
                {
                    return this.CompareTo(node) == 0;
                }
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public static bool operator ==(TreeNode<V> first, TreeNode<V> second)
            {
                if ((object)first == null && (object)second == null)
                {
                    return true;
                }
                else if ((object)first == null || (object)second == null)
                {
                    return false;
                }
                else
                {
                    return first.Equals(second);
                }
            }

            public static bool operator !=(TreeNode<V> first, TreeNode<V> second)
            {
                if ((object)first == null && (object)second == null)
                {
                    return false;
                }
                else if ((object)first == null || (object)second == null)
                {
                    return true;
                }
                else
                {
                    return !first.Equals(second);
                }
            }
        }
        
        //in order walk means DFS - left node, then root and then right node, used for IEnumerable interface
        private void InOrderWalk(TreeNode<T> start, ref List<T> nodeValues)
        {
            if(start == null)
            {
                return;
            }
            InOrderWalk(start.LeftChild, ref nodeValues);
            nodeValues.Add(start.Value);
            InOrderWalk(start.RightChild, ref nodeValues);
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> nodeValues = new List<T>();
            InOrderWalk(this.Root, ref nodeValues);
            foreach (var value in nodeValues)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var node in this)
            {
                output.Append(node);
                output.Append(' ');
            }
            return output.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var node in this)
            {
                hash ^= node.GetHashCode();
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            BST<T> other = obj as BST<T>;
            if ((object)other == null)
            {
                return false;
            }
            bool isEqual = true;
            Equals(this.Root, other.Root, ref isEqual);
            return isEqual;
        }

        private void Equals(TreeNode<T> startFirst, TreeNode<T> startSecond, ref bool isEqual)
        {
            if ((object)startFirst == null)
            {
                if ((object)startSecond != null)
                {
                    isEqual = false;
                }
                return;
            }
            if (!startFirst.Equals(startSecond))
            {
                isEqual = false;
            }
            Equals(startFirst.LeftChild, startSecond.LeftChild, ref isEqual);
            Equals(startFirst.RightChild, startSecond.RightChild, ref isEqual);
        }

        public static bool operator ==(BST<T> first, BST<T> second)
        {
            if ((object)first == null && (object)second == null)
            {
                return true;
            }
            else if ((object)first == null || (object)second == null)
            {
                return false;
            }
            else
            {
                return first.Equals(second);
            }
        }

        public static bool operator !=(BST<T> first, BST<T> second)
        {
            return !first.Equals(second);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
        
        public BST<T> Clone()
        {
            BST<T> clone = new BST<T>(this.Root.Value);
            Clone(this.Root, ref clone);
            return clone;
        }

        private void Clone(TreeNode<T> start, ref BST<T> clone)
        {
            if (start == null)
            {
                return;
            }
            clone.Insert(start.Value);
            Clone(start.LeftChild, ref clone);
            Clone(start.RightChild, ref clone);
        }

        public bool Search(T value)
        {
            TreeNode<T> match = null;
            Search(this.Root, value, ref match);
            if (match == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Search(TreeNode<T> start, T value, ref TreeNode<T> match)
        {
            if (start == null)
            {
                return;
            }
            if (start.Value.CompareTo(value) > 0)
            {
                Search(start.LeftChild, value, ref match);
            }
            else if (start.Value.CompareTo(value) < 0)
            {
                Search(start.RightChild, value, ref match);
            }
            else
            {
                match = start;
            }
        }

        public void Remove(T value)
        {
            TreeNode<T> removeNote = null;
            this.Search(this.Root, value, ref removeNote);
            if (removeNote == null)
            {
                return;
            }
            this.Remove(removeNote);
        }

        private void Remove(TreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                TreeNode<T> temp = node.RightChild;
                while (temp.LeftChild != null)
                {
                    temp = temp.LeftChild;
                }
                node.Value = temp.Value;
                Remove(temp);
            }
            else if (node.LeftChild == null && node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    this.Root = null;
                }
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else
                {
                    node.Parent.RightChild = null;
                }
            }
            else
            {
                TreeNode<T> temp = (node.LeftChild == null ? node.RightChild : node.LeftChild);
                if (node.Parent == null)
                {
                    this.Root = temp;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = temp;
                    }
                    else
                    {
                        node.Parent.RightChild = temp;
                    }
                    temp.Parent = node.Parent;
                }
            }
        }
    }
}
