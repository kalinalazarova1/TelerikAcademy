namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var mergeCollection = new T[collection.Count];
            this.MergeSort(collection, mergeCollection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, IList<T> mergeCollection, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int m = l + ((r - l) / 2);
            this.MergeSort(collection, mergeCollection, l, m);
            this.MergeSort(collection, mergeCollection, m + 1, r);
            this.Merge(collection, mergeCollection, l, m, r);
        }

        private void Merge(IList<T> collection, IList<T> mergeCollection, int l, int m, int r)
        {
            for (int i = l, left = l, right = m + 1; left <= m || right <= r; i++)
            {
                if (left > m)
                {
                    mergeCollection[i] = collection[right++];
                }
                else if (right > r)
                {
                    mergeCollection[i] = collection[left++];
                }
                else if (collection[left].CompareTo(collection[right]) <= 0)
                {
                    mergeCollection[i] = collection[left++];
                }
                else if (collection[left].CompareTo(collection[right]) > 0)
                {
                    mergeCollection[i] = collection[right++];
                }
            }

            for (int i = l; i <= r; i++)
            {
                collection[i] = mergeCollection[i];
            }

            return;
        }
    }
}
