using System.Collections.Generic;

namespace Algorithms
{
    public static class VertexExtensions
    {
        public static HashSet<Vertex> GetFullPath(this Vertex vertex, Dictionary<Vertex, Vertex> paths)
        {
            var result = new HashSet<Vertex>();

            if (vertex == null || paths.Count == 0 || !paths.ContainsKey(vertex))
            {
                return result;
            }

            result.Add(vertex);

            var parent = paths[vertex];

            while (parent != null)
            {
                result.Add(parent);
                parent = paths[parent];
            }

            return result;
        }
    }
}
