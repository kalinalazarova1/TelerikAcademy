// 1.Add assertions in the code from the project "Assertions-Homework" to ensure
// all possible preconditions and postconditions are checked.

namespace _01.SortUtils
{
    using System;

    internal static class SortUtilsTest
    {
        internal static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            try
            {
                Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
                SortUtils.SelectionSort(arr);
                Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

                SortUtils.SelectionSort(new int[0]); // Test sorting empty array
                SortUtils.SelectionSort(new int[1]); // Test sorting single element array

                Console.WriteLine(SortUtils.BinarySearch(arr, -1000));
                Console.WriteLine(SortUtils.BinarySearch(arr, 0));
                Console.WriteLine(SortUtils.BinarySearch(arr, 17));
                Console.WriteLine(SortUtils.BinarySearch(arr, 10));
                Console.WriteLine(SortUtils.BinarySearch(arr, 1000));
            }
            catch (ArgumentNullException aue)
            {
                Console.WriteLine(aue.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}