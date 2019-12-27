using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MultiThreading.Primitives;

namespace Benchmark
{
    public static class Program
    {
        public static void Main()
        {
            // Warm up
            Measure(SimpleLockReader, SimpleLockWriter);

            // Measure
            var simpleLockTime = Measure(SimpleLockReader, SimpleLockWriter);
            Console.WriteLine("Simple lock: {0}ms", simpleLockTime);

            // Warm up
            Measure(RwLockReader, RwLockWriter);

            // Measure
            var rwLockTime = Measure(RwLockReader, RwLockWriter);
            Console.WriteLine("ReaderWriterLock: {0}ms", rwLockTime);

            // Warm up
            Measure(RwLockSlimReader, RwLockSlimWriter);

            // Measure
            var rwLockSlimTime = Measure(RwLockSlimReader, RwLockSlimWriter);
            Console.WriteLine("ReaderWriterLockSlim: {0}ms", rwLockSlimTime);

            // Warm up
            Measure(RwLockCustomReader, RwLockCustomWriter);

            // Measure
            var rwLockCustomTime = Measure(RwLockCustomReader, RwLockCustomWriter);
            Console.WriteLine("ReaderWriterLockCustom: {0}ms", rwLockCustomTime);
        }

        #region Measure

        private const int ReadersCount = 10;
        private const int WritersCount = 5;
        private const int Count = 10000;
        private const int ReadPayload = 100;
        private const int WritePayload = 100;
        private static readonly Dictionary<int, string> Map = new Dictionary<int, string>();

        private static int _incrementedNumber = 0;

        private static void ReaderProc()
        {
            Map.TryGetValue(Environment.TickCount % Count, out var val);
            Thread.SpinWait(ReadPayload);
        }

        private static void WriterProc()
        {
            var n = Environment.TickCount % Count;
            Thread.SpinWait(WritePayload);
            _incrementedNumber++;
            Map[n] = n.ToString();
        }

        private static long Measure(Action reader, Action writer)
        {
            var threads = Enumerable.Range(0, ReadersCount).Select(n => new Thread(() =>
                {
                    for (var i = 0; i < Count; i++) reader();
                })).Concat(Enumerable.Range(0, WritersCount).Select(n => new Thread(() =>
                {
                    for (var i = 0; i < Count; i++) writer();
                })))
                .ToArray();

            Map.Clear();

            var sw = Stopwatch.StartNew();

            foreach (var thread in threads) thread.Start();

            foreach (var thread in threads) thread.Join();

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        #endregion

        #region Lock

        private static readonly object SimpleLockLock = new object();

        private static void SimpleLockReader()
        {
            lock (SimpleLockLock) ReaderProc();
        }

        private static void SimpleLockWriter()
        {
            lock (SimpleLockLock) WriterProc();
        }

        #endregion

        #region ReaderWriterLock

        private static readonly ReaderWriterLock Lock = new ReaderWriterLock();

        private static void RwLockReader()
        {
            Lock.AcquireReaderLock(-1);
            try
            {
                ReaderProc();
            }
            finally
            {
                Lock.ReleaseReaderLock();
            }
        }

        private static void RwLockWriter()
        {
            Lock.AcquireWriterLock(-1);
            try
            {
                WriterProc();
            }
            finally
            {
                Lock.ReleaseWriterLock();
            }
        }

        #endregion

        #region ReaderWriterLockSLim

        private static readonly ReaderWriterLockSlim LockSlim = new ReaderWriterLockSlim();

        private static void RwLockSlimReader()
        {
            LockSlim.EnterReadLock();
            try
            {
                ReaderProc();
            }
            finally
            {
                LockSlim.ExitReadLock();
            }
        }

        private static void RwLockSlimWriter()
        {
            LockSlim.EnterWriteLock();
            try
            {
                WriterProc();
            }
            finally
            {
                LockSlim.ExitWriteLock();
            }
        }

        #endregion

        #region RWLockCustom

        private static readonly RwLockCustom CustomLock = new RwLockCustom();

        private static void RwLockCustomReader()
        {
            using (CustomLock.InRead())
            {
                ReaderProc();
            }
        }

        private static void RwLockCustomWriter()
        {
            using (CustomLock.InWrite())
            {
                WriterProc();
            }
        }

        #endregion

        #region Check custom lock

        public static long ReadCustom()
        {
            var threads = Enumerable.Range(0, ReadersCount).Select(n => new Thread(() =>
            {
                for (var i = 0; i < Count; i++) ReaderProc();
            })).ToArray();

            var sw = Stopwatch.StartNew();

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        #endregion
    }
}
