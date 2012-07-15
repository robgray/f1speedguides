using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class PointsSystem1991 : PointsSystem
    {
        protected override bool ScoreDidNotFinish()
        {
            return false;
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
