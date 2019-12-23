using System.Linq;
using Algorithms;
using NUnit.Framework;

namespace Tests
{
    public class MergeSortTests
    {
        [Test]
        public void Sort1_Test()
        {
            var array = new[] {1,4,3,5,2};
            var expected = new[] {1,2,3,4,5};
            var result = array.ApplyMergeSort();

            Assert.True(result.SequenceEqual(expected));
        }

        [Test]
        public void Sort2_Test()
        {
            var array = new[] {6, 4, 2, 5, 500, 7, 3, 8, 9, 100, 25, 15, 10, 20, 1};
            var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 100, 500};
            var result = array.ApplyMergeSort();

            Assert.True(result.SequenceEqual(expected));
        }

        [Test]
        public void Sort3_Test()
        {
            var array = new[] {10, 15, 20, 25, 100, 500, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 100, 500};
            var result = array.ApplyMergeSort();

            Assert.True(result.SequenceEqual(expected));
        }
    }
}
