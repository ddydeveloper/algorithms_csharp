using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class PrimitivesBenchmark
    {
        [Benchmark]
        public void Lock() => RunThreads(Primitives.LockRead, Primitives.LockWrite);
        
        [Benchmark]
        public void RwLock() => RunThreads(Primitives.RwLockRead, Primitives.RwLockWrite);
        
        [Benchmark]
        public void RwLockSlim() => RunThreads(Primitives.RwLockSlimRead, Primitives.RwLockSlimWrite);
        
        [Benchmark]
        public void RwLockCustom() => RunThreads(Primitives.RwLockCustomRead, Primitives.RwLockCustomWrite);
        
        private static void RunThreads(Action read, Action write)
        {
            var threads = Data.GetThreadList(read, write);

            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();
        }
    }
}