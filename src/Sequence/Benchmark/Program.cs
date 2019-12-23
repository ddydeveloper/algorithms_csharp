using Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class SortBenchmark
    {
        #region Quik Sort

        [Benchmark]
        public int[] QuickSortSorted() => GetSortedArray().ApplyQuickSort();

        [Benchmark]
        public int[] QuickSortSmall() => GetSmallArray().ApplyQuickSort();

        [Benchmark]
        public int[] QuickSortLarge() => GetLargeArray().ApplyQuickSort();

        #endregion

        #region Merge Sort

        [Benchmark]
        public int[] MergeSortSorted() => GetSortedArray().ApplyMergeSort();

        [Benchmark]
        public int[] MergeSortSmall() => GetSmallArray().ApplyMergeSort();

        [Benchmark]
        public int[] MergeSortLarge() => GetLargeArray().ApplyMergeSort();

        #endregion

        #region Data

        private int[] GetSortedArray() => new[]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        private int[] GetSmallArray() => new[]
        {
            20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 5, 3, 4, 8, 2, 10, 9, 7, 6, 1
        };

        private int[] GetLargeArray() => new[]
        {
            20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 5, 3, 4, 8, 2, 10, 9, 7, 6, 1,
            220, 119, 180, 17, 186, 345, 401, 40, 189, 11, 5, 3, 4, 8, 2, 44, 9, 89, 6, 1,
            14, 119, 3, 33, 186, 345, 901, 40, 189, 11, 5, 67, 61, 87, 0, 12, 9, 12, 6, 78,
            20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 5, 3, 4, 8, 2, 10, 9, 7, 6, 1,
            220, 119, 180, 17, 186, 345, 401, 40, 189, 11, 5, 3, 4, 8, 2, 44, 9, 89, 6, 1,
            14, 119, 3, 33, 186, 345, 901, 40, 189, 11, 5, 67, 61, 87, 0, 12, 9, 12, 6, 78,
            20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 5, 3, 4, 8, 2, 10, 9, 7, 6, 1,
            220, 119, 180, 17, 186, 345, 401, 40, 189, 11, 5, 3, 4, 8, 2, 44, 9, 89, 6, 1,
            14, 119, 3, 33, 186, 345, 901, 40, 189, 11, 5, 67, 61, 87, 0, 12, 9, 12, 6, 78,
            20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 5, 3, 4, 8, 2, 10, 9, 7, 6, 1,
            220, 119, 180, 17, 186, 345, 401, 40, 189, 11, 5, 3, 4, 8, 2, 44, 9, 89, 6, 1,
            14, 119, 3, 33, 186, 345, 901, 40, 189, 11, 5, 67, 61, 87, 0, 12, 9, 12, 6, 78,
        };

        #endregion
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
