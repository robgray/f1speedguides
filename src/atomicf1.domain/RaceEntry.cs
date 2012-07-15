using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class RaceEntry : DomainObject<int>, IRaceResult
    {
        private IPointsSystem _pointsSystem;

        public RaceEntry() : this(null) { }
        
        public RaceEntry(IPointsSystem pointsSystem)
        {
            _pointsSystem = pointsSystem;            
        }

        public IPointsSystem PointsSystem 
        { 
            get
            {
                if (_pointsSystem == null && Race != null)
                {
                    _pointsSystem = Race.Season.PointsSystem;
                }
                return _pointsSystem;
            } 
        }

        public virtual int QualifyingPosition { get; set; }
        
        public virtual Race Race { get; set; }

        public virtual DriverContract Entrant { get; set; }

        public virtual decimal QualifyingTime { get; set; }

        public virtual decimal? QualifyingTime2 { get; set; }

        public virtual decimal? QualifyingTime3 { get; set; }
        
        public virtual int RacePlace { get; set; }

        public virtual string RaceTime { get; set; }

        public virtual decimal FastestLap { get; set; }


        public virtual bool HasFinished
        {
            get { return !DidNotFinish;  }
        }

        public virtual bool DidNotFinish { get; set; }

        public virtual bool DidNotStart { get; set; }

        public virtual decimal Points
        {
            get
            {
                return PointsSystem.CalculatePoints(this);
            }
        }

        public virtual bool IsDisqualified { get; set; }

        public virtual int GridPenalty { get; set; }

        public virtual bool DidNotQualify { get; set; }

        public virtual int? GridPosition { get; set;  }

        public QualifyingResult GetQualifyingResult()
        {
            return new QualifyingResult(this);
        }

        public GridResult GetGridResult()
        {
            return new GridResult(this);
        }

        public virtual int? RacerRatio
        {
            get
            {
                if (!HasFinished) return null;
                return QualifyingPosition - RacePlace;
            }
        }
    }
}
