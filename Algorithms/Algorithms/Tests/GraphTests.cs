using System;
using System.Collections.Generic;

using Algorithms.Sources.Graphs;
using Algorithms.Sources.Graphs.AdjacencyList;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void TestTraversals()
        {
            var graph = new Graph<int>();
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);
            var vertex8 = new Vertex<int>(8);
            
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);
            graph.AddVertex(vertex8);

            graph.AddUndirectedEdge(vertex1, vertex2, 45);
            graph.AddUndirectedEdge(vertex1, vertex3, 20);
            graph.AddUndirectedEdge(vertex2, vertex3, 30);
            graph.AddUndirectedEdge(vertex2, vertex4, 48);
            graph.AddUndirectedEdge(vertex3, vertex5, 25);
            graph.AddUndirectedEdge(vertex4, vertex5, 75);
            graph.AddUndirectedEdge(vertex3, vertex6, 100);
            graph.AddUndirectedEdge(vertex5, vertex6, 90);
            graph.AddUndirectedEdge(vertex5, vertex7, 70);
            graph.AddUndirectedEdge(vertex6, vertex8, 15);

            List<int> nodes = graph.Bfs();
            Assert.That(nodes, Is.EquivalentTo(new []{1, 2, 3, 4, 5, 6, 7, 8}));

            nodes = graph.Dfs();
            Assert.That(nodes, Is.EquivalentTo(new[] { 1, 2, 4, 5, 3, 6, 8, 7 }));
        }

        [Test]
        public void TestTraversalsWithAnotherGraph()
        {
            var graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddUndirectedEdge(1, 2);
            graph.AddUndirectedEdge(1, 3);
            graph.AddUndirectedEdge(2, 3);
            graph.AddUndirectedEdge(2, 4);
            graph.AddUndirectedEdge(3, 5);
            graph.AddUndirectedEdge(3, 6);
            graph.AddUndirectedEdge(4, 5);
            graph.AddUndirectedEdge(5, 6);
            graph.AddUndirectedEdge(5, 7);
            graph.AddUndirectedEdge(6, 8);

            List<int> nodes = graph.Bfs();
            Assert.That(nodes, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));

            nodes = graph.Dfs();
            Assert.That(nodes, Is.EquivalentTo(new[] { 1, 2, 3, 5, 6, 8, 7, 4 }));
        }

        [Test]
        public void TestTraversalsWithUnconnectedComponents()
        {
            var graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddUndirectedEdge(1, 2);
            graph.AddUndirectedEdge(2, 3);
            graph.AddUndirectedEdge(3, 4);
            graph.AddUndirectedEdge(2, 4);
            graph.AddUndirectedEdge(5, 6);
            graph.AddUndirectedEdge(6, 7);

            List<int> nodes = graph.Bfs();
            Assert.That(nodes, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7 }));

            nodes = graph.Dfs();
            Assert.That(nodes, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7 }));
        }

        [Test]
        public void TestDijkstra()
        {
            var graph = new Graph<int>();
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);
            var vertex8 = new Vertex<int>(8);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);
            graph.AddVertex(vertex8);

            graph.AddUndirectedEdge(vertex1, vertex2, 45);
            graph.AddUndirectedEdge(vertex1, vertex3, 20);
            graph.AddUndirectedEdge(vertex2, vertex3, 30);
            graph.AddUndirectedEdge(vertex2, vertex4, 48);
            graph.AddUndirectedEdge(vertex3, vertex5, 25);
            graph.AddUndirectedEdge(vertex4, vertex5, 75);
            graph.AddUndirectedEdge(vertex3, vertex6, 100);
            graph.AddUndirectedEdge(vertex5, vertex6, 110);
            graph.AddUndirectedEdge(vertex5, vertex7, 70);
            graph.AddUndirectedEdge(vertex6, vertex8, 15);

            Dictionary<int, int> costs = Dijkstra.Run(graph, graph.Vertexes[0]);
            foreach (var cost in costs)
            {
                Console.WriteLine("{0} : {1}", cost.Key, cost.Value);
            }
        }
    }
}