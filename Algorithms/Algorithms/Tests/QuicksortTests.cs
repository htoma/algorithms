using System;
using Algorithms.Sources.Sorting;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class QuicksortTests
    {
        [Test]
        public void Test()
        {
            var values = new[] { 7, 9, 2, 4, 3, 5, 8 };
            Quicksort.Quick(values, 0, values.Length - 1);
            foreach (int el in values)
            {
                Console.Write("{0} ", el);
            }
            Console.WriteLine();
        }
    }
}