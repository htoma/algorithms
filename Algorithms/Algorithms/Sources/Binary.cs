namespace Algorithms.Sources
{
    public static class Binary
    {
        public static string ShowBinary(int n)
        {
            if (n == 0)
            {
                return "0";
            }
            string binary = "";
            while (n > 0)
            {
                binary = (n % 2) + binary;
                n /= 2;
            }
            return binary;
        }

        public static int CountOnes(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int count = 0;
            for (; (n & (n - 1)) > 0; n = n & (n - 1))
            {
                count++;
            }
            return count;
        }

        public static int FromBinary(string binary)
        {
            int result = 0;
            foreach (char c in binary)
            {
                result *= 2;
                if (c == '1')
                {
                    result++;
                }
            }
            return result;
        }

        public static int GetNextBiggerNumberWithTheSameNumberOfOnes(int n)
        {
            // we need to find a 1 and then a 0 starting from the right
            // we'll put 1 where we found the 0
            // and we'll put 0 on the first 1 at its right

            if (n == 0)
            {
                return -1;
            }

            int result = 0;
            int curPos = 1;
            bool replaced = false;
            int posOne = 0;
            while (n > 0)
            {
                int digit = n % 2;
                if (digit == 1)
                {
                    if (!replaced)
                    {
                        posOne = curPos;
                    }                    
                    result |= 1 << (curPos - 1);
                }
                else
                {
                    if (!replaced)
                    {
                        if (posOne > 0)
                        {
                            result |= 1 << (curPos - 1);
                            replaced = true;
                        }
                    }
                }
                n >>= 1;
                curPos++;
            }
            if (!replaced && curPos < 31)
            {
                // number looks like 1111...10000...0
                // but all is not lost, we'll try putting one in front
                result = (1 << (curPos - 1)) + result;
                replaced = true;
            }

            if (!replaced)
            {
                // we tried our best
                return -1;
            }

            // one more thing left, put 0 in the left most position where we found a 1
            return clearBit(result, posOne);
        }

        private static int clearBit(int n, int pos)
        {
            int bitCount = countBits(n);
            int left = (1 << (bitCount - pos)) - 1;
            left <<= pos;
            if (pos == 0)
            {
                return left;
            }
            int right = (1 << (pos - 1)) - 1;
            return (left | right) & n;
        }

        private static int countBits(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int count = 0;
            while (n > 0)
            {
                count++;
                n >>= 1;
            }
            return count;
        }
    }
}