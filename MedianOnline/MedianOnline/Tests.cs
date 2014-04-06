using System.Collections.Generic;
using NUnit.Framework;

namespace MedianOnline
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var data = new[] {4, 1, 7, 6, 5, 2};
            var median = new Median();

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
            int half = values.Count / 2;
            return values.Count % 2 == 0 ? (values[half] + values[half - 1]) / 2 : values[half - 1];               
        }
    }
}