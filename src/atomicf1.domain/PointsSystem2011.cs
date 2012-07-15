using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class PointsSystem2011 : PointsSystem2010
    {
        protected override bool ScoreDidNotFinish()
        {
            return false;
        }

        protected override void BuildQualifyingPoints()
        {
            _qualifyingPoints = new Dictionary<int, decimal>();
        }
    }
}
