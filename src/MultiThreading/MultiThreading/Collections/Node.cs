namespace MultiThreading.Collections
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next;

        public T Value { get; }
    }
}
