namespace Algorithms.Sources
{
    public static class Partition
    {
        public static bool CanItBePartitioned(int[] values)
        {
            if (values.Length == 0)
            {
                return false;
            }

            int sum = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                sum += values[i];
            }

            if (sum % 2 != 0)
            {
                return false;
            }

            // start looking for elements that can compose the half of the sum
            return findSum(values, values.Length - 1, sum / 2);
        }

        private static bool findSum(int[] values, int maxPos, int sum)
        {
            if (sum < 0)
            {
                return false;
            }

            if (maxPos < 0 && sum > 0)
            {
                // no numbers left to check and sum is not covered
                return false;
            }

            if (sum == 0)
            {
                return true;
            }

            // try to cover the sum ignoring the current maxPos
            // or by using it
            return findSum(values, maxPos - 1, sum) || findSum(values, maxPos - 1, sum - values[maxPos]);
        }
    }
}