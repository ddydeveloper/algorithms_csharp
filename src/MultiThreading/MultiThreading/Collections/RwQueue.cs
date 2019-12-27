using MultiThreading.Primitives;

namespace MultiThreading.Collections
{
    /// <summary>
    /// Thread-safe FIFO data structure implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RwQueue<T>
    {
        private readonly RwLockCustom _locker = new RwLockCustom();
        private Node<T> _head = new Node<T>(default);
        private Node<T> _tail;
        private int _count;

        public RwQueue() => _tail = _head;

        public void Enqueue(T value)
        {
            using (_locker.InWrite())
            {
                var node = new Node<T>(value);
                _tail.Next = node;
                _tail = node;
                _count++;
            }
        }

        public T Dequeue()
        {
            using (_locker.InWrite())
            {
                if (_head == _tail) return default;

                var oldHead = _head;
                var result = oldHead.Next.Value;
                _head = oldHead.Next;
                _count--;

                return result;
            }
        }

        public int Count
        {
            get
            {
                using (_locker.InRead())
                {
                    return _count;
                }
            }
        }
    }
}
