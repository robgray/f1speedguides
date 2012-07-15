using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;

namespace atomicf1.domain
{
    public class Race : LinkableObject<int>
    {
        protected IList<RaceEntry> _entries;

        public Race()
        {
            _entries = new List<RaceEntry>();
        }

        public override string Name
        {
            get
            {
                return string.Format("{0}, {1} - {2}", this.Circuit.Name, this.Circuit.Country, this.Season.Name);
            }
            set
            {
                base.Name = value;
            }
        }

        public virtual Circuit Circuit { get; set; }

        public virtual Season Season { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual int PercentLength { get; set; }

        public virtual IEnumerable<RaceEntry> Entries
        {
            get { return _entries; }
        }

        public virtual RaceEntry Enter(DriverContract entry) 
        {            
            var raceEntry = new RaceEntry(Season.PointsSystem);
            raceEntry.Entrant = entry;
            raceEntry.Race = this;

            _entries.Add(raceEntry);

            return raceEntry;
        }
        
        public virtual void Withdraw(RaceEntry entry)
        {
            entry.Race = null;
            _entries.Remove(entry);
        }

        public virtual RaceResult GetRaceResult(RaceEntry entry)
        {
            var results = GetRaceResults();
            return results.SingleOrDefault(result => result.Entrant.Id == entry.Entrant.Id);
        }

        public virtual QualifyingResult GetQualifyingResult(RaceEntry entry)
        {
            var results = GetQualificationResults();
            return results.SingleOrDefault(result => result.Entrant.Id == entry.Entrant.Id);
        }

        private IEnumerable<TeamResult> CalculateTeamResult()
        {            
            IDictionary<int, TeamResult> results = new Dictionary<int, TeamResult>();            
            
            foreach (var entry in _entries)
            {
                if (entry.Entrant.Team.Id == 0) continue;                
                if (!results.ContainsKey(entry.Entrant.Team.Id))
                {
                    results.Add(entry.Entrant.Team.Id, new TeamResult
                                                    {
                                                        Team = entry.Entrant.Team,
                                                        Points = 0
                                                    });                    
                }
                var teamResult = results[entry.Entrant.Team.Id];
                teamResult.Points += entry.Points;
            }


            var list = results.Values.ToList();
            list = list.OrderByDescending(x => x.Points).ToList();

            var pos = 0;
            list.ForEach(x => x.Position = ++pos);

            return list;
        }

        private IEnumerable<RaceResult> CalculateRaceResults()
        {            
            var results = from entry in _entries
                          orderby entry.RacePlace                          
                          select new RaceResult(entry)
                                     {                                         
                                         RaceTime = entry.RacePlace,
                                         HasFinished = !entry.DidNotFinish
                                     };
                        
            return results;
        }

        public virtual RaceEntry GetRaceEntry(Driver driver)
        {
            return Entries.FirstOrDefault(e => e.Entrant.Driver.Id == driver.Id);
        }
                
        private IEnumerable<QualifyingResult> CalculateQualificationResults()
        {
            var qualiResults = new List<QualifyingResult>();
            Entries.ToList().ForEach(e => qualiResults.Add(e.GetQualifyingResult()));
            
            return qualiResults.OrderBy(e => e.Position);
        }

        public IEnumerable<Result> GetStartingGrid()
        {
            var startingGrid = new List<Result>();
            Entries.ToList().ForEach(e => startingGrid.Add(e.GetGridResult()));

            return startingGrid.OrderBy(e => e.Position);
        }

        public virtual bool GotFastestLap(Driver driver)
        {
            if (FastestLapDriver == null) return false;
            return FastestLapDriver.Id == driver.Id;
        }        
      

        public virtual IEnumerable<QualifyingResult> GetQualificationResults()
        {
            var key = string.Format("QUALIRES-{0}", Id);

            if (!CacheHelper.Contains(key))
            {
                CacheHelper.Insert(CalculateQualificationResults(), key);
            }

            return CacheHelper.Get<IEnumerable<QualifyingResult>>(key);
        }

        public virtual IEnumerable<RaceResult> GetRaceResults()
        {
            var key = string.Format("RACERES-{0}", Id);

            if (!CacheHelper.Contains(key))
            {
                CacheHelper.Insert(CalculateRaceResults(), key);
            }

            return CacheHelper.Get<IEnumerable<RaceResult>>(key);
        }

        public virtual IEnumerable<TeamResult> GetTeamResults()
        {
            var key = string.Format("RACETEAMRES-{0}", Id);

            if (!CacheHelper.Contains(key))
            {
                CacheHelper.Insert(CalculateTeamResult(), key);
            }

            return CacheHelper.Get<IEnumerable<TeamResult>>(key);
        }

        public virtual Driver FastestLapDriver
        {
            get
            {
                var key = string.Format("RACEFL-{0}", Id);

                if (!CacheHelper.Contains(key))
                {
                    CacheHelper.Insert(CalculateFasterLapDriver(), key);
                }

                return CacheHelper.Get<Driver>(key);

            }
        }

        private Driver CalculateFasterLapDriver()
        {
            var fastestEntry = Entries.Where(e => e.FastestLap > 0).OrderBy(e => e.FastestLap).FirstOrDefault();
            if (fastestEntry != null)
                return fastestEntry.Entrant.Driver;
            return null;
        }

    }
}
