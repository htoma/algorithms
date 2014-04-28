namespace Algorithms.Sources
{
    public static class FindUniqueAmongTriplets
    {
        public static int Find(int[] values)
        {
            /*
             * a list of triplets and a single element
             * we should identify that single element
             * the idea is to do an addition for each digit starting from the right of all numbers
             * and put the sum % 3 in the corresponding position of the result
             */

            if (values.Length < 4 || values.Length % 3 != 1)
            {
                return -1;
            }

            int result = 0;
            // check each bit
            for (int i = 0; i < 31; i++)
            {
                // sum the bit for all numbers
                int sum = 0;
                int mask = 1 << i;
                foreach (int el in values)
                {
                    if ((el & mask) > 0)
                    {
                        sum++;
                    }
                }
                result |= (sum % 3) << i;
            }
            return result;
        }
    }
}