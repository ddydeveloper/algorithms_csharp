using System.Collections.Generic;

namespace Source
{
    public static class SortExtensions
    {
        #region Quick Sort

        public static int[] ApplyQuickSort(this int[] array) => QuickSort(array, 0, array.Length - 1);

        private static int[] QuickSort(int[] array, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return array;
            }

            var pivotIdx = SortGetPivot(array, startIdx, endIdx);
            QuickSort(array, startIdx, pivotIdx - 1);
            QuickSort(array, pivotIdx + 1, endIdx);

            return array;
        }

        private static int SortGetPivot(IList<int> array, int startIdx, int endIdx)
        {
            var pivot = startIdx - 1;

            for (var i = startIdx; i < endIdx; i++)
            {
                if (array[i] >= array[endIdx]) continue;

                pivot++;
                SwapItems(array, pivot, i);
            }

            pivot++;
            SwapItems(array, pivot, endIdx);

            return pivot;
        }

        private static void SwapItems(IList<int> array, int firstIdx, int secondIdx)
        {
            var swappedItem = array[firstIdx];
            array[firstIdx] = array[secondIdx];
            array[secondIdx] = swappedItem;
        }

        #endregion

        #region Merge Sort

        public static int[] ApplyMergeSort(this int[] array) => MergeSort(array, 0, array.Length - 1);

        private static int[] MergeSort(int[] array, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx) return array;

            var middleIdx = (startIdx + endIdx) / 2;

            MergeSort(array, startIdx, middleIdx);
            MergeSort(array, middleIdx + 1, endIdx);
            MergeSubArrays(array, startIdx, middleIdx, endIdx);

            return array;
        }

        private static void MergeSubArrays(int[] array, int startIdx, int middleIdx, int endIdx)
        {
            var leftCaret = startIdx;
            var rightCaret = middleIdx + 1;
            var tempCaret = 0;
            var tempArray = new int[endIdx - startIdx + 1];

            // merge sub arrays with sorting
            while ((leftCaret <= middleIdx) && (rightCaret <= endIdx))
            {
                if (array[leftCaret] < array[rightCaret])
                {
                    tempArray[tempCaret] = array[leftCaret];
                    leftCaret++;
                }
                else
                {
                    tempArray[tempCaret] = array[rightCaret];
                    rightCaret++;
                }

                tempCaret++;
            }

            // fill left array item which were not processed during iteration
            for (var i = leftCaret; i <= middleIdx; i++)
            {
                tempArray[tempCaret] = array[i];
                tempCaret++;
            }

            // fill right array item which were not processed during iteration
            for (var i = rightCaret; i <= endIdx; i++)
            {
                tempArray[tempCaret] = array[i];
                tempCaret++;
            }

            // actualize existing array
            for (var i = 0; i < tempArray.Length; i++)
            {
                array[startIdx + i] = tempArray[i];
            }
        }

        #endregion
    }
}
