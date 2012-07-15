using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public interface IPointsSystem
    {
        bool GivesPointsForQualifying { get; }

        decimal CalculatePoints(RaceEntry entry);
        decimal CalculateQualifyingPoints(RaceEntry entry);
        decimal CalculateRacePoints(RaceEntry entry);
        decimal CalculateSeasonPoints(IEnumerable<RaceEntry> entries);
    }
}
