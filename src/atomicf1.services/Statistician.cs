using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.common;
using atomicf1.persistence;

namespace atomicf1.services
{
    public class Statistician : StatisticianBase, IStatistician
    {
        private readonly IRaceRepository _raceRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IDriverContractRepository _contractRepository;
        
        public Statistician() : this(new RaceRepository(), new SeasonRepository(), new DriverRepository(), new DriverContractRepository()) { }

        public Statistician(IRaceRepository raceRepository, ISeasonRepository seasonRepository, IDriverRepository driverRepository, IDriverContractRepository contractRepository)
        {
            _raceRepository = raceRepository;
            _seasonRepository = seasonRepository;
            _driverRepository = driverRepository;
            _contractRepository = contractRepository;
        }

        public virtual CircuitStatistics GetCircuitStatistics(Circuit circuit)
        {
            var races = _raceRepository.GetRacesAllAtCircuit(circuit);

            var lastRace = races.OrderBy(x => x.StartDate).LastOrDefault(x => x.Entries.Count() > 0);
            var previousWinner = new DriverContract { Driver = new Driver() { AtomicName = "* None *", Name = "* None *" } };
            if (lastRace != null) {
                var previousWinningResult = lastRace.GetRaceResults().FirstOrDefault(x => x.Position == 1);
                if (previousWinningResult != null) {
                    previousWinner = previousWinningResult.Entrant;
                } 
            }
                            
            // Qualifying Record 
            var record = decimal.MaxValue;
            var qualifyingRecordHolder = new DriverContract { Driver = new Driver() { AtomicName = "* None *", Name = "* None *" } };
            foreach (var race in races) {
                var polePosition = race.GetQualificationResults().Where(x => x.LapTime > 0).OrderBy(x => x.LapTime).FirstOrDefault();
                if (polePosition != null) {
                    if (polePosition.LapTime < record) {
                        record = polePosition.LapTime;
                        qualifyingRecordHolder = polePosition.Entrant;
                    }
                }
            }

            return new CircuitStatistics(circuit, previousWinner, record, qualifyingRecordHolder);
        }

        public virtual IList<QualifiyingStatistic> GetTopQualifiersForCurrentSeason(PlaceMetric metric)
        {
            return new SeasonStatistician(_seasonRepository.GetCurrent()).GetTopQualifiers(metric);
        }

        public virtual IList<Champion> GetChampions()
        {
         
            var seasons = _seasonRepository.GetAll().Where(x => !x.IsCurrent);

            var champions = (from season in seasons
                             let driver = season.GetDriverStandings().OrderBy(x => x.Position).FirstOrDefault()
                             where season.Races.Count() > 0            
                            select new Champion(driver.Entrant, season.Name)).ToList();

            return champions;
        }

        public virtual Statistics GetDriverStatistics(Driver driver)
        {
            var stats = new Statistics();
            var racerRatio = 0.0;
    
            foreach (var season in driver.Contracts.Select(c => c.Season))
            {
                if (!season.Entrants.Any(x => x.Driver.Id == driver.Id))
                    continue; 

                bool hasCountedSeason = false;
                var average = stats.NewSeasonAverageStatistic(season.Name);
                foreach (var race in season.Races)
                {
                    var entry = race.Entries.FirstOrDefault(re => re.Entrant.Driver.Id == driver.Id);
                    if (entry != null)
                    {
                        if (entry.RacerRatio != null)
                            racerRatio += entry.RacerRatio.Value;

                        stats.Entered += 1;
                        if (season.Year >= 4) stats.FastestLapsEntered += 1;
                        stats.Poles += entry.QualifyingPosition == 1 ? 1 : 0;
                        stats.Wins += entry.RacePlace == 1 ? 1 : 0;
                        stats.Podiums += entry.RacePlace <= 3 ? 1 : 0;
                        stats.Finished += entry.DidNotFinish ? 0 : 1;
                        stats.Points += (int) entry.Points;
                        stats.FastestLaps += race.GotFastestLap(driver) ? 1 : 0;

                        if (!entry.DidNotQualify)
                            average.AddQualifyingResult(entry.QualifyingPosition);

                        if (entry.HasFinished)
                            average.AddRaceResult(entry.RacePlace);

                        if (!hasCountedSeason)
                        {
                            stats.Seasons += 1;
                            hasCountedSeason = true;
                        }
                    }

                    var seasonResult =
                        season.GetDriverStandings().FirstOrDefault(e => e.Entrant.Driver.Id == driver.Id);

                    if (seasonResult != null)
                    {
                        if (seasonResult.Position < stats.BestChampionshipResult)
                            stats.BestChampionshipResult = seasonResult.Position;
                    }
                }
            }

            stats.RacerRatio = racerRatio / stats.Entered;

            return stats;
        }

        public virtual Statistics GetTeamStatistics(Team team)
        {
            
            var stats = new Statistics();

                var seasons = _seasonRepository.GetAll();
                foreach (var season in seasons)
                {
                    var hasCountedSeason = false;
                    var average = stats.NewSeasonAverageStatistic(season.Name);
                    foreach (var race in season.Races)
                    {
                        var entries = race.Entries.Where(re => re.Entrant.Team.Id == team.Id);
                        foreach (var entry in entries)
                            if (entry != null)
                            {
                                stats.Entered += 1;
                                stats.Poles += entry.QualifyingPosition == 1 ? 1 : 0;
                                stats.Wins += entry.RacePlace == 1 ? 1 : 0;
                                stats.Podiums += entry.RacePlace <= 3 ? 1 : 0;
                                stats.Finished += entry.DidNotFinish ? 0 : 1;
                                stats.Points += (int) entry.Points;

                                if (!entry.DidNotQualify)
                                    average.AddQualifyingResult(entry.QualifyingPosition);

                                if (entry.HasFinished)
                                    average.AddRaceResult(entry.RacePlace);

                                if (!hasCountedSeason)
                                {
                                    stats.Seasons += 1;
                                    hasCountedSeason = true;
                                }
                            }

                        var seasonResult = season.GetTeamStandings().SingleOrDefault(e => e.Entrant.Team.Id == team.Id);

                        if (seasonResult != null)
                        {
                            if (seasonResult.Position < stats.BestChampionshipResult)
                                stats.BestChampionshipResult = seasonResult.Position;
                        }
                    }
                }

            return stats;
        }

        /// <summary>
        /// Gets a Qualifying Grid of the average qualifying laps, ordered by fastest time.
        /// </summary>
        /// <param name="circuit"></param>
        public virtual IList<SuperGridEntry> GetSuperGrid(Circuit circuit)
        {            
            var gridDict = new Dictionary<int, SuperGridEntry>();            

            var races = _raceRepository.GetRacesAllAtCircuit(circuit);
            
            foreach (var race in races)            
            {
                var poleRecordResult = races.SelectMany(r => r.GetQualificationResults()).Where(r => r.LapTime > 0).OrderBy(r => r.LapTime).Take(1).First();

                var qualifyingResults = race.GetQualificationResults();
                if (qualifyingResults.Count() > 0)
                {
                    var poleResult = qualifyingResults.First(x => x.Position == 1);
                    foreach (var result in qualifyingResults)
                    {
                        if (result.HasQualified)
                        {
                            // get super grid entry
                            if (!gridDict.ContainsKey(result.Driver.Id))
                            {
                                gridDict.Add(result.Driver.Id, new SuperGridEntry {Driver = result.Driver});

                            }
                            var superGrid = gridDict[result.Driver.Id];

                            superGrid.AddLapTime(poleRecordResult.LapTime, result.LapTime, result.LapTime / poleResult.LapTime);
                        }
                    }
                }
            }

            return gridDict.Values.OrderBy(g => g.Rank).ToList();
        }

        public virtual IList<SuperRaceEntry> GetSuperRace(Circuit circuit)
        {
            var raceDict = new Dictionary<int, SuperRaceEntry>();

            var races = _raceRepository.GetRacesAllAtCircuit(circuit);
            foreach (var race in races)
            {
                var raceResults = race.GetRaceResults();
                foreach (var result in raceResults)
                {
                    if (result.Position > 0)
                    {
                        if (!raceDict.ContainsKey(result.Entrant.Driver.Id))
                        {
                            raceDict.Add(result.Entrant.Driver.Id, new SuperRaceEntry { Driver = result.Entrant.Driver });
                        }

                        var superRace = raceDict[result.Entrant.Driver.Id];
                        superRace.AddRacePosition(result.Position);
                    }
                }
            }

            return raceDict.Values.OrderBy(r => r.Position).ToList();
        }

        public virtual IList<GenericResult> GetWinsTable()
        {
            var races = _raceRepository.GetAll();
            return base.GetWinsTable(races);
        }

        public virtual IList<GenericResult> GetPolesTable()
        {
            var races = _raceRepository.GetAll();
            return base.GetPolesTable(races);
        }

        public virtual IList<GenericResult> GetFastestLapsTable()
        {
            var races = _raceRepository.GetAll();
            return base.GetFastestLapsTable(races);
        }

        public virtual IList<GenericResult> GetPodiumsTable()
        {
            var races = _raceRepository.GetAll();
            return base.GetPodiumsTable(races);
        }

        public virtual IList<GenericResult> GetRacerTable()
        {
            var stats = new List<DriverStat>();
            var drivers = _driverRepository.GetAll();
            
            foreach(var driver in drivers)
            {
                var stat = GetDriverStatistics(driver);
                if (stat.Entered > 5)
                    stats.Add(new DriverStat(driver, stat));            
            }

            stats = stats.OrderByDescending(s => s.Statistic.RacerRatio).ToList();
            
            var results = new List<GenericResult>();
            var position = 1;
            foreach (var stat in stats)
            {
                var result = new GenericResult {                            
                            Position = position++,
                            Name = stat.Name,
                            Result = stat.Statistic.RacerRatio.ToString("0.00")
                };
                results.Add(result);                
            }

            return results;
        }

        private class DriverStat 
        {
            public DriverStat(Driver driver, Statistics stat)
            {
                Name = driver.Name;
                Statistic = stat;
            }

            public string Name { get; private set;}
            public Statistics Statistic { get; private set; }
        }

        public virtual IList<GenericResult> GetPointsTable()
        {
            var races = _raceRepository.GetAll();
            return base.GetPointsTable(races);
        }

        public virtual DataTable GetDetailedDriverChampionshipTable(Season season)
        {
            return new SeasonStatistician(season).GetDetailedDriverChampionshipTable();
        }

        public virtual DataTable GetDetailedTeamChampionshipTable(Season season)
        {
            return new SeasonStatistician(season).GetDetailedTeamChampionshipTable();
        }

        public virtual DataTable GetDetailedQualifyingTable(Season season)
        {
            return new SeasonStatistician(season).GetDetailedQualifyingTable();
        }
        
        public virtual IList<GenericResult> GetDriversTableRankedByAverageRacePlace()
        {
            var seasons = _seasonRepository.GetAll();
            return base.GetDriversTableRankedBy(race => race.GetRaceResults(), seasons);
        }

        public virtual  IList<GenericResult> GetDriversTableRankedByAverageRacePlace(Season season)
        {
            return new SeasonStatistician(season).GetDriversTableRankedByAverageRacePlace();
        }

        public virtual IList<GenericResult> GetDriversTableRankedByAverageGridPlace()
        {
            var seasons = _seasonRepository.GetAll();
            return base.GetDriversTableRankedBy(race => race.GetRaceResults(), seasons);
        }

        public virtual IList<GenericResult> GetDriversTableRankedByAverageGridPlace(Season season)
        {
            return new SeasonStatistician(season).GetDriversTableRankedByAverageGridPlace();
        }

        public virtual IList<GenericResult> GetMostDriverWinsInASeason()
        {
            return null;
        }

        
    }   
}
