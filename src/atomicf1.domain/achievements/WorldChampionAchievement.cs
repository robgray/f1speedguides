using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public class WorldChampionAchievement : Achievement
    {
        public WorldChampionAchievement() : base("Win the World Championship", "Win the Atomic F1 championship", "Champion") { }

        protected override int Occurrences(Driver driver)
        {
            var seasons = driver.Contracts.Select(c => c.Season).Where(s => !s.IsCurrent);

            return seasons.Count(s => s.Champion.Id == driver.Id);
        }

        public override bool AchievedAt(RaceEntry entry)
        {
            // do not give this out during at a particular race.
            // can't be bothered doing the calculation to work out if it's mathematically possible etc.
            return false;
        }
    }
}
