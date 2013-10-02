//5. Write a generic class GenericList that keeps a list of elements of some parametric type T. 
//Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
//6.Implement auto-grow functionality: when the internal array is full, create a new array of double
//size and move all elements to it.
//7. Create generic methods Min() and Max() for finding the minimal and maximal element in the GenericList.
//You may need to add a generic constraints for the type T.


using System;
using GenericList;

namespace ListTest
{
    class ListTest
    {
        static void Main()
        {
            int[] arr = { 5, 7, 13, 24, 18 , 3, 0};
            List<int> testList = new List<int>();       //create an instance of class GenericList.List<T>
            for (int i = 0; i < arr.Length; i++)
            {
                testList.Add(arr[i]);                   //test add elements and auto-grow feature because the default capacity is 5 and the elements are 7
            }
            Console.WriteLine(testList.ToString());     //test print using ToString()
            testList.Insert(2, 8);                      //test insert in the middle
            Console.WriteLine(testList.ToString());
            testList.Insert(8, -1);                     //test insert at the end
            Console.WriteLine(testList.ToString());
            testList.RemoveAt(3);                       //test remove element
            Console.WriteLine(testList.ToString());
            Console.WriteLine("Min: {0}", testList.Min());//test find minimal element
            Console.WriteLine("Max: {0}", testList.Max());//test find maximal element
            Console.WriteLine(testList.IndexOf(24));      //test find the index of a value 
            testList.Clear();                             //test list clear method
            Console.WriteLine(testList.ToString());
            testList.Insert(0, 10);                        //test insert at index 0 in an empty list
            Console.WriteLine(testList.ToString());
        }
    }
}
