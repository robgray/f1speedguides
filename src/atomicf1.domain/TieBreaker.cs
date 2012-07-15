using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class TieBreaker
    {
        public decimal Calculate(Season season, Driver driver)
        {        
            return season.Races.SelectMany(r => r.Entries).Count(x => x.Entrant.Driver.Id == driver.Id && x.RacePlace == 1);
        }
    }
}
