using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class QualifyingResult : Result
    {
        public QualifyingResult(RaceEntry entry) : base(entry) { }
        
        public virtual Driver Driver
        {
            get
            {
                return Entry.Entrant.Driver;
            }
        }

        public override decimal Points
        {
            get { return Entry.PointsSystem.CalculateQualifyingPoints(Entry); }
        }

        public virtual decimal LapTime 
        { 
            get
            {
                if (Entry.QualifyingTime3.HasValue)
                    return Entry.QualifyingTime3.Value;

                return Entry.QualifyingTime2.HasValue ? Entry.QualifyingTime2.Value : Entry.QualifyingTime;
            }
        }

        public override int Position
        {
            get { return Entry.GridPosition ?? int.MaxValue; }            
        }

        public virtual bool HasQualified 
        {
            get { return !Entry.DidNotQualify; }            
        }

        protected override bool IsPositionNotAvailable
        {
            get { return Position == 0; }
        }

        public override string GetPositionString(bool numericOnly)
        {
            return base.GetQualifyingPositionString(numericOnly);
        }

        public override DriverContract Entrant
        {
            get { return base.Entry.Entrant; }            
        }
    }    

    public class GridResult : Result
    {
        public GridResult(RaceEntry entry) : base(entry) { }


        public override decimal Points
        {
            get { return 0; }
        }

        protected override bool IsPositionNotAvailable
        {
            get { return Entry.GridPosition == null; }
        }

        public override int Position
        {
            get { return Entry.GridPosition ?? int.MaxValue; }            
        }
    }
}
