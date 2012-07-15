using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class PolePositionAchievement : Achievement
    {
        public PolePositionAchievement() : base("Earn a Pole Position", "Earned a pole position in the Atomic F1 championship", "PolePosition") { }

        protected override int Occurrences(Driver driver)
        {
            return (GetAllRaces(driver).Count(r => r.GetQualifyingResult(r.GetRaceEntry(driver)).Position == 1));                
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            return entry.Race.GetQualifyingResult(entry).Position == 1;
        }
    }
}
