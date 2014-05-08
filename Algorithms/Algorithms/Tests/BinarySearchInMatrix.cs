using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinarySearchInMatrix
    {
        [Test]
        public void Test()
        {
            var matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {   
                    var result = Find(matrix, 3, 3, matrix[i, j]);
                    Console.WriteLine("{0}-{1}", result.Item1, result.Item2);
                }
            }
        }

        public static Tuple<int, int> Find(int[,] matrix, int n, int m, int value)
        {
            if (n == 0)
            {
                return null;
            }
            if (matrix.Length == 1)
            {
                return new Tuple<int, int>(0, 0);
            }
            return find(matrix, m, value, 0, n - 1);
        }

        private static Tuple<int, int> find(int[,] matrix, int m, int value, int up, int down)
        {
            if (up > down)
                return null;
            if (up == down)
            {
                return findOnLine(matrix, value, up, m);
            }
            int half = (up + down) / 2;
            if (matrix[half, 0] > value)
                return find(matrix, m, value, up, half - 1);
            if (matrix[half, m - 1] < value)
                return find(matrix, m, value, half + 1, down);
            return findOnLine(matrix, value, half, m);
        }

        private static Tuple<int, int> findOnLine(int[,] matrix, int value, int line, int m)
        {
            int col = binarySearch(extractArray(matrix, line, m), value, 0, m - 1);
            if (col == -1)
            {
                return null;
            }
            return new Tuple<int, int>(line, col);
        }

        private static int binarySearch(int[] array, int value, int left, int right)
        {
            if (left > right)
                return -1;
            if (left == right)
                return array[left] == value ? left : -1;

            int half = array.Length / 2;
            if (array[half] == value)
                return half;
            if (array[half] > value)
                return binarySearch(array, value, left, half - 1);
            return binarySearch(array, value, half + 1, right);
        }

        private static int[] extractArray(int[,] matrix, int line, int m)
        {
            var result = new int[m];
            for (int i = 0; i < m; i++)
            {
                result[i] = matrix[line, i];
            }
            return result;
        }
    }
}