using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project.Game
{
    class LinearSearch
    {
        class LinearSearch<C>
        {
            public C find(List<C> list, Func<C, bool> criterion)
            {
                C result = default(C);
                int i = 0;
                while (i < list.Count)
                {
                    if (criterion(list[i]))
                    {
                        Console.WriteLine("Found");
                        result = list[i];
                        return result;
                    }
                    i++;
                }
                Console.WriteLine("Not found");
                return result;
            }
        }
    }
}
