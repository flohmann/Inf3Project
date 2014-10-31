using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    class Dragon : IPositionable
    {
        private Int32 dragonId;
        private Dragon type;
        private Boolean isBusy;
        private String desc;
        private int x;
        private int y;

        public Dragon(Int32 id){
          
        }
        public Dragon dragonId { get; set; }

    }
}
