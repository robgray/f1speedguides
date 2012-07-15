using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class PodiumAchievement : Achievement
    {
        public PodiumAchievement() : base("Score a Podium", "Secure a podium place in an Atomic F1 champsionship race", "Podium") { }

        protected override int Occurrences(Driver driver)
        {
            return GetAllRaces(driver).Count(r => r.GetRaceResult(r.GetRaceEntry(driver)).Position <= 3);
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            return entry.Race.GetRaceResult(entry).Position <= 3;
        }
    }
}
