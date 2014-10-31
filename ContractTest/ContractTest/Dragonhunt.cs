using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    class Dragonhunt : Challenge
    {
        private EnumDragonhunt enumDragonhunt;

        public Dragonhunt(Int32 id, Player player, Opponent opponent, Boolean isAccepted)
            : base(opponent, isAccepted){
        

        }

    }
}
}