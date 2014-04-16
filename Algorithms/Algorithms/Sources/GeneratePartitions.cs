using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sources
{
    public static class GeneratePartitions
    {
        public static void Partition(List<int> values)
        {
            List<List<int>> partitions = computePartitions(values);
            partitions.ForEach(
                x =>
                {
                    x.ForEach(y => Console.WriteLine("{0} ", y));
                    Console.WriteLine();
                });
        }

        public static List<List<int>> computePartitions(List<int> toSelect)
        {
            var result = new List<List<int>>();
            if (toSelect.Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (toSelect.Count == 1)
            {
                result.Add(new List<int> { toSelect.First() });
                return result;
            }
            for (int i = 0; i < toSelect.Count; i++)
            {
                var resultList = new List<int> { toSelect[i] };
                var list = new List<int>(toSelect);
                list.RemoveAt(i);
                foreach (List<int> partition in computePartitions(list))
                {
                    result.Add(resultList.Concat(partition).ToList());
                }
            }
            return result;
        } 
    }
}