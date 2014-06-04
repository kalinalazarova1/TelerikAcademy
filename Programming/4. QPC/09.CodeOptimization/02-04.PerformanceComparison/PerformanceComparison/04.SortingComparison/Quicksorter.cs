namespace SortingComparison
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int l, int r)
        {
            if (l < r)
            {
                int pivotIndex = new Random().Next(l, r + 1);
                pivotIndex = this.Partition(collection, l, r, pivotIndex);
                this.QuickSort(collection, l, pivotIndex - 1);
                this.QuickSort(collection, pivotIndex + 1, r);
            }
        }

        private void Swap(IList<T> collection, int i, int j)
        {
            T forSwap = collection[i];
            collection[i] = collection[j];
            collection[j] = forSwap;
        }

        private int Partition(IList<T> collection, int l, int r, int pivotIndex)
        {
            T pivotValue = collection[pivotIndex];
            this.Swap(collection, pivotIndex, r);
            int j = l;
            for (int i = l; i < r; i++)
            {
                if (collection[i].CompareTo(pivotValue) < 0)
                {
                    this.Swap(collection, i, j++);
                }
            }

            this.Swap(collection, r, j);
            return j;
        }
    }
}
