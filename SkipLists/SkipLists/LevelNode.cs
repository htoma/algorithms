namespace SkipLists
{
    public class LevelNode
    {
        public int Value { get { return ParentNode.Value; } }

        public LevelNode Next { get; set; }

        public Node ParentNode { get; private set; }

        /// <summary>
        /// how many level 0 nodes are jumped from the previous node 
        /// of this level
        /// used for partial counts
        /// </summary>
        public int SkippedNodes { get; set; }

        public LevelNode( Node parentNode)
        {
            ParentNode = parentNode;
        }
    }
}