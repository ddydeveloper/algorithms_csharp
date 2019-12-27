using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Algorithms.WeightedGraph;
using NUnit.Framework;

namespace Tests
{
    public class WeightedGraphTests
    {
        private readonly List<Vertex> _vertices = new List<Vertex>
        {
            new Vertex(0),
            new Vertex(1),
            new Vertex(2),
            new Vertex(3),
            new Vertex(4),
            new Vertex(5),
            new Vertex(6),
            new Vertex(7),
            new Vertex(8),
            new Vertex(9),
        };

        private WeightedGraph _graph;

        [SetUp]
        public void Setup()
        {
            var edges = new List<Edge>
            {
                new Edge(_vertices.ElementAt(0), _vertices.ElementAt(1), 10),
                new Edge(_vertices.ElementAt(1), _vertices.ElementAt(3), 20),
                new Edge(_vertices.ElementAt(1), _vertices.ElementAt(4), 15),
                new Edge(_vertices.ElementAt(3), _vertices.ElementAt(8), 5),
                new Edge(_vertices.ElementAt(3), _vertices.ElementAt(9), 15),

                new Edge(_vertices.ElementAt(0), _vertices.ElementAt(2), 20),
                new Edge(_vertices.ElementAt(2), _vertices.ElementAt(5), 40),
                new Edge(_vertices.ElementAt(5), _vertices.ElementAt(6), 25),
                new Edge(_vertices.ElementAt(5), _vertices.ElementAt(7), 20)
            };

            _graph = new WeightedGraph(_vertices, edges);
        }

        [Test]
        public void Dejkstra_Test()
        {
            var root = _vertices.ElementAt(0);
            var fifth = _vertices.Single(x => x.Number == 5);
            var ninth = _vertices.Single(x => x.Number == 9);

            var result = _graph.CalculateDejkstra(root);

            Assert.True(result.Count == 9);
            Assert.True(result[fifth] == 60);
            Assert.True(result[ninth] == 45);
        }
    }
}
