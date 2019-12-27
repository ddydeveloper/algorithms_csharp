using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sortSummary = BenchmarkRunner.Run<SortBenchmark>();
            var searchSummary = BenchmarkRunner.Run<SearchBenchmark>();
        }
    }
}
