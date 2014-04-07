using System;
using System.Linq;

using NUnit.Framework;

namespace NextBiggerNumber
{
    [TestFixture]
    public class Tests
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
            var result = NextBiggerNumber.Compute(values);
            foreach (var pair in result)
            {
                Console.WriteLine("{0} < {1}", pair.Item1, pair.Item2);
            }
        }
    }
}