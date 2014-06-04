namespace SortingComparison
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = this.SelectionSort(collection);
        }

        private IList<T> SelectionSort(IList<T> collection)
        {
            int min;
            T forSwap;
            for (int i = 0; i < collection.Count; i++)
            {
                min = i;
                for (int j = i; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                forSwap = collection[i];
                collection[i] = collection[min];
                collection[min] = forSwap;
            }

            return collection;
        }
    }
}
