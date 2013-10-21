using System;
using System.Collections.Generic;

namespace SkipLists
{
    using System.Linq;

    public class SkipList
    {
        private const int MAX_LEVELS = 32;
        
        private readonly Node _head;

        private readonly Random _random;

        private int _currentMaxLevels;

        private readonly int _maxLevels;

        public SkipList(int maxLevels = MAX_LEVELS)
        {
            _maxLevels = maxLevels >= 1 && maxLevels <= MAX_LEVELS ? maxLevels : MAX_LEVELS;
            _head = new Node(int.MinValue + 1, maxLevels);
            _head.LevelNodes[0] = new LevelNode(_head);
            
            _random = new Random();
            _currentMaxLevels = 0;            
        }

        public void Insert(int value)
        {
            var map = new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 7, 1 }, { 9, 2 }, { 10, 3 } };

            // logN operation
            int nodeLevels = generateRandomLevelCount(); //map[value]; 

            // avoid going beyond the current max levels
            if (nodeLevels > _currentMaxLevels)
            {
                _head.LevelNodes[_currentMaxLevels] = new LevelNode(_head);

                // increase the current max level
                _currentMaxLevels++;
                nodeLevels = _currentMaxLevels;
            }

            var node = new Node(value, nodeLevels);

            // start scanning from the highest level accessible to this node
            // need to update later on the skipped nodes for each level
            // and the next for each node on each level
            // we cannot do that unless we know how many level 0 nodes were actually skipped

            var skippedNodesMap = new Dictionary<int, dynamic>();
            var countSkippedPerLevel = new int[_currentMaxLevels];
            LevelNode pointer = _head.LevelNodes[_currentMaxLevels - 1];

            for (var level = _currentMaxLevels - 1; level >= 0; level--)
            {
                pointer = pointer.ParentNode.LevelNodes[level];
                
                countSkippedPerLevel[level] = 0;
                while (pointer.Next != null)
                {
                    if (pointer.Next.Value > value)
                    {
                        // no need to step away, found our node
                        break;
                    }

                    pointer = pointer.Next;

                    // if we are on the highest level and moving, it means we haven't found the anchor point
                    if (level != _currentMaxLevels - 1)
                    {
                        countSkippedPerLevel[level] += pointer.SkippedNodes + 1;                        
                    }
                }
                
                if (level < nodeLevels)
                {
                    // create node if needed
                    var levelNode = new LevelNode(node);
                    levelNode.Next = pointer.Next;
                    node.LevelNodes[level] = levelNode;
                    pointer.Next = levelNode;
                    
                    // will have to update the skipped nodes for this node
                    skippedNodesMap[level] = new {
                                                     IsNew = true,
                                                     Node = levelNode
                                                 };

                    if (level > 0)
                    {
                        // we'll update this value later
                        levelNode.SkippedNodes = 0;
                    }
                    else
                    {
                        // update values for upper levels
                        for (int i = 1; i < _currentMaxLevels; i++)
                        {
                            dynamic toUpdate = skippedNodesMap[i];
                            LevelNode nodeToUpdate = toUpdate.Node;
                            if (toUpdate.IsNew)
                            {                                
                                nodeToUpdate.SkippedNodes = nodeToUpdate.ParentNode.LevelNodes[i - 1].SkippedNodes + 
                                    countSkippedPerLevel[i - 1];
                                if (nodeToUpdate.Next != null)
                                {
                                    nodeToUpdate.Next.SkippedNodes = nodeToUpdate.Next.SkippedNodes -
                                                                     nodeToUpdate.SkippedNodes;
                                }
                            }
                            else
                            {
                                if (nodeToUpdate.Next != null)
                                {
                                    nodeToUpdate.Next.SkippedNodes += 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    skippedNodesMap[level] = new
                                                 {
                                                     IsNew = false,
                                                     Node = pointer
                                                 };
                }                                    
            }          
        }

        public IEnumerable<int> GetElements()
        {
            // O(N) operation

            LevelNode tmp = _head.LevelNodes[0].Next;

            while (tmp != null)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }

        public bool Exists(int value)
        {
            // start scanning from the highest level
            Node tmp = _head;
            for (var level = _currentMaxLevels - 1; level >= 0; level--)
            {
                LevelNode pointer = tmp.LevelNodes[level];

                while (pointer.Next != null)
                {
                    if (pointer.Next.Value == value)
                    {
                        return true;
                    }

                    if (pointer.Next.Value > value)
                    {
                        // no need to step away, found our node
                        break;
                    }
                    pointer = pointer.Next;
                }

                tmp = pointer.ParentNode;
            }

            return false;
        }

        public void Remove(int value)
        {
            // logN operation

            // find the node in the list and remove it from every level
            Node tmp = _head;
            for (var level = _currentMaxLevels - 1; level >= 0; level--)
            {
                LevelNode pointer = tmp.LevelNodes[level];

                while (pointer.Next != null)
                {
                    if (pointer.Next.Value == value)
                    {
                        pointer.Next = pointer.Next.Next;
                        if (pointer.Next != null
                            && pointer.Next.SkippedNodes > 0)
                        {
                            pointer.Next.SkippedNodes--;
                        }
                        break;
                    }

                    if (pointer.Next.Value > value)
                    {
                        break;
                    }

                    pointer = pointer.Next;
                }

                tmp = pointer.ParentNode;
            }
        }

        public int? FindClosestElement(int value)
        {
            if (isEmpty())
            {
                return null;
            }

            // logN operation
            // start scanning from the highest level
            Node tmp = _head;
            for (var level = _currentMaxLevels - 1; level >= 0; level--)
            {
                LevelNode pointer = tmp.LevelNodes[level];

                while (pointer.Next != null)
                {
                    if (pointer.Next.Value == value)
                    {
                        return value;
                    }

                    if (pointer.Next.Value > value)
                    {
                        // no need to step away, found our node
                        break;
                    }
                    pointer = pointer.Next;
                }

                tmp = pointer.ParentNode;

                if (level == 0)
                {
                    // check whether the left or right is closer
                    if (pointer.Next == null)
                    {
                        return pointer.Value;
                    }

                    int left = Math.Abs(pointer.Value - value);
                    int right = Math.Abs(value - pointer.Next.Value);
                    return left <= right ? 
                        (pointer.ParentNode == _head ? _head.LevelNodes[0].Value : pointer.Value) : pointer.Next.Value;
                }
            }
            return _head.Value;
        }

        public int? FindKLargestElement(int k)
        {
            if (k <= 0)
            {
                return null;
            }

            // logN operation
            // start scanning from the highest level
            int count = 0;
            Node tmp = _head;
            for (var level = _currentMaxLevels - 1; level >= 0; level--)
            {
                LevelNode pointer = tmp.LevelNodes[level];

                while (pointer.Next != null)
                {
                    if (count + pointer.Next.SkippedNodes + 1 == k)
                    {
                        return pointer.Next.ParentNode.Value;
                    }

                    if (count + pointer.Next.SkippedNodes + 1 > k)
                    {
                        // no need to step away, found our node
                        break;
                    }
                    pointer = pointer.Next;
                    count = count + pointer.SkippedNodes + 1;
                }

                tmp = pointer.ParentNode;
            }

            return null;
        }

        public int CountElementsInRange(int left, int right)
        {
            // logN operation
            if (left > right || isEmpty())
            {
                return 0;
            }

            // find the left edge (not necessarily equal to left)
            // then the right edge
            // can do it in one step, but when left is found, we have to go the highest level again
            // it's more clear with two distinct iterations
            bool leftFound = false;
            Node edge = _head;
            int levelFound = 0;
            for (var level = _currentMaxLevels - 1; !leftFound && level >= 0; level--)
            {
                LevelNode pointer = edge.LevelNodes[level];

                while (!leftFound && pointer.Next != null)
                {
                    // exactly on the left edge
                    if (pointer.Next.Value == left)
                    {
                        levelFound = level;
                        leftFound = true;                     
                    }
                    else if (pointer.Next.Value > left)
                    {
                        if (level == 0)
                        {
                            // ok, no value equal to left in this list
                            // will have to settle to the closest higher value if not higher than right
                            if (pointer.Next.Value > right)
                            {
                                return 0;
                            }

                            leftFound = true;
                        }
                        else
                        {
                            // go down a level
                            break;
                        }
                    }

                    pointer = pointer.Next;
                }

                edge = pointer.ParentNode;                            
            }

            if (!leftFound)
            {
                return 0;
            }

            int count = 1;

            // look for the right edge
            for (var level = levelFound; level >= 0; level--)
            {
                LevelNode pointer = edge.LevelNodes[level];

                while (pointer.Next != null)
                {
                    // exactly on the right edge
                    if (pointer.Next.Value == right)
                    {
                        return count + pointer.Next.ParentNode.LevelNodes[level].SkippedNodes + 1;
                    }
                    
                    if (pointer.Next.Value > right)
                    {
                        // try on lower levels
                        break;
                    }

                    count += pointer.Next.ParentNode.LevelNodes[level].SkippedNodes + 1;
                    pointer = pointer.Next;                    
                }

                edge = pointer.ParentNode;
            }

            return count;
        }

        public void PrintConfiguration()
        {
            Console.WriteLine("List configuration");
            var tmp = _head.LevelNodes[0];
            while (tmp.Next != null)
            {
                Console.WriteLine(string.Format("Value: {0}, Levels with skipped: {1}",
                    tmp.Next.ParentNode.Value,
                    string.Join(", ",
                    tmp.Next.ParentNode.LevelNodes.Select(x => string.Format("{0}", x.SkippedNodes)))));
                tmp = tmp.Next;
            }
        }
     
        private int generateRandomLevelCount()
        {
            // the limit for the number of levels is MAX_LEVELS
            // the probability of having more than one level is 1/2
            // having more than two levels is 1/4 and so on
            // generate a random number to cover the probability for MAX_LEVELS
            // but we should have at least one level
            // so let's generate a number with at most MAX_LEVELS bits
            // and choose the probability as the succession of bits of 1
            // don't go beyond the limits of int
            // max positive int 2^31-1
            int randLimit = 2 ^ (_maxLevels > 30 ? 30 : _maxLevels);
            int random = _random.Next(0, randLimit);
            
            // count the number of 1 bits in succession
            int level = 0;
            for (; (random & 1) == 1; random >>= 1)
            {
                level++;
            }

            return level + 1;
        }

        private bool isEmpty()
        {
            return _currentMaxLevels == 0 || _head.LevelNodes[0] == null || _head.LevelNodes[0].Next == null;
        }        
    }
}