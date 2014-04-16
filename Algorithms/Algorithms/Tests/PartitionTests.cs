using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PartitionTests
    {
        [Test]
        public void Test()
        {
            var values = new[] { 1, 11, 5, 5 };
            Assert.IsTrue(Partition.CanItBePartitioned(values));

            values = new[] { 1, 7, 2, 3, 4, 5 };
            Assert.IsTrue(Partition.CanItBePartitioned(values));

            values = new[] { 1, 7, 2, 3, 6, 5 };
            Assert.IsTrue(Partition.CanItBePartitioned(values));

            values = new[] { 7, 2, 6, 9 };
            Assert.IsFalse(Partition.CanItBePartitioned(values));
        }
    }
}