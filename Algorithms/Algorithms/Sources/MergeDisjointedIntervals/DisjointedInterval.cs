namespace Algorithms.Sources.MergeDisjointedIntervals
{
    public class DisjointedInterval
    {
        public int Left { get; set; } 
        public int Right { get; set; }

        public DisjointedInterval(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }
}