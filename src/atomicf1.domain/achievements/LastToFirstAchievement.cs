using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class LastToFirstAchievement : Achievement
    {
        public LastToFirstAchievement() : base("Come from Behind", "Win a race from last place on the grid", "ComeFromBehind") { }
        
        protected override int Occurrences(Driver driver)
        {
            return (from race in GetAllRaces(driver)
                     let lowestQualifyingPosition = race.GetQualificationResults().Max(x => x.Position)
                     let entry = race.GetRaceEntry(driver)
                     where
                         race.GetQualifyingResult(entry).Position == lowestQualifyingPosition &&
                         race.GetRaceResult(entry).Position == 1
                     select race).Count();
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            var lowestQuali = entry.Race.GetQualificationResults().Max(x => x.Position);
            return entry.Race.GetQualifyingResult(entry).Position == lowestQuali &&
                entry.Race.GetRaceResult(entry).Position == 1;            
        }
    }
}
