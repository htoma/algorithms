using System;
using System.Collections.Generic;

namespace MedianForTwoSortedArrays
{
    public static class Median
    {
        public static int GetMedianForArray(List<int> values, bool entireArray = true, int leftLimit = - 1, int rightLimit = -1)
        {
            if (entireArray)
            {
                leftLimit = 0;
                rightLimit = values.Count - 1;
            }
            int half = (rightLimit + 1 - leftLimit)/2 + leftLimit;
            return (rightLimit + 1 - leftLimit) % 2 == 0 ? (values[half] + values[half - 1]) / 2 : values[half];
        }

        public static int GetMedianForTwoArrays(List<int> first, List<int> second)
        {
            int n = first.Count;

            if (n == 1)
            {
                return (first[0] + second[0])/2;
            }

            // start merging elements and stop when you hit n
            // where n is the size of each array            

            int i = 0;
            int j = 0;

            int pos = 0;
            int mLeft = 0;
            int mRight = 0; // the two numbers that compose the average value with their average
            while (pos <= n)
            {
                if (i == n)
                {
                    // hit the end of the first list
                    return (first[n - 1] + second[0])/2;
                }

                if (j == n)
                {
                    // hit the end of the second list
                    return (first[0] + second[n - 1])/2;
                }

                if (first[i] < second[j])
                {
                    mLeft = mRight;
                    mRight = first[i];
                    i++;
                }
                else if (first[i] > second[j])
                {
                    mLeft = mRight;
                    mRight = second[j];
                    j++;
                }

                pos++;
            }

            return (mLeft + mRight)/2;
        }

        public static int GetMedianInLogN(List<int> first, int firstLeft, int firstRight, 
            List<int> second, int secondLeft, int secondRight)
        {
            // the two arrays will always have the same size
            int size = firstRight - firstLeft + 1;
            if (size == 1)
            {
                return (first[firstLeft] + second[secondLeft])/2;
            }

            if (size == 2)
            {
                return (Math.Max(first[firstLeft], second[secondLeft]) +
                        Math.Min(first[firstRight], second[secondRight]))/2;
            }

            int medianFirst = GetMedianForArray(first, false, firstLeft, firstRight);
            int medianSecond = GetMedianForArray(second, false, secondLeft, secondRight);
            if (medianFirst == medianSecond)
            {
                return medianFirst;
            }

            // will have to take one side of the first array
            // and the other side of the second array
            // be sure to always include the median positions in both arrays

            int medianLeft = 0;
            int medianRight = 0;
            if (medianFirst > medianSecond)
            {
                medianRight = firstLeft + size / 2;
                medianLeft = size % 2 == 0 ? secondLeft + size / 2 - 1 : secondLeft + size / 2;
                return GetMedianInLogN(first, firstLeft, medianRight, second, medianLeft, secondRight);
            }

            medianRight = secondLeft + size / 2;
            medianLeft = size % 2 == 0 ? firstLeft + size / 2 - 1 : firstLeft + size / 2;
            
            return GetMedianInLogN(first, medianLeft, firstRight, second, secondLeft, medianRight);
        }
    }
}
