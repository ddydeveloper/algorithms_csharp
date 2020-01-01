using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmark
{
    public static class Data
    {
        private const int ReadersCount = 10;
        private const int WritersCount = 5;
        private const int Count = 10000;

        private static readonly Dictionary<int, string> Map = new Dictionary<int, string>();

        public static Task[] GetThreadList(Action read, Action write)
        {
            Map.Clear();

            var readTasks = Enumerable.Range(0, ReadersCount).Select(r => Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < Count; i++) read();
            }));

            var writeTasks = Enumerable.Range(0, WritersCount).Select(r => Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < Count; i++) write();
            }));

            return readTasks.Concat(writeTasks).ToArray();
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
