using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public class DetailedDriverChampionshipTable
    {
        protected IDictionary<int, DetailedDriverChampionshipResult> _results = new Dictionary<int, DetailedDriverChampionshipResult>();
        protected Season _season;

        public DetailedDriverChampionshipTable(Season season)
        {
            _season = season;
        }

        public int Races { get { return _season.Races.Count();  } }

        public void AddResult(int raceNumber, RaceResult result)
        {
            if (!_results.ContainsKey(result.Entrant.Driver.Id))
            {
                _results.Add(result.Entrant.Driver.Id, new DetailedDriverChampionshipResult(result.Entrant.Driver, _season));
            }
            var championshipResult = _results[result.Entrant.Driver.Id];
            championshipResult.AddResult(raceNumber, result);
        }
      
        public IEnumerable<DetailedChampionshipResult> Results
        {
            get { return _results.Values.OrderByDescending(x => x.TotalPoints); }
        }        
    }
   
    public class DetailedTeamChampionshipTable
    {
        protected IDictionary<int, DetailedTeamChampionshipResult> _results = new Dictionary<int, DetailedTeamChampionshipResult>();
        protected Season _season;

        public DetailedTeamChampionshipTable(Season season)
        {
            _season = season;
        }

        public int Races { get { return _season.Races.Count();  } }
                
        public void AddResult(int raceNumber, TeamResult result)
        {
            if (!_results.ContainsKey(result.Team.Id))
            {
                _results.Add(result.Team.Id, new DetailedTeamChampionshipResult(result.Team, _season));
            }
            var championshipResult = _results[result.Team.Id];
            championshipResult.AddResult(raceNumber, result);
        }

        public IEnumerable<DetailedTeamChampionshipResult> Results
        {
            get { return _results.Values.OrderByDescending(x => x.TotalPoints); }
        }    
    }

    public class DetailedQualifyingTable
    {
        protected IDictionary<int, DetailedDriverChampionshipResult> _results = new Dictionary<int, DetailedDriverChampionshipResult>();
        protected Season _season;

        public DetailedQualifyingTable(Season season)
        {
            _season = season;
        }

        public int Races { get { return _season.Races.Count(); } }

        public void AddResult(int raceNumber, RaceResult result)
        {
            if (!_results.ContainsKey(result.Entrant.Driver.Id))
            {
                _results.Add(result.Entrant.Driver.Id, new DetailedDriverChampionshipResult(result.Entrant.Driver, _season));
            }
            var championshipResult = _results[result.Entrant.Driver.Id];
            championshipResult.AddResult(raceNumber, result);
        }

        public IEnumerable<DetailedChampionshipResult> Results
        {
            get { return _results.Values.OrderBy(x => x.AverageQualifyingPosition); }
        }
    }
}
