namespace Algorithms.Sources
{
    public static class LongestCommonSubsequence
    {
        public static string Lcs(string first, string second)
        {
            return lcs(first, second, first.Length - 1, second.Length - 1);
        }

        private static string lcs(string first, string second, int posFirst, int posSecond)
        {
            if (posFirst < 0 || posSecond < 0)
            {
                return string.Empty;
            }

            if (first[posFirst] == second[posSecond])
            {
                return lcs(first, second, posFirst - 1, posSecond - 1) + first[posFirst];
            }

            string useFirst = lcs(first, second, posFirst - 1, posSecond);
            string useSecond = lcs(first, second, posFirst, posSecond - 1);

            return useFirst.Length < useSecond.Length ? useSecond : useFirst;
        }
    }
}