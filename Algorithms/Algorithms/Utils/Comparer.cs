using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Utils
{
    public class Comparer<T> : IComparer<T>
    {
        private readonly bool _ascending;
        
        public Comparer(bool ascending = true)
        {
            _ascending = ascending;
        } 

        public int Compare(T x, T y)
        {
            int value = Comparer.Default.Compare(x, y);
            return value * (_ascending ? 1 : -1);
        }
    }
}