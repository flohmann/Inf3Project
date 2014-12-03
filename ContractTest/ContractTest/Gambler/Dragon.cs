using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    public class Dragon : Entity
    {  
        public Dragon(int id, int x, int y, String type, Boolean busy, String desc) : base(id, x, y, type)
        {
            setBusy(busy);
            setDesc(desc);
        }


    }
}
