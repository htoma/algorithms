using System.Collections.Generic;

namespace Algorithms.Utils
{
    public static class Utils
    {
        public static int MedianForSorted(List<int> values)
        {
            if (values.Count == 0)
            {
                return 0;
            }

            int half = values.Count / 2;
            return values.Count % 2 == 0 ? (values[half - 1] + values[half]) / 2 : values[half];
        }

        public static void Switch<T>(T[] values, int first, int second)
        {
            T aux = values[first];
            values[first] = values[second];
            values[second] = aux;
        }

        public static void Switch<T>(List<T> values, int first, int second)
        {
            T aux = values[first];
            values[first] = values[second];
            values[second] = aux;
        }
    }
}