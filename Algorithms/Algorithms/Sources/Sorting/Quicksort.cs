namespace Algorithms.Sources.Sorting
{
    public static class Quicksort
    {
        public static void Quick(int[] values, int left, int right)
        {
            int pos = partition(values, left, right);

            if (left < pos - 1)
            {
                Quick(values, left, pos - 1);
            }

            if (pos + 1 < right)
            {
                Quick(values, pos + 1, right);
            }
        }

        private static int partition(int[] values, int left, int right)
        {
            int pos = left - 1;
            for (int i = left; i < right; i++)
            {
                if (values[i] < values[right])
                {
                    Utils.Utils.Switch(values, i, ++pos);
                }
            }

            Utils.Utils.Switch(values, right, ++pos);

            return pos;
        }
    }
}