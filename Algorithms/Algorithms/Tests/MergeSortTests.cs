using System;
using Algorithms.Sources.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void Test()
        {
            var values = new[] {7, 9, 2, 4, 3, 5, 8};
            var result = MergeSort.Sort(values, 0, values.Length - 1);
            foreach (var el in result)
            {
                Console.Write("{0} ", el);
            }
            Console.WriteLine();
        }
    }
}