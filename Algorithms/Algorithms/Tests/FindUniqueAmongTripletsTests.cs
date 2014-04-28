using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class FindUniqueAmongTripletsTests
    {
        [Test]
        public void Test()
        {
            var values = new[] { 1, 12, 3, 2, 3, 1, 1, 12, 3, 12 };
            Assert.AreEqual(FindUniqueAmongTriplets.Find(values), 2);
        }
    }
}