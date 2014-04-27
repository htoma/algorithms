using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class NextBiggerIntegerTests
    {
        [Test]
        public void Test()
        {
            int n = 21765;
            Assert.AreEqual(NextBiggerInteger.GetNext(n), 25167);
            n = 27865;
            Assert.AreEqual(NextBiggerInteger.GetNext(n), 28567);
            n = 25468;
            Assert.AreEqual(NextBiggerInteger.GetNext(n), 25486);
            n = 54321;
            Assert.AreEqual(NextBiggerInteger.GetNext(n), -1);
        }
    }
}