using System;
using MultiThreading.Collections;
using NUnit.Framework;

namespace Tests
{
    public class LockFreeStackTests
    {
        [Test]
        public void StackNullableInt_Test()
        {
            var stack = new LockFreeStack<int?>();

            Assert.True(stack.Pop() == null);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.True(stack.Pop() == 3);
            Assert.True(stack.Pop() == 2);
            Assert.True(stack.Pop() == 1);

            Assert.True(stack.Pop() == null);
        }

        [Test]
        public void StackDatetime_Test()
        {
            var stack = new LockFreeStack<DateTime>();
            var defaultValue = default(DateTime);

            Assert.True(stack.Pop() == defaultValue);

            stack.Push(new DateTime(2000, 1, 1));
            stack.Push(new DateTime(2001, 1, 1));
            stack.Push(new DateTime(2002, 1, 1));

            Assert.True(stack.Pop() == new DateTime(2002, 1, 1));
            Assert.True(stack.Pop() == new DateTime(2001, 1, 1));
            Assert.True(stack.Pop() == new DateTime(2000, 1, 1));

            Assert.True(stack.Pop() == defaultValue);
        }
    }
}
