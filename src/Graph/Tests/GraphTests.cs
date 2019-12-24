using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Algorithms.Graph;
using NUnit.Framework;

namespace Tests
{
    public class GraphTests
    {
        #region Infrastructure

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

        private Graph _graph;

        private Graph _cyclicGraph;

        [SetUp]
        public void Setup()
        {
            var edges = new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(0), _vertices.ElementAt(1)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(1), _vertices.ElementAt(3)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(1), _vertices.ElementAt(4)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(3), _vertices.ElementAt(8)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(3), _vertices.ElementAt(9)),

                new Tuple<Vertex, Vertex>(_vertices.ElementAt(0), _vertices.ElementAt(2)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(2), _vertices.ElementAt(5)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(5), _vertices.ElementAt(6)),
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(5), _vertices.ElementAt(7))
            };

            _graph = new Graph(_vertices, edges);

            _cyclicGraph = new Graph(_vertices, edges.Concat(new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(_vertices.ElementAt(2), _vertices.ElementAt(4))
            }));
        }

        #endregion

        #region DFS based

        [Test]
        public void RunDfs_Test()
        {
            var result = _graph.RunDfs(_vertices.ElementAt(0));
            Assert.True(result.Count > 0);
        }

        [Test]
        public void RunDfsRecursive_Test()
        {
            var result = _graph.RunRecursiveDfs(_vertices.ElementAt(0));
            Assert.True(result.Count > 0);
        }

        [Test]
        public void Dfs_Comparer_Test()
        {
            var dfsResult = _graph.RunDfs(_vertices.ElementAt(0));
            var dfsRecursiveResult = _graph.RunRecursiveDfs(_vertices.ElementAt(0));

            Assert.True(dfsResult.Count == dfsRecursiveResult.Count);

            for (var i = 0; i < dfsResult.Count; i++)
            {
                Assert.True(dfsResult.ElementAt(i).Equals(dfsRecursiveResult.ElementAt(i)));
            }
        }

        [Test]
        public void GetPathsDfs_Test()
        {
            var paths = _graph.GetAllPathsDfs(_vertices.ElementAt(0));
            var vertex = _vertices.Single(x => x.Number == 8);
            var fullPath = vertex.GetFullPath(paths);

            Assert.True(fullPath.Count == 4);
            Assert.True(fullPath.Any(x => x.Number == 8));
            Assert.True(fullPath.Any(x => x.Number == 3));
            Assert.True(fullPath.Any(x => x.Number == 1));
            Assert.True(fullPath.Any(x => x.Number == 0));
        }

        [Test]
        public void GetLcaDfsRoot_Test()
        {
            var root = _vertices.ElementAt(0);
            var fist = _vertices.Single(x => x.Number == 8);
            var second = _vertices.Single(x => x.Number == 7);

            var lca = _graph.GetLcaDfs(root, fist, second);

            Assert.True(lca.Equals(root));
        }

        [Test]
        public void GetLcaDfsShared_Test()
        {
            var root = _vertices.ElementAt(0);
            var fist = _vertices.Single(x => x.Number == 4);
            var second = _vertices.Single(x => x.Number == 9);
            var lca = _graph.GetLcaDfs(root, fist, second);

            Assert.True(lca.Number == 1);
        }

        [Test]
        public void TopologicalSort_Test()
        {
            var vertices = new List<Vertex>
            {
                new Vertex(0),
                new Vertex(1),
                new Vertex(2),
                new Vertex(3),
                new Vertex(4)
            };

            var edges = new List<Tuple<Vertex, Vertex>>
            {
                new Tuple<Vertex, Vertex>(vertices.ElementAt(3), vertices.ElementAt(2)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(2), vertices.ElementAt(4)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(4), vertices.ElementAt(1)),
                new Tuple<Vertex, Vertex>(vertices.ElementAt(4), vertices.ElementAt(0))
            };

            var graph = new Graph(vertices, edges);
            var orderedStack = new Stack<Vertex>();
            graph.TryApplyTopologicalSortDfs(vertices.ElementAt(3), orderedStack);

            Assert.True(orderedStack.Count == vertices.Count);
        }

        [Test]
        public void IsCyclicDfsFalse_Test() => Assert.False(_graph.IsCyclicDfs(_vertices.ElementAt(0)));

        [Test]
        public void IsCyclicDfsTrue_Test() => Assert.True(_cyclicGraph.IsCyclicDfs(_vertices.ElementAt(0)));

        #endregion

        #region BFS based

        [Test]
        public void GetPathBfsExisting_Test()
        {
            var root = _vertices.ElementAt(0);
            var ninth = _vertices.ElementAt(9);
            var rootToNinthPath = _graph.GetVertexBfs(root, ninth.Number);

            Assert.True(rootToNinthPath.Equals(ninth));
        }

        [Test]
        public void GetPathBfsEmpty_Test()
        {
            var root = _vertices.ElementAt(0);
            var rootToNinthPath = _graph.GetVertexBfs(root, 15);

            Assert.IsNull(rootToNinthPath);
        }

        #endregion
    }
}
