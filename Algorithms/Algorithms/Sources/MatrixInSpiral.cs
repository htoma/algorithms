using System;

namespace Algorithms.Sources
{
    public static class MatrixInSpiral
    {
        public static void Traverse(int[,] matrix, int n, int m)
        {
            int iStart = 0;
            int iEnd = n - 1;
            int jStart = 0;
            int jEnd = m - 1;

            int direction = 0;

            while (iStart <= iEnd && jStart <= jEnd)
            {
                if (direction == 0)
                {
                    for (int j = jStart; j <= jEnd; j++)
                    {
                        Console.Write("{0} ", matrix[iStart, j]);
                    }
                    iStart++;
                }
                else if (direction == 1)
                {
                    for (int i = iStart; i <= iEnd; i++)
                    {
                        Console.Write("{0} ", matrix[i, jEnd]);
                    }
                    jEnd--;
                }
                else if (direction == 2)
                {
                    for (int j = jEnd; j >= jStart; j--)
                    {
                        Console.Write("{0} ", matrix[iEnd, j]);
                    }
                    iEnd--;
                }
                else
                {
                    for (int i = iEnd; i >= iStart; i--)
                    {
                        Console.Write("{0} ", matrix[i, jStart]);
                    }
                    jStart++;
                }
                direction = ++direction % 4;
            }
        }
    }
}