namespace Algorithms
{
    public class Edge
    {
        public Edge(Vertex start, Vertex end, int weight)
        {
            Weight = weight;
            Start = start;
            End = end;
        }

        public int Weight { get; }

        public Vertex Start { get; }

        public Vertex End { get; }
    }
}
