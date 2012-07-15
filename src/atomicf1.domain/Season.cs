using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Season : LinkableObject<int>
    {
        private readonly IList<Race> _races;
        private readonly IList<DriverContract> _entrants;
        private IPointsSystem _pointsSystem;
        
        public Season()
        {
            _races = new List<Race>();
            _entrants = new List<DriverContract>();
        }

        public virtual string PointsSystemTypeName { get; set; }

        public virtual int Year { get; set; }

        public virtual string Description { get; set; }
        
        public virtual IEnumerable<ChampionshipResult> GetDriverStandings()
        { 
            var list = Entrants.Select(entry => new ChampionshipResult
                                                    {
                                                        Entrant = entry 
                                                    }).ToList();

            foreach (var entrant in list)
            {
                var driverEntries = _races.SelectMany(r => r.Entries.Where(e => e.Entrant.Driver.Id == entrant.Entrant.Driver.Id));
                entrant.Points = PointsSystem.CalculateSeasonPoints(driverEntries);
            }

            list = list.OrderByDescending(x => x.Points).OrderByDescending(y => y.TieBreaker).ToList();
            var pos = 0;
            list.ForEach(x => x.Position = ++pos);

            return list;
        }

        public virtual IEnumerable<ChampionshipResult> GetDriverStandings(TieBreaker tiebreaker)
        {
            var list = Entrants.Select(entry => new ChampionshipResult
            {
                Entrant = entry
            }).ToList();

            foreach (var entrant in list)
            {
                var driverEntries = _races.SelectMany(r => r.Entries.Where(e => e.Entrant.Driver.Id == entrant.Entrant.Driver.Id));
                entrant.Points = PointsSystem.CalculateSeasonPoints(driverEntries);
                entrant.TieBreaker = tiebreaker.Calculate(this, entrant.Entrant.Driver);
            }

            list = list.OrderByDescending(x => x.Points).OrderByDescending(y => y.TieBreaker).ToList();
            var pos = 0;
            list.ForEach(x => x.Position = ++pos);

            return list;
        }

        public virtual IEnumerable<ChampionshipResult> GetTeamStandings()
        {
            var list = new List<ChampionshipResult>();

            foreach (var ent in Entrants) {

                if (list.Count(x => x.Entrant.Team.Id == ent.Team.Id) == 0) {

                    list.Add(new ChampionshipResult()
                                 {
                                     Entrant = new DriverContract {Team = ent.Team},
                                     Points = 0
                                 });
                }
            }

            foreach (var race in _races)
            {
                foreach (var entry in race.Entries)
                {
                    var champResult = list.SingleOrDefault(x => x.Entrant.Team.Name == entry.Entrant.Team.Name);
                    if (champResult == null)
                    {
                        champResult = new ChampionshipResult
                        {
                            Entrant = new DriverContract() { Team = entry.Entrant.Team },
                            Points = 0
                        };
                        list.Add(champResult);
                    }
                    champResult.Points += entry.Points;
                }
            }

            list = list.OrderByDescending(x => x.Points).ToList();
            var pos = 0;
            list.ForEach(x => x.Position = ++pos);
            return list;
        }

        public virtual IEnumerable<Race> Races
        {
            get { return _races; }            
        }    
    
        public virtual void AddRace(Race race)
        {
            race.Season = this;
            _races.Add(race);
        }

        public virtual void RemoveRace(Race race)
        {
            if (_races.Contains(race)) {
                race.Season = null;
                _races.Remove(race);                
            }
        }

        public virtual DriverContract RegisterForCompetition(Driver driver, Team team)
        {
            var contract = new DriverContract
                               {
                                   Driver = driver,
                                   Team = team,
                                   Season = this,
                                   SignedDate = DateTime.Now
                               };

            _entrants.Add(contract);
            return contract;
        }

        public IEnumerable<DriverContract> Entrants
        {
            get { return _entrants; }
        }

        public virtual bool IsCurrent { get; set; }
    
        public DataTable GetChampionshipTable()
        {
            return new ChampionshipTableBuilder(this).Build();
        }

        public IPointsSystem PointsSystem
        {
            get
            {
                if (_pointsSystem == null)
                {
                    Type pointsSystem = Type.GetType(PointsSystemTypeName);
                    _pointsSystem = (IPointsSystem)Activator.CreateInstance(pointsSystem, true);
                }
                return _pointsSystem;
            }
        }

        public Team GetTeam(Driver driver)
        {
            var contract = Entrants.SingleOrDefault(e => e.Driver.Id == driver.Id);
            if (contract == null) return null;
            return contract.Team;
        }

        public Driver Champion
        {
            get { 
                var championStanding = GetDriverStandings().OrderBy(x => x.Position).FirstOrDefault();
                return championStanding != null ? championStanding.Entrant.Driver : null;
            }
        }
        
        public Calendar GetCalendar()
        {
            var calendar = new Calendar(this.Name);

            foreach (var race in Races)
            {
                calendar.AddEvent(race.StartDate, race.Circuit.ToString(), race.PercentLength);
            }

            return calendar;
        }
    }
}
