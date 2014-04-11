using Algorithms.Sources.Graphs.AdjacencyList;

namespace Algorithms.Sources.Graphs
{
    public class Edge<T>
    {
        public Vertex<T> To { get; set; }
        public int Cost { get; set; }

        public Edge(Vertex<T> to, int cost)
        {
            To = to;
            Cost = cost;
        } 
    }
}