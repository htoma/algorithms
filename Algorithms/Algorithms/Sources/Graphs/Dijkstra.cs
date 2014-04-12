using System.Collections.Generic;
using System.Linq;

using Algorithms.Sources.Graphs.AdjacencyList;

namespace Algorithms.Sources.Graphs
{
    public static class Dijkstra
    {
        public static Dictionary<int, int> Run(Graph<int> graph, Vertex<int> start)
        {
            // in order to retrieve the vertex directly
            var vertexes = new Dictionary<int, Vertex<int>>();
            var costs = new Dictionary<int, int>();
            var toPick = new HashSet<int>();

            foreach (Vertex<int> vertex in graph.Vertexes)
            {
                vertexes[vertex.Data] = vertex;
                costs[vertex.Data] = int.MaxValue;
                toPick.Add(vertex.Data);
            }

            costs[start.Data] = 0;
            while (toPick.Count > 0)
            {
                // pick the vertex with the minimum cost
                int data = pickMin(toPick, costs);
                toPick.Remove(data);
                Vertex<int> vertex = vertexes[data];
                foreach (Edge<int> edge in vertex.Edges.Where(x => toPick.Contains(x.To.Data)))
                {
                    int cumulateCost = costs[vertex.Data] + edge.Cost;
                    if (costs[edge.To.Data] > cumulateCost)
                    {
                        costs[edge.To.Data] = cumulateCost;
                    }
                }
            }

            return costs;
        }

        private static int pickMin(IEnumerable<int> toPick, Dictionary<int, int> costs)
        {
            int min = int.MaxValue;
            int data = 0;
            foreach (int element in toPick)
            {
                if (costs[element] < min)
                {
                    min = costs[element];
                    data = element;
                }
            }
            return data;
        }
    }
}