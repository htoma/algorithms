using Algorithms.Sources;

using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MatrixInSpiralTests
    {
        [Test]
        public void Test()
        {
            var matrix = new int[,]
            {
                {1, 2, 3, 4, 5},
                {6, 7, 8, 9, 10},
                {11, 12, 13, 14, 15},
                {16, 17, 18, 19, 20}
            };
            MatrixInSpiral.Traverse(matrix, 4, 5);
        }
    }
}