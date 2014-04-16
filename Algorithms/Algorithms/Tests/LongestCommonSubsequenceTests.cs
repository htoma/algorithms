using System;
using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class LongestCommonSubsequenceTests
    {
        [Test]
        public void Test()
        {
            string first = "abcadefg";
            string second = "cadbeghij";

            Console.WriteLine(first);
            Console.WriteLine(second);

            Console.WriteLine(LongestCommonSubsequence.Lcs(first, second));
        }
    }
}