using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    class Skirmish : Challenge
    {
        public Skirmish(Opponent opponent, Boolean isAccepted)
            : base(opponent, isAccepted,"Skirmish")
        {

        }
    }
}
