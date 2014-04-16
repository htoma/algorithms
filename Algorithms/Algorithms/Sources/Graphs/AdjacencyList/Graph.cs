using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sources.Graphs.AdjacencyList
{
    public class Graph<T>
    {
        public List<Vertex<T>> Vertexes { get; set; }

        public Graph()
        {
            Vertexes = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddVertex(T value)
        {
            Vertexes.Add(new Vertex<T>(value));
        }

        public void AddDirectedEdge(Vertex<T> from, Vertex<T> to, int cost = 0)
        {
            from.Edges.AddLast(new Edge<T>(from, to, cost));
        }

        public void AddDirectedEdge(T from, T to, int cost = 0)
        {
            Vertex<T> fromNode = Find(from);
            if (fromNode == null)
            {
                return;
            }

            Vertex<T> toNode = Find(to);
            if (toNode == null)
            {
                return;
            }

            AddDirectedEdge(fromNode, toNode, cost);
        }

        public void AddUndirectedEdge(Vertex<T> from, Vertex<T> to, int cost = 0)
        {
            from.Edges.AddLast(new Edge<T>(from, to, cost));
        }

        public void AddUndirectedEdge(T from, T to, int cost = 0)
        {
            Vertex<T> fromNode = Find(from);
            if (fromNode == null)
            {
                return;
            }

            Vertex<T> toNode = Find(to);
            if (toNode == null)
            {
                return;
            }

            AddUndirectedEdge(fromNode, toNode, cost);
        }

        public Vertex<T> Find(T value)
        {
            Vertex<T> vertex = Vertexes.Find(x => Equals(x.Data, value));
            return vertex;
        }

        public bool Remove(T value)
        {
            Vertex<T> vertex = Find(value);
            if (vertex == null)
            {
                return false;
            }
            Vertexes.Remove(vertex);

            foreach (Vertex<T> node in Vertexes)
            {
                node.RemoveEdge(value);
            }

            return true;
        }

        /// <summary>
        /// breadth first search
        /// </summary>
        public List<T> Bfs()
        {
            var result = new List<T>();
            if (Vertexes.Count == 0)
            {
                return result;
            }

            if (Vertexes.Count == 1)
            {
                result.Add(Vertexes[0].Data);
                return result;
            }
            
            var queue = new Queue<Vertex<T>>();            
            var nodesChecked = new HashSet<T>();

            while (true)
            {
                Vertex<T> nextToAdd = Vertexes.FirstOrDefault(x => !nodesChecked.Contains(x.Data));
                if (nextToAdd == null)
                {
                    break;
                }
                queue.Enqueue(nextToAdd);
                nodesChecked.Add(nextToAdd.Data);

                while (queue.Count > 0)
                {
                    Vertex<T> node = queue.Dequeue();
                    result.Add(node.Data);
                    foreach (Edge<T> edge in node.Edges)
                    {
                        if (!nodesChecked.Contains(edge.To.Data))
                        {
                            queue.Enqueue(edge.To);
                            nodesChecked.Add(edge.To.Data);
                        }
                    }
                }
            }

            return result;
        }

        public List<T> Dfs()
        {
            var result = new List<T>();
            if (Vertexes.Count == 0)
            {
                return result;
            }

            if (Vertexes.Count == 1)
            {
                result.Add(Vertexes[0].Data);
                return result;
            }

            var queue = new Queue<Vertex<T>>();
            var nodesChecked = new HashSet<T>();

            while (true)
            {
                Vertex<T> nextToAdd = Vertexes.FirstOrDefault(x => !nodesChecked.Contains(x.Data));
                if (nextToAdd == null)
                {
                    break;
                }
                queue.Enqueue(nextToAdd);
                nodesChecked.Add(nextToAdd.Data);

                while (queue.Count > 0)
                {
                    Vertex<T> node = queue.Dequeue();
                    result.Add(node.Data);
                    dfsNode(node, queue, nodesChecked);
                }
            }

            return result;
        }

        public static bool DetectCycle(Graph<T> graph)
        {
            if (graph == null || graph.Vertexes.Count < 3)
            {
                return false;
            }

            var visitedVertexes = new Dictionary<T, bool>();
            foreach (Vertex<T> vertex in graph.Vertexes)
            {
                visitedVertexes[vertex.Data] = false;
            }

            return detectCycle(graph.Vertexes[0], visitedVertexes, new HashSet<Edge<T>>());
        }

        private static bool detectCycle(Vertex<T> vertex, Dictionary<T, bool> visitedVertexes, HashSet<Edge<T>> checkedEdges)
        {
            visitedVertexes[vertex.Data] = true;
            foreach (Edge<T> edge in vertex.Edges)
            {
                if (!visitedVertexes[edge.To.Data])
                {
                    // never been to this vertex
                    checkedEdges.Add(edge);
                    if (detectCycle(edge.To, visitedVertexes, checkedEdges))
                    {
                        return true;
                    }
                }
                else
                {
                    // node hit previously
                    if (!checkedEdges.Contains(edge))
                    {
                        // reached coming from some other node, oups! cycle detected
                        return true;
                    }
                }
            }
            return false;
        }

        private void dfsNode(Vertex<T> node, Queue<Vertex<T>> queue, HashSet<T> nodesChecked)
        {
            foreach (Edge<T> edge in node.Edges)
            {
                if (!nodesChecked.Contains(edge.To.Data))
                {
                    queue.Enqueue(edge.To);
                    nodesChecked.Add(edge.To.Data);
                    dfsNode(edge.To, queue, nodesChecked);
                }
            }
        }
    }
}