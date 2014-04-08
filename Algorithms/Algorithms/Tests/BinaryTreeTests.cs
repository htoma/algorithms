using System.Collections.Generic;
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
    }
}