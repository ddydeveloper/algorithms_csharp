using System.Linq;
using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class SortBenchmark
    {
        #region Quik Sort

        [Benchmark]
        public int[] QuickSortSorted() => Data.GetSortedArray().ApplyQuickSort();

        [Benchmark]
        public int[] QuickSortSmall() => Data.GetSmallArray().ApplyQuickSort();

        [Benchmark]
        public int[] QuickSortLarge() => Data.GetLargeArray().ApplyQuickSort();

        #endregion

        #region Merge Sort

        [Benchmark]
        public int[] MergeSortSorted() => Data.GetSortedArray().ApplyMergeSort();

        [Benchmark]
        public int[] MergeSortSmall() => Data.GetSmallArray().ApplyMergeSort();

        [Benchmark]
        public int[] MergeSortLarge() => Data.GetLargeArray().ApplyMergeSort();

        #endregion

        #region .Net

        [Benchmark]
        public void DotNet()
        {
            var orderedEnumerable = Data.GetSortedArray().OrderBy(i => i);
        }

        [Benchmark]
        public void DotNetSmall()
        {
            var orderedEnumerable = Data.GetSmallArray().OrderBy(i => i);
        }

        [Benchmark]
        public void DotNetLarge()
        {
            var orderedEnumerable = Data.GetLargeArray().OrderBy(i => i);
        }

        #endregion
    }
}
