using System;

namespace Algorithms
{
    /// <summary>
    /// Graph vertex
    /// </summary>
    public class Vertex: IEquatable<Vertex>
    {
        public Vertex(int number)
        {
            Number = number;
        }

        public int Number { get; }

        #region Object implementation

        public override string ToString() => Number.ToString();

        public override bool Equals(object obj) => Equals(obj as Vertex);

        public override int GetHashCode() => Number;

        #endregion

        #region IEquatable implementation

        public bool Equals(Vertex other) => other != null && Number == other.Number;

        #endregion
    }
}
