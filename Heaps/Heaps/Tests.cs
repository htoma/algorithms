using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Heaps
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestInsertionAndSortAscending()
        {
            var heap = new Heap();
            new []{4, 1, 7, 6, 5, 8}.ToList().ForEach(heap.Insert);
            List<int> result = heap.GetSorted();
            result.ForEach(x => Console.Write("{0} ", x));
        }

        [Test]
        public void TestInsertionAndSortDescending()
        {
            var heap = new Heap(false);
            new[] { 4, 1, 7, 6, 5, 8 }.ToList().ForEach(heap.Insert);
            List<int> result = heap.GetSorted();
            result.ForEach(x => Console.Write("{0} ", x));
        }

        [Test]
        public void TestHeapify()
        {
            var heap = new Heap(new List<int> {4, 1, 7, 6, 5, 8});
            List<int> result = heap.GetSorted();
            result.ForEach(x => Console.Write("{0} ", x));
        }
    }
}