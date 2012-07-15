using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public class Champion
    {
        public Champion(DriverContract entrant, string season)
        {
            Entrant = entrant;
            Season = season;
        }

        public DriverContract Entrant { get; private set; }
        public string Season { get; private set; }
    }
}
