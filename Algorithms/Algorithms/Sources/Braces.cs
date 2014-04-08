using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sources
{
    public static class Braces
    {
        public static bool Ok(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            var stack = new Stack<char>();

            var dictionary = new Dictionary<char, char>
            {
                { ']', '[' },
                { '}', '{' },
                { ')', '(' }
            };
            var opening = dictionary.Values;
            var closing = dictionary.Keys;

            foreach (char c in text)
            {
                if (opening.Contains(c))
                {
                    stack.Push(c);
                }
                else if (closing.Contains(c))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    char lastBrace = stack.Pop();
                    if (lastBrace != dictionary[c])
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        } 
    }
}