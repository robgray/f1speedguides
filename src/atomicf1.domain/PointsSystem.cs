using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public abstract class PointsSystem : IPointsSystem
    {
        protected IDictionary<int, decimal> _qualifyingPoints;
        protected IDictionary<int, decimal> _racePoints;
        
        /// <summary>
        ///  The number of results to count toward the points.
        /// </summary>
        protected int? TopResults { get; set; }

        protected int PointsForFastestLap { get; set; }

        protected PointsSystem()
        {
            BuildQualifyingPoints();
            BuildRacePoints();
        }

        protected virtual void BuildQualifyingPoints()
        {
            _qualifyingPoints = new Dictionary<int, decimal>();
        }

        protected virtual void BuildRacePoints() 
        {
            _racePoints = new Dictionary<int, decimal>();
        }

        public bool GivesPointsForQualifying { get { return _qualifyingPoints.Count > 0;  } }
        
        public decimal CalculatePoints(RaceEntry entry)
        {            
            return CalculateRacePoints(entry) + CalculateQualifyingPoints(entry);
        }        

        public decimal CalculateRacePoints(RaceEntry entry)
        {
            if (!ScoreDidNotFinish() && entry.DidNotFinish)
            {
                return 0;
            }

            if (!entry.DidNotStart && !entry.IsDisqualified && ((ScoreDidNotFinish() && entry.DidNotFinish) || !entry.DidNotFinish))
            {
                var racePosition = entry.RacePlace;
                if (_racePoints.ContainsKey(racePosition))
                {                    
                    return _racePoints[racePosition];
                }                    
            }

            return 0;
        }

        public decimal CalculateQualifyingPoints(RaceEntry entry)
        {
            if (!entry.DidNotQualify)
            {
                var qualifyingPosition = entry.QualifyingPosition;
                if (_qualifyingPoints.ContainsKey(qualifyingPosition) && !entry.DidNotQualify)
                    return _qualifyingPoints[qualifyingPosition];
            }
            return 0;
        }

        protected virtual bool ScoreDidNotFinish()
        {
            return false;
        }

        /// <summary>
        /// Takes a list of entries for and returns the total points for those entries.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public virtual decimal CalculateSeasonPoints(IEnumerable<RaceEntry> entries)
        {
            var raceEntryPoints = new List<decimal>();
            
            foreach (var entry in entries)
            {
                var points = 0M;
                points += CalculateQualifyingPoints(entry);
                points += CalculateRacePoints(entry);
                raceEntryPoints.Add(points);
            }
            
            return raceEntryPoints.OrderByDescending(d => d).Take(TopResults ?? entries.Count()).Sum();
        }        
    }
}
