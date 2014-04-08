using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MedianOnlineTests
    {
        [Test]
        public void Test()
        {
            var data = new[] {4, 1, 7, 6, 5, 2};
            var median = new MedianOnline.MedianOnline();

            var currentList = new List<int>();
            foreach (var number in data)
            {
                currentList.Add(number);
                int newMedian = median.GetMedian(number);
                Assert.AreEqual(newMedian, getMedianForArray(currentList));
            }
        }

        private static int getMedianForArray(List<int> values)
        {
            if (values.Count == 1)
            {
                return values[0];
            }
            values.Sort();
            int half = values.Count / 2;
            return values.Count % 2 == 0 ? (values[half] + values[half - 1]) / 2 : values[half];               
        }
    }
}