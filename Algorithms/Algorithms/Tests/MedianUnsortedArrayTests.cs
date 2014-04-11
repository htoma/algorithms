using System.Collections.Generic;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MedianUnsortedArrayTests
    {
        [Test]
        public void Test()
        {
            var values = new List<int> { 1, 4, 5, 3, 2 };
            var medianUnsorted = MedianUnsortedArray.Median(values);
            values.Sort();
            var medianSorted = Utils.Utils.MedianForSorted(values);
            Assert.AreEqual(medianSorted, medianUnsorted);

            values = new List<int> { 7, 9, 2, 4, 3, 8, 5, 10, 1 };
            medianUnsorted = MedianUnsortedArray.Median(values);
            values.Sort();
            medianSorted = Utils.Utils.MedianForSorted(values);
            Assert.AreEqual(medianSorted, medianUnsorted);
        }
    }
}