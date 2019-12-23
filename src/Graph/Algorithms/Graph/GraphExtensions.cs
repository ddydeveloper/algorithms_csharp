using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graph
{
    public static class GraphExtensions
    {
        #region DFS based algorithms

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

        public static HashSet<Vertex> RunRecursiveDfs(this Graph graph, Vertex vertex, HashSet<Vertex> visited = null)
        {
            if (visited == null)
            {
                visited = new HashSet<Vertex>();
            }

            if (graph is null || !graph.Vertices.ContainsKey(vertex) || visited.Contains(vertex))
            {
                return visited;
            }

            visited.Add(vertex);

            graph.Vertices[vertex]
                .Where(child => !visited.Contains(child))
                .Reverse()
                .ToList()
                .ForEach(child => RunRecursiveDfs(graph, child, visited));

            return visited;
        }

        public static Dictionary<Vertex, Vertex> GetAllPathsDfs(this Graph graph, Vertex vertex, Vertex from = null, Dictionary<Vertex, Vertex> paths = null)
        {
            if (paths == null)
            {
                paths = new Dictionary<Vertex, Vertex>();
            }

            if (graph is null || !graph.Vertices.ContainsKey(vertex) || paths.ContainsKey(vertex))
            {
                return paths;
            }

            paths[vertex] = from;

            graph.Vertices[vertex]
                .Where(child => !paths.ContainsKey(child))
                .Reverse()
                .ToList()
                .ForEach(child => GetAllPathsDfs(graph, child, vertex, paths));

            return paths;
        }

        public static Vertex GetLcaDfs(this Graph graph, Vertex root, Vertex first, Vertex second)
        {
            var paths = graph.GetAllPathsDfs(root);
            var firstPath = first.GetFullPath(paths);
            var secondPath = second.GetFullPath(paths);

            var intersections = firstPath.Intersect(secondPath).ToList();
            return intersections.FirstOrDefault();
        }

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

        #region BFS based algorithms

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

                if (vertex.Value == value) return vertex;

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
