using System;
using System.Collections.Generic;

namespace Algorithms.Sources
{
    public static class NextBiggerInteger
    {
        /// <summary>
        /// the idea is to find the rotating point
        /// meaning the point where a digit is lower than the next one
        /// starting from that point and until the end of digit array, every position will be changed
        /// put all ascending digits in the queue and find the first one bigger than the inflexion point
        /// it will be that digit that will replace the value at the inflexion point
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetNext(int n)
        {
            if (n < 10)
            {
                return n;
            }

            int digit = n % 10;
            var q = new Queue<int>();
            q.Enqueue(digit);
            n /= 10;

            while (n > 0)
            {
                int tempDigit = n % 10;
                n /= 10;
                if (tempDigit > digit)
                {
                    q.Enqueue(tempDigit);
                    digit = tempDigit;
                }
                else
                {
                    if (n > 0)
                    {
                        // set the left part
                        n *= (int) Math.Pow(10, q.Count + 1);
                    }

                    // found the rotation point
                    // build the right part starting from here
                    int result = 0;
                    int pos = 0;
                    bool switched = false;
                    while (!switched || q.Count > 0)
                    {
                        int el = q.Dequeue();
                        pos++;
                        result *= 10;
                        if (!switched && el > tempDigit)
                        {                            
                            result += tempDigit;
                            result += el * (int)Math.Pow(10, pos); 
                            switched = true;
                        }
                        else if (switched || el < tempDigit)
                        {                            
                            result += el;
                        }                        
                    }
                    return n + result;
                }
            }
            return -1;
        }
    }
}