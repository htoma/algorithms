using Algorithms.Sources.Graphs.AdjacencyList;

namespace Algorithms.Sources.Graphs
{
    public class Edge<T>
    {
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
        public int Cost { get; set; }

        public Edge(Vertex<T> from, Vertex<T> to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Edge<T>) obj;
            return (From.Data.Equals(other.From.Data) && To.Data.Equals(other.To.Data)) || 
                (To.Data.Equals(other.From.Data) && From.Data.Equals(other.To.Data));
        }
    }
}