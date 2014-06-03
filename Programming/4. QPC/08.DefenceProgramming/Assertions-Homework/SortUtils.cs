namespace _01.SortUtils
{
    using System;
    using System.Diagnostics;

    internal static class SortUtils
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null)
            {
                throw new ArgumentNullException("The array for sorting could not be null!");
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            if (arr == null)
            {
                throw new ArgumentNullException("The search array could not be null!");
            }

            if (value == null)
            {
                throw new ArgumentNullException("The search value could not be null!");
            }

            if (!new Func<bool>(() =>
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1].CompareTo(arr[i]) > 0)
                    {
                        return false;
                    }
                }

                return true;
            })())
            {
                throw new ArgumentException("The array has to be sorted!");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array could not be null!");
            Debug.Assert(arr.Length > 0, "The array length has to be greater than zero!");
            Debug.Assert(startIndex <= endIndex, "The start index has to be less or equal to end index!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index has to be in the range of the array!");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index has to be in the range of the array!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(
                new Func<bool>(() =>
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The minimal element index is not correct!");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null && y != null, "Could not swap with null!");
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array could not be null!");
            Debug.Assert(arr.Length > 0, "The array length has to be greater than zero!");
            Debug.Assert(value != null, "The search value could not be null!");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "The start index has to be in the range of the array!");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "The end index has to be in the range of the array!");
            Debug.Assert(startIndex <= endIndex, "The start index has to be less or equal to end index!");
            Debug.Assert(
                new Func<bool>(() =>
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1].CompareTo(arr[i]) > 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The array has to be sorted!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert(arr[midIndex].CompareTo(value) == 0, "The index of the search value is not correct!");
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            Debug.Assert(
                new Func<bool>(() =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].CompareTo(value) == 0)
                    {
                        return false;
                    }
                }

                return true;
            })(),
            "The value is present in the array but is not found!");

            // Searched value not found
            return -1;
        }
    }
}
