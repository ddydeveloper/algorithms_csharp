using System.Threading;
using Source.Primitives;

namespace Benchmark
{
    public static class Primitives
    {
        #region Lock

        private static readonly object LockObject = new object();

        public static void LockRead()
        {
            lock (LockObject) Data.DoReadJob();
        }

        public static void LockWrite()
        {
            lock (LockObject) Data.DoWriteJob();
        }

        #endregion

        #region ReaderWriterLock

        private static readonly ReaderWriterLock Lock = new ReaderWriterLock();

        public static void RwLockRead()
        {
            Lock.AcquireReaderLock(-1);
            try
            {
                Data.DoReadJob();
            }
            finally
            {
                Lock.ReleaseReaderLock();
            }
        }

        public static void RwLockWrite()
        {
            Lock.AcquireWriterLock(-1);
            try
            {
                Data.DoWriteJob();
            }
            finally
            {
                Lock.ReleaseWriterLock();
            }
        }

        #endregion

        #region ReaderWriterLockSLim

        private static readonly ReaderWriterLockSlim LockSlim = new ReaderWriterLockSlim();

        public static void RwLockSlimRead()
        {
            LockSlim.EnterReadLock();
            try
            {
                Data.DoReadJob();
            }
            finally
            {
                LockSlim.ExitReadLock();
            }
        }

        public static void RwLockSlimWrite()
        {
            LockSlim.EnterWriteLock();
            try
            {
                Data.DoWriteJob();
            }
            finally
            {
                LockSlim.ExitWriteLock();
            }
        }

        #endregion

        #region RWLockCustom

        private static readonly RwLockCustom RwLockCustom = new RwLockCustom();

        public static void RwLockCustomRead()
        {
            using (RwLockCustom.InRead())
            {
                Data.DoReadJob();
            }
        }

        public static void RwLockCustomWrite()
        {
            using (RwLockCustom.InWrite())
            {
                Data.DoWriteJob();
            }
        }

        #endregion
    }
}