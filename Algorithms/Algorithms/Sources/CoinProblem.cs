namespace Algorithms.Sources
{
    public static class CoinProblem
    {
        /// <summary>
        /// use 3, 5, 7 as units
        /// </summary>
        public static int Pay(int sum)
        {
            if (sum < 3)
            {
                return 0;
            }

            //return pay(sum, new[] { 3, 5, 7 }, 3);
            return payDp(sum, new[] { 3, 5, 7 }, 3);
        }

        private static int pay(int sum, int[] coins, int m)
        {
            if (sum < 0)
            {
                return 0;
            }
            if (sum == 0)
            {
                return 1;
            }
            if (m <= 0 && sum > 0)
            {
                return 0;
            }

            return pay(sum, coins, m - 1) + pay(sum - coins[m - 1], coins, m);            
        }

        private static int payDp(int sum, int[] coins, int m)
        {
            // build solution bottom up and store all values in a matrix
            // matrix is sum+1 x m
            // each cell result[i, j] holds the number of solutions to reach sum i
            var result = new int[sum + 1, m];
            for (int j = 0; j < m; j++)
            {
                result[0, j] = 1;
            }
            for (int i = 1; i <= sum; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var sumWithoutCoinJ = j >= 1 ? result[i, j - 1] : 0;
                    var sumWithCoinJ = i >= coins[j] ? result[i - coins[j], j] : 0;
                    result[i, j] = sumWithCoinJ + sumWithoutCoinJ;
                }
            }
            return result[sum, m - 1];
        }
    }
}