using System;
using System.Collections.Generic;

namespace Algorithms.Sources
{
    /// <summary>
    /// cover a length of N with pieces of length 1, 2 and 3
    /// show all possible combinations to do it
    /// </summary>
    public static class CoverLength
    {
        public static void Cover(int n)
        {
            if (n <= 0)
            {
                return;
            }

            var solutions = new List<Tuple<int, int, int>>();
            if (n == 1)
            {
                solutions.Add(new Tuple<int, int, int>(1, 0 ,0));
            }
            else if (n == 2)
            {
                solutions.Add(new Tuple<int, int, int>(2, 0, 0));
                solutions.Add(new Tuple<int, int, int>(0, 1, 0));
            }
            else
            {
                // choose max elements of 3
                int maxThree = n / 3;
                int maxTwo = 0;
                while (maxThree > 0)
                {
                    int leftTwo = n - maxThree * 3;
                    
                    // choose max elements of 2
                    maxTwo = leftTwo / 2;
                    while (maxTwo > 0)
                    {
                        int leftOne = leftTwo - maxTwo * 2;
                        solutions.Add(new Tuple<int, int, int>(leftOne, maxTwo, maxThree));
                        maxTwo--;
                    }

                    // cover by 1s
                    solutions.Add(new Tuple<int, int, int>(leftTwo, 0, maxThree));

                    maxThree--;
                }

                // cover by 2s and 1s
                maxTwo = n / 2;
                while (maxTwo > 0)
                {
                    int leftOne = n - maxTwo * 2;
                    solutions.Add(new Tuple<int, int, int>(leftOne, maxTwo, maxThree));
                    maxTwo--;
                }

                // add the solution consisting only of 1s
                solutions.Add(new Tuple<int, int, int>(n, 0, 0));
            }

            Console.WriteLine("Number to be covered {0}", n);
            foreach (var solution in solutions)
            {
                Console.WriteLine("{0}-{1}-{2}", solution.Item1, solution.Item2, solution.Item3);
            }
        }
    }
}
