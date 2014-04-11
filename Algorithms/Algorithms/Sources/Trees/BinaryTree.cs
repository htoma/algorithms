﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.Sources.Trees
{
    public class BinaryTree<T>
    {
        public T Data { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public BinaryTree(T data)
        {
            this.Data = data;
        } 

        public BinaryTree(List<T> values)
            : this(values, 0, values.Count - 1)
        {            
        } 

        public BinaryTree(List<T> values, int start, int end)
        {
            this.insertBalanced(values, start, end);
        } 

        public static List<T> Inorder(BinaryTree<T> node)
        {
            if (node == null || Equals(node.Data, default(T)))
            {
                return null;
            }
            
            List<T> left = Inorder(node.Left);
            if (left == null)
            {
                left = new List<T>();
            }

            left.Add(node.Data);

            List<T> right = Inorder(node.Right);

            return right != null ? left.Concat(right).ToList() : left;
        }

        public static List<T> Preorder(BinaryTree<T> node)
        {            
            if (node == null || Equals(node.Data, default(T)))
            {
                return new List<T>();
            }

            var result = new List<T> { node.Data };

            List<T> left = Preorder(node.Left);
            if (left != null)
            {
                result = result.Concat(left).ToList();
            }

            List<T> right = Preorder(node.Right);
            if (right != null)
            {
                result = result.Concat(right).ToList();
            }
            

            return result;
        }

        public static List<T> Postorder(BinaryTree<T> node)
        {
            if (node == null || Equals(node.Data, default(T)))
            {
                return null;
            }

            var result = new List<T>();

            List<T> left = Postorder(node.Left);
            if (left != null)
            {
                result = left;
            }

            List<T> right = Postorder(node.Right);
            if (right != null)
            {
                result = result.Concat(right).ToList();
            }

            result.Add(node.Data);

            return result;
        }

        public static BinaryTree<T> FindNode(T data, BinaryTree<T> head, IComparer<T> comparer)
        {
            if (head == null)
            {
                return null;
            }
            if (comparer.Compare(head.Data, data) == 0)
            {
                return head;
            }
            if (comparer.Compare(head.Data, data) < 0)
            {
                return FindNode(data, head.Right, comparer);
            }
            return FindNode(data, head.Left, comparer);
        }

        public static int GetTreeHeight(BinaryTree<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetTreeHeight(node.Left), GetTreeHeight(node.Right));
        }

        public static Dictionary<int, int> GetWidths(BinaryTree<T> node)
        {
            var result = new Dictionary<int, int>();
            getWidth(node, 1, result);
            return result;
        }

        /// <summary>
        /// checks if BT is BST
        /// check not only that the current node is ok
        /// but also that all of its left children are less than it
        /// and all the right children are bigger than it
        /// 
        /// for each node, return the min and max of his children
        /// </summary>
        public static bool IsTreeBinarySearchTree(BinaryTree<int> node, out int min, out int max)
        {
            max = node.Data;
            min = node.Data;

            int temp = node.Data;
            bool ok = node.Left == null || IsTreeBinarySearchTree(node.Left, out min, out temp);
            if (!ok || temp > node.Data)
            {
                return false;
            }

            temp = node.Data;
            ok = node.Right == null || IsTreeBinarySearchTree(node.Right, out temp, out max);
            if (!ok || temp < node.Data)
            {
                return false;
            }
            return true;
        }

        private static void getWidth(BinaryTree<T> node, int level, Dictionary<int, int> levelWidths)
        {
            if (node == null)
            {
                return;
            }

            if (!levelWidths.ContainsKey(level))
            {
                levelWidths[level] = 1;
            }
            else
            {
                levelWidths[level]++;
            }
            getWidth(node.Left, level + 1, levelWidths);
            getWidth(node.Right, level + 1, levelWidths);
        }

        /// <summary>
        /// use the interval half split insertion for balancing
        /// </summary>
        private void insertBalanced(List<T> values, int start, int end)
        {
            if (start > end)
            {
                throw new InvalidDataException();
            }

            if (start == end)
            {
                this.Data = values[start];
                return;
            }

            int diff = end - start;
            int half = start + diff / 2;
            this.Data = values[half];
            this.Left = start <= half -1 ? new BinaryTree<T>(values, start, half - 1) : null;
            this.Right = half + 1 <= end ? new BinaryTree<T>(values, half + 1, end) : null;
        }         
    }
}