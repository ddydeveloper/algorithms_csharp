using System;
using System.Threading;

namespace MultiThreading.Primitives
{
    public class RwLockCustom
    {
        private static int _readerCount;
        private static int _writerCount;
        private readonly object _lockObject = new object();

        #region API

        public IDisposable InRead()
        {
            lock (_lockObject)
            {
                while (IsInRead() || IsInWrite())
                {
                    Monitor.Wait(_lockObject);
                }

                return new Locker(_lockObject, true);
            }
        }

        public IDisposable InWrite()
        {
            lock (_lockObject)
            {
                while (IsInRead() || IsInWrite())
                {
                    Monitor.Wait(_lockObject);
                }

                return new Locker(_lockObject, false);
            }
        }

        #endregion

        #region Lock Infrastructure

        private static bool IsInRead() => Thread.VolatileRead(ref _readerCount) > 0;

        private static bool IsInWrite() => Thread.VolatileRead(ref _writerCount) > 0;

        private class Locker: IDisposable
        {
            private readonly object _locked;
            private readonly bool _isReadLock;

            public Locker(object locked, bool isReadLock)
            {
                _locked = locked;
                _isReadLock = isReadLock;
                IncrementLock();
            }

            public void Dispose()
            {
                DecrementLock();

                lock (_locked)
                {
                    Monitor.PulseAll(_locked);
                }
            }

            private void IncrementLock()
            {
                if (_isReadLock)
                    Interlocked.Increment(ref _readerCount);
                else
                    Interlocked.Increment(ref _writerCount);
            }

            private void DecrementLock()
            {
                if (_isReadLock)
                    Interlocked.Decrement(ref _readerCount);
                else
                    Interlocked.Decrement(ref _writerCount);
            }
        }

        #endregion
    }
}
