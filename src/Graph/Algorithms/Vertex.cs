using System;

namespace Algorithms
{
    /// <summary>
    /// Vertex color
    /// </summary>
    public enum VertexColor
    {
        White = 0,
        Gray = 1,
        Black = 2
    }

    /// <summary>
    /// Graph vertex
    /// </summary>
    public class Vertex: IEquatable<Vertex>
    {
        public Vertex(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public VertexColor Color { get; set; } = VertexColor.White;

        #region Object implementation

        public override string ToString() => $"${Value}: ${Color}";

        public override bool Equals(object obj) => Equals(obj as Vertex);

        public override int GetHashCode() => Value;

        #endregion

        #region IEquatable implementation

        public bool Equals(Vertex other) => other != null && Value == other.Value;

        #endregion
    }
}
