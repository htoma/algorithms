using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MedianForTwoSortedArrays
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void Test()
        {
            var arraysToTest = new List<Tuple<List<int>, List<int>>>
            {
                new Tuple<List<int>, List<int>>(
                    new List<int>
                    {
                        1,
                        2,
                        9,
                        11
                    },
                    new List<int>
                    {
                        4,
                        5,
                        7,
                        12
                    }),
                new Tuple<List<int>, List<int>>(
                    new List<int>
                    {
                        1,
                        2,
                        9,
                        11,
                        14
                    },
                    new List<int>
                    {
                        4,
                        5,
                        7,
                        12,
                        13
                    })
            };

            foreach (var pair in arraysToTest)
            {
                var merged = pair.Item1.Concat(pair.Item2).ToList();
                merged.Sort();
                int median = Median.GetMedianForArray(merged);
                int computed = Median.GetMedianInLogN(pair.Item1, 0, pair.Item1.Count - 1, pair.Item2, 0,
                    pair.Item2.Count - 1);
                Assert.AreEqual(median, computed);
            }
        }
    }
}
