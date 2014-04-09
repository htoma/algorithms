using System;
using System.Collections.Generic;
using Algorithms.Sources.MergeDisjointedIntervals;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MergeDisjointedIntervalsTests
    {
        [Test]
        public void TestMyNumbers()
        {
            var first = new List<DisjointedInterval>
            {
                new DisjointedInterval(1, 3),
                new DisjointedInterval(7, 12),
                new DisjointedInterval(15, 23)
            };

            var second = new List<DisjointedInterval>
            {
                new DisjointedInterval(5, 9),
                new DisjointedInterval(10, 11),
                new DisjointedInterval(14, 21)
            };

            List<DisjointedInterval> result = MergeDisjointedIntervals.Merge(first, second);
            
            first.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
            second.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
            result.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
        }

        [Test]
        public void TestProblemInput()
        {
            var first = new List<DisjointedInterval>
            {
                new DisjointedInterval(1, 5),
                new DisjointedInterval(10, 15),
                new DisjointedInterval(20, 25)
            };

            var second = new List<DisjointedInterval>
            {
                new DisjointedInterval(12, 27),
            };

            List<DisjointedInterval> result = MergeDisjointedIntervals.Merge(first, second);

            first.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
            second.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
            result.ForEach(x => Console.Write("({0}-{1})", x.Left, x.Right));
            Console.WriteLine();
        }
    }
}