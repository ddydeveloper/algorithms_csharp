using System;
using BenchmarkDotNet.Attributes;
using Source;

namespace Benchmark
{
    public class SearchBenchmark
    {
        #region Sorted Array

        [Benchmark]
        public int FindRecursiveSortedArray() => Data.GetSortedArray().FindBinaryRecursive(10);
        
        [Benchmark]
        public int FindSortedArray() => Data.GetSortedArray().FindBinary(10);
        
        [Benchmark]
        public int FindSortedSystemArray() => Array.FindIndex(Data.GetSortedArray(), x => x == 10);

        #endregion

        #region Small array

        [Benchmark]
        public int FindRecursiveSmallArray() => Data.GetSmallArray().ApplyMergeSort().FindBinaryRecursive(10);
        
        [Benchmark]
        public int FindSmallArray() => Data.GetSmallArray().ApplyMergeSort().FindBinary(10);
        
        [Benchmark]
        public int FindSmallSystemArray() => Array.FindIndex(Data.GetSmallArray().ApplyMergeSort(), x => x == 10);

        #endregion

        #region Large Array
        
        [Benchmark]
        public int FindRecursiveLargeArray() => Data.GetLargeArray().ApplyMergeSort().FindBinaryRecursive(10);
        
        [Benchmark]
        public int FindLargeArray() => Data.GetLargeArray().ApplyMergeSort().FindBinary(10);
        
        [Benchmark]
        public int FindLargeSystemArray() => Array.FindIndex(Data.GetLargeArray().ApplyMergeSort(), x => x == 10);

        #endregion
    }
}
