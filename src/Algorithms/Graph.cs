using System;
using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// Vertex color
    /// </summary>
    public enum VertexColor
    {
        White = 0,
        Gray = 1,
        Black = 2
    }

    /// <summary>
    /// Graph vertex
    /// </summary>
    public class Vertex: IEquatable<Vertex>
    {
        public Vertex(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public VertexColor Color { get; set; } = VertexColor.White;

        #region Object implementation

        public override string ToString() => $"${Value}: ${Color}";

        public override bool Equals(object obj) => Equals(obj as Vertex);

        public override int GetHashCode() => Value;

        #endregion

        #region IEquatable implementation

        public bool Equals(Vertex other) => other != null && Value == other.Value;

        #endregion
    }

    /// <summary>
    /// Oriented graph
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
