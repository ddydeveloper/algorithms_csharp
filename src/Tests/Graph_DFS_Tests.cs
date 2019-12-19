using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using NUnit.Framework;

namespace Tests
{
    public class Graph_DFS_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DFS()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0),
                new Vertex(1),
                new Vertex(2),
                new Vertex(3),
                new Vertex(4),
                new Vertex(5),
            };

            var edges = new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(vertices.ElementAt(0), vertices.ElementAt(1)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(0), vertices.ElementAt(2)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(1), vertices.ElementAt(3)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(1), vertices.ElementAt(4)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(2), vertices.ElementAt(5)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(5), vertices.ElementAt(4))
            };

            var graph = new Graph(vertices, edges);
            var result = graph.Dfs(vertices.ElementAt(0));

            Assert.True(result.Count > 0);
        }

        [Test]
        public void DfsSortAndCycles()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0),
                new Vertex(1),
                new Vertex(2),
                new Vertex(3),
                new Vertex(4),
                new Vertex(5),
            };

            var edges = new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(vertices.ElementAt(0), vertices.ElementAt(1)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(0), vertices.ElementAt(2)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(1), vertices.ElementAt(3)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(1), vertices.ElementAt(4)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(2), vertices.ElementAt(5)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(5), vertices.ElementAt(4))
            };

            var graph = new Graph(vertices, edges);
            var (item1, item2) = graph.DfsTopo(vertices.ElementAt(0));

            Assert.True(item1 == 1);
            Assert.True(item2.Count == vertices.Count);
        }
    }
}
