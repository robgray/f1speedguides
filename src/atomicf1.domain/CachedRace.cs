using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;

namespace atomicf1.domain
{
    /// <summary>
    /// Provides caching of the CPU intensive task to calculate the race results.
    /// </summary>
    public class CachedRace : Race
    {
        public override IEnumerable<QualifyingResult> GetQualificationResults()
        {
            var key = string.Format("QUALIRES-{0}", Id);

            if (!CacheHelper.Contains(key))
            {
                CacheHelper.Insert(base.GetQualificationResults(), key);
            }

            return CacheHelper.Get<IEnumerable<QualifyingResult>>(key);
        }       

        public override IEnumerable<RaceResult> GetRaceResults()
        {
            var key = string.Format("RACERES-{0}", Id);

            if (!CacheHelper.Contains(key))
            {
                CacheHelper.Insert(base.GetRaceResults(), key);
            }

            return CacheHelper.Get<IEnumerable<RaceResult>>(key);
        }

        public override Driver FastestLapDriver
        {
            get
            {
                var key = string.Format("RACEFL-{0}", Id);
                
                if (!CacheHelper.Contains(key))
                {
                    CacheHelper.Insert(base.FastestLapDriver, key);
                }

                return CacheHelper.Get<Driver>(key);

            }
        }
    }
}
