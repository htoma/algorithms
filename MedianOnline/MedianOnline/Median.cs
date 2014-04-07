namespace MedianOnline
{
    /// <summary>
    /// computes median for an incoming flow of numbers
    /// at each step, a new number is added
    /// and median has to be recomputed without sorting all previously seen numbers
    /// 
    /// Algorithm:
    /// keep two heaps such that the difference in their capacity is at most 1
    /// if one of the two heaps is larger, the median is its top
    /// left heap: smmaler than median, max element always top
    /// right heap: bigger than median, min element always top
    /// when a new number comes in:
    /// - if the two heaps have the same capacity, insert it in the left heap if it's lower than the median or in the right heap otherwise
    /// - otherwise if it's lower:
    ///            - if left heap has smaller capacity, insert it there 
    ///            - if left heap has bigger capacity, extract its top, remove it from left and insert into the right then insert element into the left
    /// - otherwise if it's bigger:
    ///            - if right heap has smaller capacity, insert it there
    ///            - if right heap has bigger capacity, extract its top, remove it from right and insert into the left then insert element into the right 
    /// </summary>
    public class Median
    {
        private int _median = 0;

        private readonly Heap _heapLeft = new Heap(false);
        private readonly Heap _heapRight = new Heap();

        public int GetMedian(int newNumber)
        {
            int leftSize = _heapLeft.Capacity();
            int rightSize = _heapRight.Capacity();

            if (leftSize == rightSize)
            {
                if (newNumber < _median)
                {
                    _heapLeft.Insert(newNumber);
                    _median = _heapLeft.Peek();
                }
                else
                {
                    _heapRight.Insert(newNumber);
                    _median = _heapRight.Peek();
                }
                return _median;
            }

            if (leftSize < rightSize)
            {
                if (newNumber < _median)
                {
                    _heapLeft.Insert(newNumber);
                }
                else
                {
                    int pop = _heapRight.Pop();
                    _heapLeft.Insert(pop);
                    _heapRight.Insert(newNumber);
                }
            }
            else
            {
                if (newNumber < _median)
                {
                    int pop = _heapLeft.Pop();
                    _heapRight.Insert(pop);
                    _heapLeft.Insert(newNumber);
                }
                else
                {
                    _heapRight.Insert(newNumber);
                }
            }

            _median = (_heapLeft.Peek() + _heapRight.Peek()) / 2;
            return _median;
        }
    }
}