using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class RaceResult : Result
    {
        protected RaceEntry _entry;
        
        public RaceResult(RaceEntry entry) : base(entry)
        {            
            Entrant = entry.Entrant;       
        }

        public virtual decimal RaceTime { get; set; }        

        public virtual bool HasFinished
        {
            get { return Completed; }
            set { Completed = value; }
        }

        protected override bool IsPositionNotAvailable
        {
            get { return Position == 0; }
        }

        public override decimal Points
        {
            get { return Entry.PointsSystem.CalculateRacePoints(Entry); }
        }        
    }

    public class NullRaceResult : RaceResult
    {
        public NullRaceResult(ICompetitor competitor, Season season)
            : base(new RaceEntry() { Entrant = new DriverContract() { Driver = new Driver(), Season = season, Team = new Team() }, Race = new Race() { Season = season } })
        {
            Completed = false;
            Position = 0;
        }
    }
}
