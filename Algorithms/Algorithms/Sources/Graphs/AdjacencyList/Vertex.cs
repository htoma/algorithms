using System.Collections.Generic;

namespace Algorithms.Sources.Graphs.AdjacencyList
{
    /// <summary>
    /// adjancency list
    /// </summary>
    public class Vertex<T>
    {
        public T Data { get; set; }
        public LinkedList<Edge<T>> Edges { get; set; }

        public Vertex(T data)
        {
            Data = data;
            Edges = new LinkedList<Edge<T>>();
        }

        public bool RemoveEdge(T to)
        {
            LinkedListNode<Edge<T>> node = Edges.First;
            while (node != null)
            {
                if (Equals(node.Value.To, to))
                {
                    Edges.Remove(node);
                    return true;
                }
                node = node.Next;
            }
            return false;
        }
    }
}