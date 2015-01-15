using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project.Game
{
    class BinarySearch<C>
    {
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

