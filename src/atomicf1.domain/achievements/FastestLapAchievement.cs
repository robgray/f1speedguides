using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class FastestLapAchievement : Achievement
    {
        public FastestLapAchievement() : base("Fastest Lap of a Race", "Have the Fastest Lap at the end of a Race", "FastestLap") { }
        
        protected override int Occurrences(Driver driver)
        {
            return GetAllRaces(driver).Count(r => r.GotFastestLap(driver));            
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            return entry.Race.GotFastestLap(entry.Entrant.Driver);
        }
    }
}
