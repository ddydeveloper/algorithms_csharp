using BenchmarkDotNet.Running;

namespace Benchmark
{
    public static class Program
    {
        public static void Main()
        {
            var sortSummary = BenchmarkRunner.Run<PrimitivesBenchmark>();
        }
    }
}
