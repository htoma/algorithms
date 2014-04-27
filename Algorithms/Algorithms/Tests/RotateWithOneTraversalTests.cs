using System;
using System.Linq;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class RotateWithOneTraversalTests
    {
        [Test]
        public void Test()
        {
            Console.WriteLine(new string(RotateWithOneTraversal.RotateLeft("ABCDEFGHIJ".ToArray(), 4)));
        }
    }
}