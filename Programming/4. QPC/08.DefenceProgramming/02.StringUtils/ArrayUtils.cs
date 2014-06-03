namespace _02.Utils
{
    using System;
    using System.Collections.Generic;

    public static class ArrayUtils
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr", "The array could not be null!");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new IndexOutOfRangeException("The start index is out of the range of the array!");
            }

            if (count < 0)
            {
                throw new ArgumentException("count", "The count could not be less than zero!");
            }

            if (count + startIndex > arr.Length)
            {
                throw new ArgumentException("The sum of the count and start index must be less than the length of the array!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }
}
