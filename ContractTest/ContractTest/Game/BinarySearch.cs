using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project.Game
{
    class BinarySearch<C>
    {
        /// <summary>
        /// Binary search through a list. Takes the middle of a list the searched element is not found yet.
        /// if the searched element is higher than the value of the middle element it continues on the right and vice versa.
        /// it is recursively elected a new middle element and looked again if a given element is larger or smaller.
        /// the expense is halved after each step
        /// </summary>
        /// <param name="list">the sorted! list to search through</param>
        /// <param name="criterion">the criterion from which we determine, whether we have found our element</param>
        /// <returns>the element, if it is found, or the "not found", if not</returns>
        public C find(List<C> list, Func<C, int> criterion)
        {

            C result = default(C);

            int middle;
            int left = 0;
            int right = list.Count - 1;

            

            while (left <= right)
            {
                middle = left + ((right - left) / 2);
                if (criterion(list[middle]) == 0)
                {
                    Console.WriteLine("Found");
                    result = list[middle];
                    return result;
                }
                else if (criterion(list[middle]) > 0)
                {
                    right = middle - 1;
                }
                else if (criterion(list[middle]) < 0)
                {
                    left = middle + 1;
                }

            }
            
           
            Console.WriteLine("Not Found");
            return result;


      
        }

    }
    }

