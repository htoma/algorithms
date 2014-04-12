using System;

using Algorithms.Sources;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class CoinProblemTests
    {
        [Test]
        public void Test357()
        {
            Console.WriteLine("Number of solutions {0}", CoinProblem.Pay(20));
        }
    }
}