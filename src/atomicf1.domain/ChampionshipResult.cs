using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class ChampionshipResult 
    {     
        public virtual DriverContract Entrant { get; set; }

        public virtual decimal Points { get; set; }

        public virtual int Position { get; set; }

        public virtual decimal TieBreaker { get; set; }
    }
}
