using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void Test()
        {
            var values = new[] { 1 };
            Assert.IsTrue(BinarySearch(1, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(2, values, 0, values.Length - 1));

            values = new[] { 1, 2 };
            Assert.IsTrue(BinarySearch(1, values, 0, values.Length - 1));
            Assert.IsTrue(BinarySearch(2, values, 0, values.Length - 1));

            values = new[] { 1, 3, 6, 9, 12 };
            foreach (int value in values)
            {
                Assert.IsTrue(BinarySearch(value, values, 0, values.Length - 1));
            }
            Assert.IsFalse(BinarySearch(0, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(2, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(4, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(5, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(7, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(8, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(10, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(11, values, 0, values.Length - 1));
            Assert.IsFalse(BinarySearch(14, values, 0, values.Length - 1));
        }

        public static bool BinarySearch(int n, int[] values, int left, int right)
        {
            if (left > right)
            {
                return false;
            }
            if (left == right)
            {
                return n == values[left];
            }

            int half = (left + right) / 2;
            if (values[half] == n)
            {
                return true;
            }
            if (values[half] < n)
            {
                return BinarySearch(n, values, half + 1, right);
            }
            return BinarySearch(n, values, left, half);
        }
    }
}