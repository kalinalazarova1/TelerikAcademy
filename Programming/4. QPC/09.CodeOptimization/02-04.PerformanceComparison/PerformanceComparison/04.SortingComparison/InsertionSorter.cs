namespace SortingComparison
{
    using System;
    using System.Collections.Generic;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = this.InsertionSort(collection);
        }

        private IList<T> InsertionSort(IList<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                T value = collection[i];
                int j = i;

                while ((j > 0) && (collection[j - 1].CompareTo(value) > 0))
                {
                    collection[j] = collection[j - 1];
                    j = j - 1;
                }

                collection[j] = value;
            }

            return collection;
        }
    }
}
