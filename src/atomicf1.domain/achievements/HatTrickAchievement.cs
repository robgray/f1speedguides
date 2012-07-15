using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class HatTrickAchievement : Achievement
    {
        public HatTrickAchievement() : base("Win a Hat Trick", "Win three consecutive races in the Atomic F1 championship in a single season", "HatTrick") { }
        
        protected override int Occurrences(Driver driver)
        {
            var raceWinsInRow = 0;
            var timesAchieved = 0;
            foreach (var race in GetAllRaces(driver))
            {
                if (race.GetRaceResult(race.GetRaceEntry(driver)).Position == 1)
                    raceWinsInRow++;
                else
                    raceWinsInRow = 0;

                if (raceWinsInRow == 3) {
                    timesAchieved += 1;
                    raceWinsInRow -= 1;  // four wins in a row awards this twice.
                }
            }
            return timesAchieved;
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            var raceWinsInRow = 0;
            var driver = entry.Entrant.Driver;
            foreach (var race in GetAllRaces(driver))
            {
                var entryTemp = race.GetRaceEntry(driver);
                var result = race.GetRaceResult(entryTemp);
                
                if (result != null && result.Position == 1)
                    raceWinsInRow++;
                else
                    raceWinsInRow = 0;

                if (raceWinsInRow == 3 && race.Id == entry.Race.Id)
                    return true;
            }
            return false;
        }
    }
}
