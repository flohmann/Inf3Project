﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTest
{
    class Player
    {
        private Int32 playerId;
        private Boolean isBusy;
        private string desc;
        private int x;
        private int y;
        private int points;

        public Player(Int32 id)
        {
            this.playerId = id;
        }
    }
}
