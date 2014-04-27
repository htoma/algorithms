namespace Algorithms.Sources
{
    /// <summary>
    /// rotate an array with only one traversal
    /// </summary>
    public static class RotateWithOneTraversal
    {
        /// <param name="k">rotate left by k elements</param>
        /// rotating righ is equivalent with rotating left by n-k
        public static T[] RotateLeft<T>(T[] values, int k)
        {
            if (values.Length == 0)
            {
                return values;
            }

            if (k > values.Length)
            {
                k = k % values.Length;
            }

            // reverse the entire array
            reverseSubarray(values, 0, values.Length - 1);

            // reverse the left part
            reverseSubarray(values, 0, values.Length - k - 1);

            // reverse the right part
            reverseSubarray(values, values.Length - k, values.Length - 1);

            return values;
        }

        private static void reverseSubarray<T>(T[] values, int startPos, int endPos)
        {
            if (startPos < 0 || endPos >= values.Length)
            {
                return;
            }

            int half = (startPos + endPos) / 2;
            for (int i = startPos; i <= half; i++)
            {
                var pos = endPos - (i - startPos);

                var tmp = values[i];                
                values[i] = values[pos];
                values[pos] = tmp;
            }
        }
    }
}