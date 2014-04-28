namespace Algorithms.Sources
{
    public static class AdditionWithBitOperations
    {
        public static int Add(int a, int b)
        {
            // the idea is that if you add two bits,
            // XOR gives the correct digit
            // AND gives the carry

            int result = 0;
            int carry = 0;
            int pos = 0;
            while (a > 0 || b > 0)
            {
                int digita = a > 0 ? a % 2 : 0;
                int digitb = b > 0 ? b % 2 : 0;

                if (carry > 0)
                {
                    carry = (digita | digitb) == 0 ? 0 : 1;
                    digita = digita ^ carry;
                }
                else
                {
                    carry = digita & digitb;
                }
                int bit = digita ^ digitb;
                
                if (bit > 0)
                {
                    result |= 1 << pos;
                }

                if (a > 0)
                {
                    a >>= 1;
                }
                if (b > 0)
                {
                    b >>= 1;
                }
                pos++;
            }
            if (carry == 1)
            {
                result |= 1 << pos;
            }
            return result;
        }
    }
}