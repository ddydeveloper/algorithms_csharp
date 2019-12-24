using System.Collections.Generic;

namespace Algorithms
{
    public static class BinarySearchExtensions
    {
        #region Binary search recursive

        public static int FindBinaryRecursive(this int[] array, int itemToFind)
        {
            if (array.Length == 0) return -1;
            if (array.Length == 1 && array[0] != itemToFind) return -1;

            return BinarySearchRecursive(array, itemToFind, 0, array.Length - 1);
        }

        private static int BinarySearchRecursive(IReadOnlyList<int> array, int itemToFind, int start, int end)
        {
            if (start == end) return array[start] == itemToFind ? start : -1;

            if (start > end) return -1;

            var middle = (end - start) / 2 + start;

            if (array[middle] == itemToFind) return middle;

            return array[middle] > itemToFind
                // ReSharper disable once TailRecursiveCall
                ? BinarySearchRecursive(array, itemToFind, start, middle)
                // ReSharper disable once TailRecursiveCall
                : BinarySearchRecursive(array, itemToFind, middle + 1, end);
        }

        #endregion

        #region Binary search non recursive

        public static int FindBinary(this int[] array, int itemToFind)
        {
            if (array.Length == 0) return -1;
            if (array.Length == 1 && array[0] != itemToFind) return -1;

            return BinarySearchIteration(array, itemToFind);
        }

        private static int BinarySearchIteration(IReadOnlyList<int> array, int itemToFind)
        {
            var start = 0;
            var end = array.Count - 1;

            while (true)
            {
                if (start == end) return array[start] == itemToFind ? start : -1;

                if (start > end) return -1;

                var middle = (end - start) / 2 + start;

                if (array[middle] == itemToFind) return middle;

                if (array[middle] > itemToFind)
                {
                    end = middle;
                    continue;
                }

                start = middle + 1;
            }
        }

        #endregion
    }
}
