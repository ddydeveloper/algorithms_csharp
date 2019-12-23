using System.Collections.Generic;
using System.Linq;

namespace Algorithms.WeightedGraph
{
    public class WeightedGraph
    {
        public IList<Vertex> Vertices { get; }

        public IList<Edge> Edges { get; }

        public WeightedGraph(IList<Vertex> vertices, IList<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public IEnumerable<Edge> this[Vertex vertex] => Edges.Where(x => x.Start.Equals(vertex));
    }
}
