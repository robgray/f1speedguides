using System.Collections.Generic;

namespace atomicf1.domain
{
    public class PointsSystem90s : PointsSystem
    {

        protected override void BuildQualifyingPoints()
        {
            _qualifyingPoints = new Dictionary<int, decimal>();
        }

        protected override void BuildRacePoints()
        {
            _racePoints = new Dictionary<int, decimal>
                              {
                                  {1, 10M},
                                  {2, 6M},
                                  {3, 4M},
                                  {4, 3M},
                                  {5, 2M},
                                  {6, 1M}                                  
                              };
        }
    }
}
