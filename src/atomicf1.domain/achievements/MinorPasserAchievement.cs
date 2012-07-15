using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class MinorPasserAchievement : Achievement
    {
        public MinorPasserAchievement() : base("Minor Passer", "Finish 3 places higher than you started", "MinorPasser") { }

        protected override int Occurrences(Driver driver)
        {
            return ((from race in GetAllRaces(driver)
                     let entry = race.GetRaceEntry(driver)
                     where
                         entry != null &&
                         race.GetQualifyingResult(entry).Position - race.GetRaceResult(entry).Position >= 3
                     select race).Count());
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            var qualiPosition = entry.Race.GetQualifyingResult(entry).Position;
            var racePosition = entry.Race.GetRaceResult(entry).Position;

            return qualiPosition - racePosition >= 3;
        }
    }
}
