//6.*  Define the data structure binary search tree with operations for "adding new element", "searching element"
//and "deleting elements". It is not necessary to keep the tree balanced. Implement the standard methods
//from System.Object – ToString(), Equals(…), GetHashCode() and the operators for comparison  == and
//!=. Add and implement the ICloneable interface for deep copy of the tree. Remark: Use two types – 
//structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements).


using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Search_Tree
{
    public class BSTTest
    {
        static void Main()
        {
            BST<int> test = new BST<int>();
            test.Insert(5);
            test.Insert(2);
            test.Insert(4);
            test.Insert(6);
            test.Insert(8);
            test.Insert(9);
            test.Insert(1);
            test.Insert(11);
            test.Insert(3);
            Console.WriteLine("My test tree:\t{0}", test);
            Console.WriteLine("Hash code:\t{0}", test.GetHashCode());
            BST<int> testClone = test.Clone();
            Console.WriteLine("The original and the clone are equal: {0}", test.Equals(testClone));
            Console.WriteLine("Change in clone - insert value 10:");
            testClone.Insert(10);
            Console.WriteLine("Clone:\t\t{0}", testClone);
            Console.WriteLine("Original:\t{0}", test);
            Console.WriteLine("Contains 3:\t{0}", test.Search(3));
            Console.WriteLine("Contains 13:\t{0}", test.Search(13));
            Console.WriteLine();
            Console.WriteLine("My test tree:\t{0}", test);
            int value = 3;
            Console.WriteLine("Remove number {0}:", value);
            test.Remove(value);
            Console.WriteLine("My test tree:\t{0}", test);
            value = 2;
            Console.WriteLine("Remove number {0}:", value);
            test.Remove(value);
            Console.WriteLine("My test tree:\t{0}", test);
            value = 5;
            Console.WriteLine("Remove number {0}:", value);
            test.Remove(value);
            Console.WriteLine("My test tree:\t{0}", test);
            value = 9;
            Console.WriteLine("Remove number {0}:", value);
            test.Remove(value);
            Console.WriteLine("My test tree:\t{0}", test);
            value = 11;
            Console.WriteLine("Remove number {0}:", value);
            test.Remove(value);
            Console.WriteLine("My test tree:\t{0}", test);
        }
    }
}
