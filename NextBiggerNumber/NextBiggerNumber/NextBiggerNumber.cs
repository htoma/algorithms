using System;
using System.Collections.Generic;

namespace NextBiggerNumber
{
    /*
     * Given an array, print the Next Greater Element (NGE) for every element. The Next greater Element for an element x is the first greater element on the right side of x in array. Elements for which no greater element exist, consider next greater element as -1.
     */
    public static class NextBiggerNumber
    {
        public static List<Tuple<int, int>> Compute(IEnumerable<int> values)
        {
            var result = new List<Tuple<int, int>>();
            var stack = new Stack<int>();
            foreach (var value in values)
            {
                if (stack.Count == 0)
                {
                    stack.Push(value);
                    continue;
                }
                
                int current = stack.Peek();
                // keep on popping until we find a bigger number in the stack
                while (current < value)
                {
                    stack.Pop();
                    result.Add(new Tuple<int, int>(current, value));
                    if (stack.Count > 0)
                    {
                        current = stack.Peek();
                    }
                    else
                    {
                        break;
                    }
                }

                stack.Push(value);
            }

            // for all remaining numbers in the stack, the next bigger number is -1
            while (stack.Count > 0)
            {
                int current = stack.Pop();
                result.Add(new Tuple<int, int>(current, -1));
            }
            return result;
        } 
    }
}
