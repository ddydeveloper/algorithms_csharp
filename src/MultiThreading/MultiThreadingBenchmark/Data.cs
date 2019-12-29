using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Benchmark
{
    public static class Data
    {
        private const int ReadersCount = 10;
        private const int WritersCount = 5;
        private const int Count = 10000;
        
        private static readonly Dictionary<int, string> Map = new Dictionary<int, string>();
        
        public static IList<Thread> GetThreadList(Action read, Action write)
        {
            var threads = Enumerable.Range(0, ReadersCount).Select(n => new Thread(() =>
                {
                    for (var i = 0; i < Count; i++) read();
                })).Concat(Enumerable.Range(0, WritersCount).Select(n => new Thread(() =>
                {
                    for (var i = 0; i < Count; i++) write();
                })))
                .ToArray();
            
            Map.Clear();

            return threads;
        }
        
        public static void DoReadJob()
        {
            Map.TryGetValue(Environment.TickCount % Count, out _);
            Thread.SpinWait(100);
        }

        public static void DoWriteJob()
        {
            var n = Environment.TickCount % Count;
            Thread.SpinWait(100);
            Map[n] = n.ToString();
        }
    }
}