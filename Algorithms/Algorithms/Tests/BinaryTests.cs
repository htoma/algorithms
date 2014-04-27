using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinaryTests
    {
        [Test]
        public void TestShowBinary()
        {
            string binary = Binary.ShowBinary(7);
            Assert.AreEqual(7, Binary.FromBinary(binary));

            binary = Binary.ShowBinary(121);
            Assert.AreEqual(121, Binary.FromBinary(binary));
        }

        [Test]
        public void TestCountOnes()
        {
            string binary = "10111011011";
            int m = Binary.GetNextBiggerNumberWithTheSameNumberOfOnes(Binary.FromBinary(binary));
            Console.WriteLine(Binary.ShowBinary(m));
        }
    }
}