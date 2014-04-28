using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class AdditionWithBitOperationsTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(AdditionWithBitOperations.Add(6, 7), 13);
            Assert.AreEqual(AdditionWithBitOperations.Add(5, 7), 12);
            Assert.AreEqual(AdditionWithBitOperations.Add(7, 7), 14);
        }
    }
}