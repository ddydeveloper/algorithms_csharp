using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.WeightedGraph
{
    public static class WeightedGraphExtensions
    {
        public static Dictionary<Vertex, int> Dejkstra(this WeightedGraph graph, Vertex vertex, Dictionary<Vertex, int> paths = null, int weight = 0)
        {
            if (weight < 0)
            {
                throw new ArgumentException("Weight should be greater than 0 or equal");
            }

            if (paths == null)
            {
                paths = new Dictionary<Vertex, int>();
            }

            if (graph is null || !graph.Vertices.Any(x => x.Equals(vertex)) )
            {
                return paths;
            }

            foreach (var edge in graph[vertex])
            {
                var currentVertex = edge.End;
                var currentWeight = edge.Weight + weight;

                paths.Add(currentVertex, currentWeight);

                graph.Dejkstra(currentVertex, paths, currentWeight);
            }

            return paths;
        }
    }
}
