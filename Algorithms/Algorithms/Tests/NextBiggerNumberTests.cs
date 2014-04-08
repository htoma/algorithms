using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class NextBiggerNumberTests
    {
        [Test]
        public void Test()
        {
            const int count = 10;
            const int maxValue = 100;
            var rand = new Random();
            var values = Enumerable.Range(0, count).Select(x => rand.Next(maxValue)).ToList();
            foreach (var value in values)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();
            List<Tuple<int, int>> result = NextBiggerNumber.Compute(values);
            foreach (var pair in result)
            {
                Console.WriteLine("{0} < {1}", pair.Item1, pair.Item2);
            }
        }
    }
}