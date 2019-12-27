using System;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    /// <summary>
    /// Oriented graph implementation
    /// </summary>
    public class Graph
    {
        public Graph(IEnumerable<Vertex> vertices, IEnumerable<Tuple<Vertex, Vertex>> edges)
        {
            foreach (var vertex in vertices)
            {
                InitVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public Dictionary<Vertex, HashSet<Vertex>> Vertices { get; } = new Dictionary<Vertex, HashSet<Vertex>>();

        private void InitVertex(Vertex vertex)
        {
            if (Vertices.ContainsKey(vertex))
            {
                Vertices[vertex] = new HashSet<Vertex>();
                return;
            }

            Vertices[vertex] = new HashSet<Vertex>();
        }

        private void AddEdge(Tuple<Vertex, Vertex> edge)
        {
            if (Vertices.ContainsKey(edge.Item1) && Vertices.ContainsKey(edge.Item2))
                Vertices[edge.Item1].Add(edge.Item2);
        }
    }
}
