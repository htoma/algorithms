using System;

namespace Algorithms.Sources
{
    public static class Count2InNumbersLessThanN
    {
        public static int Count(int n)
        {
            /*
             * the idea is to get a form of recursion with the count found at previous level
             * where level is the digit at right
             * here is the formulae:
             * np = np * d, if d < 2
             * np = np * d + 1 + (n % (10^k)), if d == 2, where k is the digit index starting from the right (the order of magnitude)
             * np = np * d + 10^k, if d > 2, where k is the digit index starting from the right (the order of magnitude)
            */

            if (n < 2)
            {
                return 0;
            }

            // generalize
            const int k = 2;
            int previousLevelCount = 0;
            int digitPosition = 0;
            int result = 0;

            int number = n;
            while (n > 0)
            {
                int digit = n % 10;
                int currentLevelMax = previousLevelCount * 10 + (int) Math.Pow(10, digitPosition);
                previousLevelCount = previousLevelCount * digit;
                if (digit == k)
                {
                    previousLevelCount += 1 + number % ((int)Math.Pow(10, digitPosition));
                }
                else if (digit > k)
                {
                    previousLevelCount += (int)Math.Pow(10, digitPosition);
                }

                result += previousLevelCount;
                previousLevelCount = currentLevelMax;
                digitPosition++;
                n /= 10;
            }
            return result;
        }
    }
}