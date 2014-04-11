using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources.Trees;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinaryTreeNextBiggerNumberTests
    {
        [Test]
        public void Test()
        {
            int nextBigger;
            BinaryTree<int> node;

            var head = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            Enumerable.Range(1, 7).ToList().ForEach(x =>
            {
                node = BinaryTree<int>.FindNode(x, head, new Utils.Comparer<int>());
                nextBigger = BinaryTreeNextBiggerNumber.FindNextBiggerValueForNode(node, head);
                Assert.AreEqual(nextBigger, x + 1);
            });
            node = BinaryTree<int>.FindNode(8, head, new Utils.Comparer<int>());
            nextBigger = BinaryTreeNextBiggerNumber.FindNextBiggerValueForNode(node, head);
            Assert.AreEqual(nextBigger, -1);
        }
    }
}