namespace Algorithms.Sources.SkipLists
{
    public class Node
    {
        public int Value { get; private set; }

        public LevelNode[] LevelNodes { get; set; }

        public int LevelCount { get; private set; }

        public Node(int value, int levelCount)
        {
            Value = value;
            LevelCount = levelCount;
            LevelNodes = new LevelNode[levelCount];
        }
    }
}