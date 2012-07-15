using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class MajorPasserAchievement : Achievement
    {
        public MajorPasserAchievement() : base("Major Passer", "Finish 5 places higher than you started", "MajorPasser") { }

        protected override int Occurrences(Driver driver)
        {
            return (from race in GetAllRaces(driver)
                    let entry = race.GetRaceEntry(driver)
                    where
                        entry != null &&
                        race.GetQualifyingResult(entry).Position - race.GetRaceResult(entry).Position >= 5
                    select race).Count();            
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            var qualiPosition = entry.Race.GetQualifyingResult(entry).Position;
            var racePosition = entry.Race.GetRaceResult(entry).Position;

            return qualiPosition - racePosition >= 5;
        }
    } 
}
