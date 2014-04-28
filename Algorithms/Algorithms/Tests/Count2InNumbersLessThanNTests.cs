using Algorithms.Sources;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class Count2InNumbersLessThanNTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(countHelper(100, 2), Count2InNumbersLessThanN.Count(100));
            Assert.AreEqual(countHelper(2223, 2), Count2InNumbersLessThanN.Count(2223));
            Assert.AreEqual(countHelper(30005, 2), Count2InNumbersLessThanN.Count(30005));
        }

        private static int countHelper(int n, int digit)
        {
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                count += countSpecificDigitsInNumber(i, digit);
            }
            return count;
        }

        private static int countSpecificDigitsInNumber(int n, int digit)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 10 == digit)
                {
                    count++;
                }
                n /= 10;
            }
            return count;
        }
    }
}