using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class GraphExtensions
    {
        public static HashSet<Vertex> Dfs(this Graph graph, Vertex start)
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

        public static Tuple<int, Stack<Vertex>> DfsTopo(this Graph graph, Vertex start)
        {
            if (graph is null || !graph.Vertices.ContainsKey(start))
            {
                return null;
            }

            var stack = new Stack<Vertex>();
            var sortedStack = new Stack<Vertex>();
            var cycleCount = 0;

            start.Color = VertexColor.Gray;
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (vertex.Color == VertexColor.Black) continue;

                foreach (var child in graph.Vertices[vertex])
                {
                    if (child.Color == VertexColor.Gray)
                    {
                        cycleCount++;
                    }
                    else
                    {
                        child.Color = VertexColor.Gray;
                        stack.Push(child);
                    }
                }

                vertex.Color = VertexColor.Black;
                sortedStack.Push(vertex);
            }

            return new Tuple<int, Stack<Vertex>>(cycleCount, sortedStack);
        }
    }
}
