using System;
using System.Threading.Tasks;
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

        private static void RunThreads(Action read, Action write) => Task.WaitAll(Data.GetThreadList(read, write));
    }
}
