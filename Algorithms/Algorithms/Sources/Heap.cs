using System;
using System.Collections.Generic;

namespace Algorithms.Sources
{
    /// <summary>
    /// binary heap
    /// </summary>
    public class Heap
    {
        private readonly List<int> _values = new List<int>();
        private readonly Func<int, int, bool> _comparer = (x, y) => x < y; 

        public Heap(bool ascending = true)
        {
            if (!ascending)
            {
                _comparer = (x, y) => x > y;
            }
        }

        public Heap(List<int> values, bool ascending = true)
        {
            if (!ascending)
            {
                _comparer = (x, y) => x > y;
            }

            // heapify list of values
            _values = values;

            Heapify();
        }

        public void Heapify()
        {
            // heap down, but have to start with the childs
            // the first one to be processed will be the parent of last element
            for (int pos = getParentPos(_values.Count - 1); pos >= 0; pos--)
            {
                heapDown(pos, _values.Count - 1);
            }
        }

        public int Pop()
        {
            if (_values.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int result = _values[0];
            _values.RemoveAt(0);
            if (_values.Count > 1)
            {
                heapDown(0, _values.Count - 1);
            }
            return result;
        }

        public int Capacity()
        {
            return _values.Count;
        }

        public void Print()
        {
            _values.ForEach(x => Console.Write("{0} ", x));
            Console.WriteLine();
        }
        
        public void Insert(int element)
        {
            _values.Add(element);
            if (_values.Count == 1)
            {
                return;
            }

            // nead to heap up the last element
            heapUp(_values.Count - 1);
        }

        public List<int> GetSorted()
        {
            var result = new List<int>();
            if (_values.Count == 0)
            {
                return result;
            }

            int curPos = _values.Count - 1;
            for (int i = 0; i < _values.Count; i++)
            {
                switchValues(0, curPos);
                result.Add(_values[curPos]);
                heapDown(0, --curPos);
            }

            // at the end of the method, the heap will be sorted in reverse order
            // it needs to be heapified
            Heapify();

            return result;
        }

        public int Peek()
        {
            if (_values.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _values[0];
        }

        private void heapDown(int pos, int endPos)
        {
            if (endPos <= 0)
            {
                return;
            }

            // move the element down to compare it with its children
            while (true)
            {
                int posLeftChild = getLeftChildPos(pos);
                if (posLeftChild > endPos)
                {
                    break;
                }

                int posRightChild = getRightChildPos(pos);
                if (posRightChild > endPos)
                {
                    posRightChild = posLeftChild;
                }

                if (!_comparer(_values[posLeftChild], _values[pos])  &&
                    !_comparer(_values[posRightChild], _values[pos]))
                {
                    break;
                }
                
                // which child will be replaced
                int childPos = _comparer(_values[posLeftChild], _values[posRightChild]) ? posLeftChild : posRightChild;
                switchValues(pos, childPos);
                pos = childPos;
            }
        }

        private void heapUp(int pos)
        {
            if (pos <= 0)
            {
                return;
            }

            while (true)
            {
                int posParent = getParentPos(pos);
                if (posParent < 0)
                {
                    break;
                }

                if (!_comparer(_values[pos], _values[posParent]))
                {
                    // nothing left to do
                    break;
                }

                switchValues(posParent, pos);
                pos = posParent;               
            }
        }

        private int getParentPos(int pos)
        {
            return (pos - 1) / 2;
        }

        private int getLeftChildPos(int pos)
        {
            return 2 * pos + 1;
        }

        private int getRightChildPos(int pos)
        {
            return 2 * pos + 2;
        }

        private void switchValues(int leftPos, int rightPos)
        {
            int temp = _values[rightPos];
            _values[rightPos] = _values[leftPos];
            _values[leftPos] = temp;
        }
    }
}
