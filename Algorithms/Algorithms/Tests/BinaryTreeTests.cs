﻿using System;
using System.Collections.Generic;
using System.Linq;

using Algorithms.Sources.Trees;

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

        [Test]
        public void TestIfTreeIsBinarySearchTree()
        {
            int min, max;

            var tree = new BinaryTree<int>(new List<int> { 2, 1, 3 });            
            Assert.IsFalse(BinaryTree<int>.IsTreeBinarySearchTree(tree, out min, out max));

            tree = new BinaryTree<int>(new List<int> { 1, 2, 3 });
            Assert.IsTrue(BinaryTree<int>.IsTreeBinarySearchTree(tree, out min, out max));

            var head = new BinaryTree<int>(7);
            var p = new BinaryTree<int>(4);
            head.Left = p;
            p.Left = new BinaryTree<int>(2);
            p.Right = new BinaryTree<int>(5);
            var q = new BinaryTree<int>(9);
            head.Right = q;
            q.Left = new BinaryTree<int>(8);
            p = new BinaryTree<int>(10);
            q.Right = p;
            
            Assert.IsTrue(BinaryTree<int>.IsTreeBinarySearchTree(head, out min, out max));

            p.Left = new BinaryTree<int>(6);

            Assert.IsFalse(BinaryTree<int>.IsTreeBinarySearchTree(head, out min, out max));
        }

        [Test]
        public void TestFindPred()
        {
            var head = buildTreeForDeletion();

            Assert.IsNull(BinaryTree<int>.FindPred(10, new Utils.Comparer<int>(), head).Item1);
            var pred = BinaryTree<int>.FindPred(5, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 10);
            pred = BinaryTree<int>.FindPred(3, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 5);
            pred = BinaryTree<int>.FindPred(2, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 3);
            pred = BinaryTree<int>.FindPred(4, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 3);
            pred = BinaryTree<int>.FindPred(12, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 10);
            pred = BinaryTree<int>.FindPred(11, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 12);
            pred = BinaryTree<int>.FindPred(11, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 12);
            pred = BinaryTree<int>.FindPred(13, new Utils.Comparer<int>(), head);
            Assert.AreEqual(pred.Item1.Data, 12);
        }

        [Test]
        public void TestNodeDeletion()
        {
            var head = buildTreeForDeletion();

            BinaryTree<int>.DeleteTree(10, new Utils.Comparer<int>(), ref head);
            Assert.IsNull(head);

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(5, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(3, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(2, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(4, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(8, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(6, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(9, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(12, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(11, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();

            head = buildTreeForDeletion();
            BinaryTree<int>.DeleteTree(13, new Utils.Comparer<int>(), ref head);
            BinaryTree<int>.Inorder(head).ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();
        }

        [Test]
        public void TestInorderWithStack()
        {
            var tree = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
            List<int> list = BinaryTree<int>.InorderWithStack(tree);
            Assert.That(list, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
        }

        [Test]
        public void TestFindCommonAncestorNotBst()
        {
            var tree = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            Assert.AreEqual(BinaryTree<int>.FindAncestor(tree, 1, 3).Data, 2);
            Assert.AreEqual(BinaryTree<int>.FindAncestor(tree, 1, 5).Data, 4);
            Assert.AreEqual(BinaryTree<int>.FindAncestor(tree, 2, 10).Data, 8);
            Assert.AreEqual(BinaryTree<int>.FindAncestor(tree, 4, 7).Data, 4);
            Assert.AreEqual(BinaryTree<int>.FindAncestor(tree, 6, 15).Data, 8);
        }

        [Test]
        public void TestSumPaths()
        {
            var tree = new BinaryTree<int>(new List<int> {2, 6, 4, 3, 9, 2, 5, 1, 1, 5, 2, 3, 1, 9, 10});
            BinaryTree<int>.FindSumPaths(tree, 10);
        }

        [Test]
        public void TestReconstruction()
        {
            BinaryTree<int> root = new BinaryTree<int>(Enumerable.Range(1, 100).ToList());
            List<int> inorder = BinaryTree<int>.Inorder(root);
            List<int> preorder = BinaryTree<int>.Preorder(root);
            int[] preorderArray = preorder.ToArray();
            BinaryTree<int> newRoot = BinaryTree<int>.ReconstructTree(inorder.ToArray(), ref preorderArray);
            Assert.That(BinaryTree<int>.Inorder(newRoot), Is.EquivalentTo(inorder));
            Assert.That(BinaryTree<int>.Preorder(newRoot), Is.EquivalentTo(preorder));
        }

        [Test]
        public void TestKeysInRange()
        {
            var head = new BinaryTree<int>(new List<int> { 4, 8, 12, 20, 21, 22, 24 });
            Assert.That(BinaryTree<int>.KeysInRange(head, 8, 22), Is.EquivalentTo(new[] { 8, 12, 20, 21, 22 }));
        }

        [Test]
        public void TestFindCeil()
        {
            var head = new BinaryTree<int>(new List<int> { 4, 8, 12, 20, 21, 22, 24 });
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 4).Data, 8);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 8).Data, 12);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 20).Data, 21);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 21).Data, 22);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 22).Data, 24);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 1).Data, 4);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 7).Data, 8);
            Assert.AreEqual(BinaryTree<int>.FindCeilNode(head, 17).Data, 20);
        }

        [Test]
        public void TestAddAllGreaterElements()
        {
            var head = new BinaryTree<int>(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            BinaryTree<int>.AddAllGreaterValuesToNode(head);
        }

        private BinaryTree<int> buildTreeForDeletion()
        {
            var head = new BinaryTree<int>(10);
            var p = new BinaryTree<int>(5);
            head.Left = p;
            var q = new BinaryTree<int>(3);
            p.Left = q;
            q.Left = new BinaryTree<int>(2);
            q.Right = new BinaryTree<int>(4);
            q = new BinaryTree<int>(8);
            q.Left = new BinaryTree<int>(6);
            q.Right = new BinaryTree<int>(9);
            p.Right = q;           
            p = new BinaryTree<int>(12);
            head.Right = p;
            p.Left = new BinaryTree<int>(11);
            p.Right = new BinaryTree<int>(13);
            return head;
        }  
    }
}