using System;
using System.Collections.Generic;

namespace Algorithms.Sources
{
    /// <summary>
    /// quickselect algorithm for finding the median of an unsorted array
    /// similar to quicksort, find a pivot and group elements
    /// than compare pivot position with the expected position of the median
    /// </summary>
    public static class MedianUnsortedArray
    {
        public static int Median(List<int> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }

            if (values.Count == 1)
            {
                return values[0];
            }

            int posMedian = values.Count / 2;
            int left = 0;
            int right = values.Count - 1;
            while (true)
            {
                int pos = partition(values, left, right);
                if (pos == posMedian)
                {
                    return values[posMedian];
                }
                if (pos < posMedian)
                {
                    left = pos + 1;
                }
                else
                {
                    right = pos - 1;
                }
            }
        }

        private static int partition(List<int> values, int left, int right)
        {
            if (right < left)
            {
                throw new InvalidOperationException();
            }

            // pick the pivot as the last element
            int exchangePos = left - 1;
            int pivot = values[right];
            for (int i = left; i < right; i++)
            {
                if (values[i] < pivot)
                {
                    exchangePos++;
                    Utils.Utils.Switch(values, exchangePos, i);
                }
            }
            Utils.Utils.Switch(values, ++exchangePos, right);
            return exchangePos;
        }
    }
}