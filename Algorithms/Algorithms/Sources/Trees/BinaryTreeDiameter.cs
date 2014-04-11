using System;

namespace Algorithms.Sources.Trees
{
    /*
     * The diameter of a tree (sometimes called the width) is the number of nodes 
     * on the longest path between two leaves in the tree.
     * 
     * the diameter for a node is the maximum diameter between its left and its right nodes
     * or the sum of its nodes max height + 1 where the max height represents the distance
     * between the node and the most distand leaf
     */
    public static class BinaryTreeDiameter
    {
        public static int GetDiameter<T>(BinaryTree<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return Math.Max(1 + getTreeHeight(node.Left, 1) + getTreeHeight(node.Right, 1),
                Math.Max(GetDiameter(node.Left), GetDiameter(node.Right)));
        }

        private static int getTreeHeight<T>(BinaryTree<T> node, int level)
        {
            if (node == null)
            {
                return level - 1 ;
            }
            return Math.Max(getTreeHeight(node.Left, level + 1), getTreeHeight(node.Right, level + 1));
        }
    }
}