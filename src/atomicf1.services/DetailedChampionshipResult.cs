using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public abstract class DetailedChampionshipResult
    {
        private Season _season;

        public DetailedChampionshipResult(ICompetitor competitor, Season season)
        {
            Competitor = competitor;
            Races = season.Races.Count();
            Results = new RaceResult[Races];
            for (var i = 0; i < Races; i++)
            {
                Results[i] = new NullRaceResult(competitor, season);
            }

        }

        public int Races { get; private set; }

        public ICompetitor Competitor { get; private set; }

        public RaceResult[] Results { get; private set; }

        public decimal TotalPoints 
        { 
            get
            {                
                return Results.Sum(x => x.Entry.Points);
            }
        }

        public double? AverageQualifyingPosition
        {
            get
            {
                return Results.Average(x => x.Entry.QualifyingPosition);
            }
        }

        public abstract void AddResult(int raceNumber, RaceResult result);        
    }

    public class DetailedDriverChampionshipResult : DetailedChampionshipResult
    {
        public DetailedDriverChampionshipResult(ICompetitor competitor, Season season) : base(competitor, season) { }

        public override void AddResult(int raceNumber, RaceResult result)
        {
            if (result.Entrant.Driver.Id != Competitor.Id) return;
            if (raceNumber > Results.Length) return;
            Results[raceNumber - 1] = result;
        }        
    }
    
    public class DetailedTeamChampionshipResult 
    {        
        private Season _season;

        public DetailedTeamChampionshipResult(ICompetitor competitor, Season season)
        {
            Competitor = competitor;
            Races = season.Races.Count();
            Results = new TeamResult[Races];
            for (var i = 0; i < Races; i++)
            {
                Results[i] = new NullTeamResult(competitor, season);
            }

        }

        public int Races { get; private set; }

        public ICompetitor Competitor { get; private set; }

        public TeamResult[] Results { get; private set; }

        public decimal TotalPoints 
        { 
            get
            {                
                return Results.Sum(x => x.Points);
            }
 
        }

        public void AddResult(int raceNumber, TeamResult result)
        {
            if (result.Team.Id != Competitor.Id) return;
            if (raceNumber > Results.Length) return;
            Results[raceNumber - 1] = result;
        }
    }


}
