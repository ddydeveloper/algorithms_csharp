using MultiThreading.Collections;
using NUnit.Framework;

namespace Tests
{
    public class LockFreeQueueTests
    {
        [Test]
        public void QueueNullableInt_Test()
        {
            var queue = new LockFreeQueue<int?>();

            Assert.True(queue.Dequeue() == null);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.True(queue.Dequeue() == 1);
            Assert.True(queue.Dequeue() == 2);
            Assert.True(queue.Dequeue() == 3);

            Assert.True(queue.Dequeue() == null);
        }
    }
}
