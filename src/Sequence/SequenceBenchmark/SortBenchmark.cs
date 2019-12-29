using System.Linq;
using BenchmarkDotNet.Attributes;
using Source;

namespace Benchmark
{
    public class SortBenchmark
    {
        #region Sorted Array

        [Benchmark]
        public int[] MergeSortSortedArray() => Data.GetSortedArray().ApplyMergeSort();
        
        [Benchmark]
        public int[] QuickSortSortedArray() => Data.GetSortedArray().ApplyQuickSort();
        
        [Benchmark]
        public void OrderBySortedArray()
        {
            var orderedEnumerable = Data.GetSortedArray().OrderBy(i => i);
        }
        
        #endregion

        #region Small Array

        [Benchmark]
        public int[] MergeSortSmallArray() => Data.GetSmallArray().ApplyMergeSort();
                
        [Benchmark]
        public int[] QuickSortSmallArray() => Data.GetSmallArray().ApplyQuickSort();
        
        [Benchmark]
        public void OrderBySmallArray()
        {
            var orderedEnumerable = Data.GetSmallArray().OrderBy(i => i);
        }

        #endregion

        #region Large Array
                
        [Benchmark]
        public int[] MergeSortLargeArray() => Data.GetLargeArray().ApplyMergeSort();

        [Benchmark]
        public int[] QuickSortLargeArray() => Data.GetLargeArray().ApplyQuickSort();

        [Benchmark]
        public void OrderByLargeArray()
        {
            var orderedEnumerable = Data.GetLargeArray().OrderBy(i => i);
        }

        #endregion
        
        #region Extra Large Random Array
                
        [Benchmark]
        public int[] MergeSortExtraLargeArray() => Data.GetExtraLargeArray().ApplyMergeSort();

        [Benchmark]
        public int[] QuickSortExtraLargeArray() => Data.GetExtraLargeArray().ApplyQuickSort();

        [Benchmark]
        public void OrderByExtraLargeArray()
        {
            var orderedEnumerable = Data.GetExtraLargeArray().OrderBy(i => i);
        }

        #endregion
    }
}
