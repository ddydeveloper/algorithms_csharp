using MultiThreading.Primitives;

namespace MultiThreading.Collections
{
    /// <summary>
    /// Thread-safe lock free FIFO data structure implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LockFreeQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public LockFreeQueue()
        {
            _head = new Node<T>(default);
            _tail = _head;
        }

        public void Enqueue(T value)
        {
            Node<T> currentTail = null;
            Node<T> currentNext = null;

            var node = new Node<T>(value);

            var tailNextUpdated = false;
            while (!tailNextUpdated) {
                currentTail = _tail;
                currentNext = currentTail.Next;

                if (_tail != currentTail) continue;

                if (currentNext == null) {
                    tailNextUpdated = LockFreeApi.CompareAndSwapRef(ref _tail.Next, node, null);
                }
                else
                {
                    LockFreeApi.CompareAndSwapRef(ref _tail, currentNext, currentTail);
                }
            }

            LockFreeApi.CompareAndSwapRef(ref _tail, node, currentTail);
        }

        public T Dequeue()
        {
            var result = default(T);

            var haveAdvancedHead = false;
            while (!haveAdvancedHead) {
                var oldHead = _head;
                var oldTail = _tail;
                var oldHeadNext = oldHead.Next;

                if (oldHead != _head) continue;

                if (oldHead == oldTail) {
                    if (oldHeadNext == null) return default;

                    LockFreeApi.CompareAndSwapRef(ref _tail, oldHeadNext,oldTail);
                }
                else
                {
                    result = oldHeadNext.Value;
                    haveAdvancedHead = LockFreeApi.CompareAndSwapRef(ref _head, oldHeadNext, oldHead);
                }
            }

            return result;
        }
    }
}
