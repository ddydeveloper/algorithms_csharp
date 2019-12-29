using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graph
{
    public static class GraphExtensions
    {
        #region DFS non recursive

        public static HashSet<Vertex> RunDfs(this Graph graph, Vertex start)
        {
            var visited = new HashSet<Vertex>();

            if (graph is null || !graph.Vertices.ContainsKey(start))
            {
                return visited;
            }

            var stack = new Stack<Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex)) continue;

                visited.Add(vertex);

                foreach (var child in graph.Vertices[vertex].Where(child => !visited.Contains(child)))
                {
                    stack.Push(child);
                }
            }

            return visited;
        }

        #endregion

        #region DFS recursive

        public static HashSet<Vertex> RunRecursiveDfs(this Graph graph, Vertex start, HashSet<Vertex> visited = null)
        {
            if (visited == null)
            {
                visited = new HashSet<Vertex>();
            }

            if (graph is null || !graph.Vertices.ContainsKey(start) || visited.Contains(start))
            {
                return visited;
            }

            RecursiveDfs(graph, start, visited);

            return visited;
        }

        private static void RecursiveDfs(Graph graph, Vertex vertex, HashSet<Vertex> visited)
        {
            visited.Add(vertex);

            graph.Vertices[vertex]
                .Where(child => !visited.Contains(child))
                .Reverse()
                .ToList()
                .ForEach(child => RecursiveDfs(graph, child, visited));
        }

        #endregion

        #region DFS based get paths

        public static Dictionary<Vertex, Vertex> GetAllPathsDfs(this Graph graph, Vertex start, Vertex from = null, Dictionary<Vertex, Vertex> paths = null)
        {
            if (paths == null)
            {
                paths = new Dictionary<Vertex, Vertex>();
            }

            if (graph is null || !graph.Vertices.ContainsKey(start) || paths.ContainsKey(start))
            {
                return paths;
            }

            PathsDfs(graph, start, null, paths);

            return paths;
        }

        private static void PathsDfs(this Graph graph, Vertex vertex, Vertex from, Dictionary<Vertex, Vertex> paths)
        {
            paths[vertex] = from;

            graph.Vertices[vertex]
                .Where(child => !paths.ContainsKey(child))
                .Reverse()
                .ToList()
                .ForEach(child => PathsDfs(graph, child, vertex, paths));
        }

        #endregion

        #region DFS based LCA

        public static Vertex GetLcaDfs(this Graph graph, Vertex root, Vertex first, Vertex second)
        {
            var paths = graph.GetAllPathsDfs(root);
            var firstPath = first.GetFullPath(paths);
            var secondPath = second.GetFullPath(paths);

            var intersections = firstPath.Intersect(secondPath).ToList();
            return intersections.FirstOrDefault();
        }

        #endregion

        #region DFS based has cycles

        public static bool IsCyclicDfs(this Graph graph, Vertex start)
        {
            if (graph is null || !graph.Vertices.ContainsKey(start))
            {
                return false;
            }

            var visited = new HashSet<Vertex>();

            var stack = new Stack<Vertex>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                {
                    return true;
                };

                visited.Add(vertex);

                foreach (var child in graph.Vertices[vertex])
                {
                    stack.Push(child);
                }
            }

            return false;
        }

        #endregion

        #region DFS based topological sort

        public static bool TryApplyTopologicalSortDfs(this Graph graph, Vertex start, Stack<Vertex> order = null)
        {
            if (order == null)
            {
                order = new Stack<Vertex>();
            }

            if (graph is null || !graph.Vertices.ContainsKey(start) || order.Contains(start))
            {
                return false;
            }

            if (graph.IsCyclicDfs(start))
            {
                return false;
            }

            TopologicalSortDfs(graph, start, order);

            return true;
        }

        private static void TopologicalSortDfs(Graph graph, Vertex vertex, Stack<Vertex> visited)
        {
            graph.Vertices[vertex]
                .Where(child => !visited.Contains(child))
                .ToList()
                .ForEach(child => TopologicalSortDfs(graph, child, visited));

            visited.Push(vertex);
        }

        #endregion

        #region BFS

        public static Vertex GetVertexBfs(this Graph graph, Vertex root, int value)
        {
            if (graph is null || !graph.Vertices.ContainsKey(root))
            {
                return null;
            }

            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (vertex.Number == value) return vertex;

                visited.Add(vertex);

                graph.Vertices[vertex]
                    .Where(child => !visited.Contains(child))
                    .ToList()
                    .ForEach(child => { queue.Enqueue(child); });
            }

            return null;
        }

        #endregion
    }
}
