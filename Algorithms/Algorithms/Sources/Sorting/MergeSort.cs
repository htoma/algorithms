namespace Algorithms.Sources.Sorting
{
    public static class MergeSort
    {
        public static int[] Sort(int[] values, int start, int end)
        {
            if (start == end)
            {
                return new[] {values[start]};
            }

            int half = start + (end - start + 1) / 2;
            int[] first = Sort(values, start, half - 1);
            int[] second = Sort(values, half, end);

            return merge(first, second);
        }

        private static int[] merge(int[] first, int[] second)
        {
            int[] result = new int[first.Length + second.Length];
            
            int i = 0;
            int j = 0;
            
            while (i < first.Length && j < second.Length)
            {
                if (first[i] < second[j])
                {
                    result[i + j] = first[i++];
                }
                else
                {
                    result[i + j] = second[j++];
                }
            }

            while (i < first.Length)
            {
                result[i + j] = first[i++];
            }

            while (j < second.Length)
            {
                result[i + j] = second[j++];
            }

            return result;
        }
    }
}