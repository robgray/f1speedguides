using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    interface IPointsResults
    {
        decimal Points { get; }

        void CalculatePoints(PointsSystem pointsSystem);
    }
}
