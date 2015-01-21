using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inf3Project.Game
{
    class Quicksort<C>
    {
        ///<summary>Quicksort first divides a large list into two smaller lists: left and right according to the pivot element
        ///all elements with values less than the pivot come left the pivot,
        ///while all elements with values greater than the pivot come right 
        ///</summary>
        ///<param name="list">the list to search through</param>
        ///<param name="pivot">the pivot element</param> 
        /// <returns>the sorted list</returns>

        public List<C> sort(List<C> list, int left, int right, Func<C, C, int> comp)
        {
            int l = left; int r = right;

            C pivot = list[l];
            C tmp;

            while (l <= r)
            {
                while (comp(list[l], pivot) < 0)
                {
                    l++;
                }
                while (comp(list[r], pivot) > 0)
                {
                    r--;
                }
                if (l <= r)
                {
                    tmp = list[l];
                    list[l++] = list[r];
                    list[r--] = tmp;
                }
            }
            if (left < r)
            {
                sort(list, left, r, comp);
            }
            if (l < right)
            {
                sort(list, l, right, comp);
            }
            return list;
        }
    }
}