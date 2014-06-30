namespace _03.CableCompany
{
    using System;

    public class Edge<T> : IComparable
    {
        public Edge(T start, T end, int weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }

        public T Start { get; set; }

        public T End { get; set; }

        public int Weight { get; set; }

        public int CompareTo(object obj)
        {
            return this.Weight.CompareTo((obj as Edge<T>).Weight);
        }
    }
}
