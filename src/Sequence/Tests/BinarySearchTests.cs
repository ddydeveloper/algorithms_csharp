using System;
using System.Linq;
using NUnit.Framework;
using Source;

namespace Tests
{
    public class BinarySearchTests
    {
        [Test]
        public void FindEmpty_Test()
        {
            const int itemToFind = 7;
            var array = new int[0];

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdx == -1);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
        }

        [Test]
        public void Find1ItemContains_Test()
        {
            const int itemToFind = 1;
            var array = new[] {1};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == 0);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[itemIdxRecursive] == itemToFind);
        }

        [Test]
        public void Find1ItemNotContains_Test()
        {
            const int itemToFind = 2;
            var array = new[] {1};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == -1);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[0] != itemToFind);
        }

        [Test]
        public void Find2ItemsContains_Test()
        {
            const int itemToFind = 1;
            var array = new[] {1, 2};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == 0);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[itemIdxRecursive] == itemToFind);
        }

        [Test]
        public void Find2ItemsNotContains_Test()
        {
            const int itemToFind = 3;
            var array = new[] {1, 2};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == -1);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[0] != itemToFind);
        }

        [Test]
        public void FindInSortedContains_Test()
        {
            const int itemToFind = 7;
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == 6);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[itemIdxRecursive] == itemToFind);
        }

        [Test]
        public void FindInSortedNotContains_Test()
        {
            const int itemToFind = 14;
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == -1);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array.All(x => x != itemToFind));
        }

        [Test]
        public void FindInNonSortedContains_Test()
        {
            const int itemToFind = 4;

            var array = new[] {4, 1, 2, 8, 3, 5, 7, 6, 10, 9};
            array.ApplyMergeSort();

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == 3);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array[itemIdxRecursive] == itemToFind);
        }

        [Test]
        public void FindInNonSortedNotContains_Test()
        {
            const int itemToFind = 14;

            var array = new[] {4, 1, 2, 8, 3, 5, 7, 6, 10, 9};
            array.ApplyMergeSort();

            var itemIdxRecursive = array.FindBinaryRecursive(itemToFind);
            var itemIdx = array.FindBinary(itemToFind);
            var itemIdxNet = Array.FindIndex(array, i => i == itemToFind);

            Assert.True(itemIdxRecursive == -1);
            Assert.True(itemIdxRecursive == itemIdx && itemIdxRecursive == itemIdxNet);
            Assert.True(array.All(x => x != itemToFind));
        }
    }
}
