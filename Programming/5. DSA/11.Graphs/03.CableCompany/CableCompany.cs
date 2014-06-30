// 3.You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house).
// If it is constrained to bury the cable only along certain paths, then there would be a graph representing which
// points are connected by those paths. But the cost of some of the paths is more expensive because they are longer.
// If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.

namespace _03.CableCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class CableCompany
    {
        public static List<Edge<int>> GetMinimalspanningTreeUsingPrim(List<Edge<int>> graph, int start)
        {
            var result = new List<Edge<int>>();
            var priority = new OrderedBag<Edge<int>>();
            var visited = new HashSet<int>();
            visited.Add(start);
            foreach (var edge in graph)
            {
                if (edge.Start == start || edge.End == start)
                {
                    priority.Add(edge);
                }
            }

            while (priority.Count > 0)
            {
                var current = priority.RemoveFirst();
                if (!(visited.Contains(current.Start) && visited.Contains(current.End)))
                {
                    result.Add(current);
                }

                if (visited.Contains(current.Start) && !visited.Contains(current.End))
                {
                    priority.AddMany(graph.Where(x => x.Start == current.End || x.End == current.End));
                    visited.Add(current.End);
                }
                else if (!visited.Contains(current.Start) && visited.Contains(current.End))
                {
                    priority.AddMany(graph.Where(x => x.Start == current.Start || x.End == current.Start));
                    visited.Add(current.Start);
                }
            }

            return result;
        }

        internal static void Main()
        {
            var neighbourhood = new List<Edge<int>>();

            // neighbourhood.Add(new Edge<int>(1, 2, 14));
            // neighbourhood.Add(new Edge<int>(1, 3, 10));
            // neighbourhood.Add(new Edge<int>(2, 4, 14));
            // neighbourhood.Add(new Edge<int>(1, 5, 18));
            // neighbourhood.Add(new Edge<int>(2, 6, 9));
            // neighbourhood.Add(new Edge<int>(3, 6, 10));
            // neighbourhood.Add(new Edge<int>(3, 4, 14));
            // neighbourhood.Add(new Edge<int>(7, 8, 9));
            // neighbourhood.Add(new Edge<int>(4, 7, 15));
            // neighbourhood.Add(new Edge<int>(4, 8, 11));
            // neighbourhood.Add(new Edge<int>(9, 10, 7));
            // neighbourhood.Add(new Edge<int>(1, 10, 10));
            // neighbourhood.Add(new Edge<int>(3, 9, 11));
            // neighbourhood.Add(new Edge<int>(8, 11, 8));
            // neighbourhood.Add(new Edge<int>(11, 12, 12));
            // neighbourhood.Add(new Edge<int>(9, 12, 17));
            // neighbourhood.Add(new Edge<int>(5, 10, 13));
            // neighbourhood.Add(new Edge<int>(6, 12, 15));
            // neighbourhood.Add(new Edge<int>(7, 13, 7));
            // neighbourhood.Add(new Edge<int>(8, 13, 10));
            // neighbourhood.Add(new Edge<int>(11, 13, 13));
            // neighbourhood.Add(new Edge<int>(7, 12, 12));
            // neighbourhood.Add(new Edge<int>(11, 14, 7));
            // neighbourhood.Add(new Edge<int>(12, 14, 10));
            neighbourhood.Add(new Edge<int>(1, 3, 5));
            neighbourhood.Add(new Edge<int>(1, 2, 4));
            neighbourhood.Add(new Edge<int>(1, 4, 9));
            neighbourhood.Add(new Edge<int>(2, 4, 2));
            neighbourhood.Add(new Edge<int>(3, 4, 20));
            neighbourhood.Add(new Edge<int>(3, 5, 7));
            neighbourhood.Add(new Edge<int>(4, 5, 8));
            neighbourhood.Add(new Edge<int>(4, 7, 6));
            neighbourhood.Add(new Edge<int>(5, 6, 12));
            neighbourhood.Add(new Edge<int>(6, 8, 2));
            neighbourhood.Add(new Edge<int>(7, 8, 4));

            var forWiring = GetMinimalspanningTreeUsingPrim(neighbourhood, 1);

            foreach (var wire in forWiring)
            {
                Console.WriteLine("Wire from {0} to {1} -> length: {2}", wire.Start, wire.End, wire.Weight);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Total wire length: {0}", forWiring.Sum(x => x.Weight));
        }
    }
}
