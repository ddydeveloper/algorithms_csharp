using System;
using Algorithms;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class SearchBenchmark
    {
        #region Recursive

        [Benchmark]
        public int FindRecursiveSorted() => Data.GetSortedArray().FindBinaryRecursive(10);

        [Benchmark]
        public int FindRecursiveSmall() => Data.GetSmallArray().ApplyMergeSort().FindBinaryRecursive(10);

        [Benchmark]
        public int FindRecursiveLarge() => Data.GetLargeArray().ApplyMergeSort().FindBinaryRecursive(10);

        #endregion

        #region Non Recursive

        [Benchmark]
        public int FindSorted() => Data.GetSortedArray().FindBinary(10);

        [Benchmark]
        public int FindSmall() => Data.GetSmallArray().ApplyMergeSort().FindBinary(10);

        [Benchmark]
        public int FindLarge() => Data.GetLargeArray().ApplyMergeSort().FindBinary(10);

        #endregion

        #region .Net

        [Benchmark]
        public int DotNet() => Array.FindIndex(Data.GetSortedArray(), x => x == 10);

        [Benchmark]
        public int DotNetSmall() => Array.FindIndex(Data.GetSmallArray().ApplyMergeSort(), x => x == 10);

        [Benchmark]
        public int DotNetLarge() => Array.FindIndex(Data.GetLargeArray().ApplyMergeSort(), x => x == 10);

        #endregion
    }
}
