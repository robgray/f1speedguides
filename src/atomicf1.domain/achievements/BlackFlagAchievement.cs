using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class BlackFlagAchievement : Achievement
    {
        public BlackFlagAchievement() : base("Receive a Black Flag", "Get disqualified from an Atomic F1 champsionship race", "Anti BlackFlag") { }

        public override bool HasEarntAchievement(Driver driver)
        {
            var results = GetAllRaces(driver).SelectMany(r => r.GetRaceResults());

            Occurences = results.Count(res => res.Disqualified && res.Entrant.Driver.Id == driver.Id);
            return results.Any(res => res.Disqualified && res.Entrant.Driver.Id == driver.Id);
        }

        public override bool HasEarntAchievementAt(RaceEntry raceEntry)
        {
            return raceEntry.IsDisqualified;
        }              
    }
}
