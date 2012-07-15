using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class RaceWinAchievement : Achievement
    {
        public RaceWinAchievement() : base("Win a Race", "Won a race in the Atomic F1 championshiop", "RaceWin") { }

        protected override int Occurrences(Driver driver)
        {
            return GetAllRaces(driver).Count(r => r.GetRaceResult(r.GetRaceEntry(driver)).Position == 1);
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            return entry.Race.GetRaceResult(entry).Position == 1;
        }
    }
}
