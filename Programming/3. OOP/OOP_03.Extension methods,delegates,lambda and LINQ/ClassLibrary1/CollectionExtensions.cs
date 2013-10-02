using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionExtensions
{
    public static class CollectionExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> collection) where T : struct, IConvertible
        {                                               //the constraint for T means it has to be value type that applies ConvertTo()
            decimal sum = 0;
            foreach (T item in collection)
            {
                sum += Convert.ToDecimal(item);
            }
            return sum;
        }

        public static decimal Average<T>(this IEnumerable<T> collection) where T : struct, IConvertible
        {
            decimal sum = 0;
            int count = 0;
            foreach (T item in collection)
            {
                sum += Convert.ToDecimal(item);
                count++;
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return sum / count;
            }
        }

        public static decimal Product<T>(this IEnumerable<T> collection) where T : struct, IConvertible
        {
            decimal prod = 1;
            IEnumerator<T> i = collection.GetEnumerator();
            if (!i.MoveNext())
            {
                return 0;
            }
            foreach (T item in collection)
            {
                prod *= Convert.ToDecimal(item);
            }
            return prod;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T> //value T must support CompareTo() method
        {
            IEnumerator<T> i = collection.GetEnumerator();
            i.MoveNext();
            T temp = i.Current;
            while (i.MoveNext())
            {
                if (i.Current.CompareTo(temp) == 1)
                {
                    temp = i.Current;
                }
            }
            return temp;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            IEnumerator<T> i = collection.GetEnumerator();
            i.MoveNext();
            T temp = i.Current;
            while (i.MoveNext())
            {
                if (i.Current.CompareTo(temp) == -1)
                {
                    temp = i.Current;
                }
            }
            return temp;
        }
    }
}
