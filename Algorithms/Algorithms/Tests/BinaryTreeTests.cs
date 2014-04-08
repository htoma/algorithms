﻿using System.Collections.Generic;
using System.Linq;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void TestInsertionAndTraversals()
        {
            var tree = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            List<int> list = BinaryTree<int>.Inorder(tree);
            Assert.That(list, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));

            list = BinaryTree<int>.Preorder(tree);
            Assert.That(list, Is.EquivalentTo(new[] { 4, 2, 1, 3, 6, 5, 7, 8 }));

            list = BinaryTree<int>.Postorder(tree);
            Assert.That(list, Is.EquivalentTo(new[] { 1, 3, 2, 5, 8, 7, 6, 4 }));
        }

        [Test]
        public void TestFind()
        {
            var head = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            Enumerable.Range(1, 8).ToList().ForEach(x =>
            {
                BinaryTree<int> node = BinaryTree<int>.FindNode(x, head, new Utils.Comparer<int>());
                Assert.IsNotNull(node);
                Assert.AreEqual(node.Data, x);
            });
        }

        [Test]
        public void TestHeightAndWidth()
        {
            /*
             *                    1
             *              /           \
             *          2                  4
             *            \             /     \
             *              3         5          9
             *                      /             \
             *                    6                 10
             *                      \              /
                                     7            11
             *                         \         /
             *                          8     12
             */
            var head = new BinaryTree<int>(1);
            var p = new BinaryTree<int>(2);
            head.Left = p;
            var q = new BinaryTree<int>(3);
            p.Right = q;
            var s = new BinaryTree<int>(4);
            head.Right = s;
            q = new BinaryTree<int>(5);
            s.Left = q;
            p = new BinaryTree<int>(6);
            q.Left = p;
            q = new BinaryTree<int>(7);
            p.Right = q;
            p = new BinaryTree<int>(8);
            q.Right = p;
            p = new BinaryTree<int>(9);
            s.Right = p;
            q = new BinaryTree<int>(10);
            p.Right = q;
            p = new BinaryTree<int>(11);
            q.Left = p;
            q = new BinaryTree<int>(12);
            p.Left = q;

            Assert.AreEqual(BinaryTree<int>.GetTreeHeight(head), 6);

            Dictionary<int, int> widths = BinaryTree<int>.GetWidths(head);
            Assert.AreEqual(widths[1], 1);
            Assert.AreEqual(widths[2], 2);
            Assert.AreEqual(widths[3], 3);
            Assert.AreEqual(widths[4], 2);
            Assert.AreEqual(widths[5], 2);
            Assert.AreEqual(widths[6], 2);
        }
    }
}