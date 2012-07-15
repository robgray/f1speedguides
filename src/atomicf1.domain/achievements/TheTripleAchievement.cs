using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class TheTripleAchievement : Achievement
    {
        public TheTripleAchievement() : base("Do the Triple", "Score pole, fastest lap, and race win in the same race", "TheTriple") { }

        protected override int Occurrences(Driver driver)
        {
            return
                GetAllRaces(driver).Count(
                    r =>
                    r.GotFastestLap(driver) && r.GetQualifyingResult(r.GetRaceEntry(driver)).Position == 1 &&
                    r.GetRaceResult(r.GetRaceEntry(driver)).Position == 1);
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            var qualiPosition = entry.Race.GetQualifyingResult(entry).Position;
            var racePosition = entry.Race.GetRaceResult(entry).Position;
            var fastestLap = entry.Race.GotFastestLap(entry.Entrant.Driver);

            return fastestLap && qualiPosition == 1 && racePosition == 1;                
        }
    }
}
