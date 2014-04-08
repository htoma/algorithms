namespace Algorithms.Sources
{
    public static class BinaryTreeNextBiggerNumber
    {
        /// <summary>
        /// given a node, find the next bigger value in a BST
        /// that would be either the left most child of the right child if the node has a right child
        /// otherwise the next node in inoder traversal
        /// </summary>
        /// <returns></returns>
        public static int FindNextBiggerValueForNode(BinaryTree<int> node, BinaryTree<int> head)
        {
            if (node == null)
            {
                return -1;
            }
            
            BinaryTree<int> child = node.Right;
            if (child != null)
            {                
                BinaryTree<int> temp = child.Left;
                while (temp != null)
                {
                    child = temp;
                    temp = temp.Left;
                }
                return child.Data;
            }

            // next bigger element is the next node in inoder traversal
            child  = head;
            BinaryTree<int> prev = null;
            while (true)
            {
                if (child == null || child.Data == node.Data)
                {
                    break;
                }
                
                if (child.Data > node.Data)
                {
                    prev = child;
                    child = child.Left;
                }
                else
                {
                    child = child.Right;
                }
            }

            return prev != null ? prev.Data : -1;
        }
    }
}