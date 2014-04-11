using Algorithms.Sources.Trees;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinaryTreeDiameterTests
    {
        [Test]
        public void Test()
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

            Assert.AreEqual(BinaryTreeDiameter.GetDiameter(head), 9);
        }
    }
}