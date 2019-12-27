using System.Threading;
using MultiThreading.Primitives;

namespace MultiThreading.Collections
{
    /// <summary>
    /// Thread-safe lock free LIFO data structure implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LockFreeStack<T>
    {
        private readonly Node<T> _head;

        public LockFreeStack()
        {
            _head = new Node<T>(default);
        }

        public void Push(T value) {
            var nodeToPush = new Node<T>(value);
            do
            {
                nodeToPush.Next = _head.Next;
            } while (!LockFreeApi.CompareAndSwapRef(ref _head.Next, nodeToPush, nodeToPush.Next));
        }

        public T Pop()
        {
            Node<T> nodeToPop;
            do
            {
                nodeToPop = _head.Next;
                if (nodeToPop == null) return default;
            } while (!LockFreeApi.CompareAndSwapRef(ref _head.Next, nodeToPop.Next, nodeToPop));

            return nodeToPop.Value;
        }
    }
}
