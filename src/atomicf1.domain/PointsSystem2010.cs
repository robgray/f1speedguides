using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class PointsSystem2010 : PointsSystem
    {                
        protected override void BuildQualifyingPoints()
        {
            _qualifyingPoints = new Dictionary<int, decimal>()
                                    {
                                        {1, 5M},
                                        {2, 4M},
                                        {3, 3M},
                                        {4, 2M},
                                        {5, 1M}
                                    };
        }

        protected override void BuildRacePoints()
        {
            _racePoints = new Dictionary<int, decimal>
                              {
                                  {1, 25M},
                                  {2, 18M},
                                  {3, 15M},
                                  {4, 12M},
                                  {5, 10M},
                                  {6, 8M},
                                  {7, 6M},
                                  {8, 4M},
                                  {9, 2M},
                                  {10, 1M}
                              };
        }

        protected override bool ScoreDidNotFinish()
        {
            return true;
        }
    }
}
