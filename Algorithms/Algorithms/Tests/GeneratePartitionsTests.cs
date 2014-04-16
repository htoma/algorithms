using System.Collections.Generic;

using Algorithms.Sources;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class GeneratePartitionsTests
    {
        [Test]
        public void Test()
        {
            GeneratePartitions.Partition(new List<int> { 1, 2, 3 });
        }
    }
}