using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public abstract class StatisticianBase
    {
        protected virtual IList<GenericResult> GetWinsTable(IEnumerable<Race> races)
        {            
            var resultDict = new Dictionary<int, GenericResult>();

            foreach (var race in races)
            {
                var winner = race.GetRaceResults().FirstOrDefault(e => e.Position == 1);
                if (winner != null)
                {
                    if (!resultDict.ContainsKey(winner.Entrant.Driver.Id))
                    {
                        resultDict.Add(winner.Entrant.Driver.Id,
                                       new GenericResult { KeyId = winner.Entrant.Driver.Id, Name = winner.Entrant.Driver.Name, Result = "0" });
                    }
                    var result = resultDict[winner.Entrant.Driver.Id];
                    result.Position += 1;
                    result.Result = result.Position.ToString();
                }
            }

            return resultDict.Values.OrderByDescending(g => g.Position).ToList();
        }

        protected virtual IList<GenericResult> GetPolesTable(IEnumerable<Race> races)
        {
            var resultDict = new Dictionary<int, GenericResult>();

            foreach (var race in races)
            {

                var winner = race.GetQualificationResults().FirstOrDefault(e => e.Position == 1);
                if (winner != null)
                {
                    if (!resultDict.ContainsKey(winner.Entrant.Driver.Id))
                    {
                        resultDict.Add(winner.Entrant.Driver.Id,
                                       new GenericResult { KeyId = winner.Entrant.Driver.Id, Name = winner.Entrant.Driver.Name, Result = "0" });
                    }
                    var result = resultDict[winner.Entrant.Driver.Id];
                    result.Position += 1;
                    result.Result = result.Position.ToString();
                }
            }

            return resultDict.Values.OrderByDescending(g => g.Position).ToList();
        }

        protected virtual IList<GenericResult> GetFastestLapsTable(IEnumerable<Race> races)
        {
            var resultDict = new Dictionary<int, GenericResult>();

            foreach (var race in races)
            {

                var fastestLap = race.FastestLapDriver;
                if (fastestLap != null)
                {
                    if (!resultDict.ContainsKey(fastestLap.Id))
                    {
                        resultDict.Add(fastestLap.Id,
                                       new GenericResult { KeyId = fastestLap.Id, Name = fastestLap.Name, Result = "0" });
                    }
                    var result = resultDict[fastestLap.Id];
                    result.Position += 1;
                    result.Result = result.Position.ToString();
                }
            }

            return resultDict.Values.OrderByDescending(g => g.Position).ToList();
        }

        protected virtual IList<GenericResult> GetPodiumsTable(IEnumerable<Race> races)
        {   
            var resultDict = new Dictionary<int, GenericResult>();

            foreach (var race in races)
            {
                var positions = race.GetRaceResults();
                if (positions != null)
                {
                    foreach (var position in positions)
                    {
                        if (position.Position > 3) continue;
                        if (!resultDict.ContainsKey(position.Entrant.Driver.Id))
                        {
                            resultDict.Add(position.Entrant.Driver.Id,
                                           new GenericResult { KeyId = position.Entrant.Driver.Id, Name = position.Entrant.Driver.Name, Result = "0" });
                        }
                        var result = resultDict[position.Entrant.Driver.Id];
                        result.Position += 1;
                        result.Result = result.Position.ToString();
                    }
                }
            }

            return resultDict.Values.OrderByDescending(g => g.Position).ToList();
        }

        protected virtual IList<GenericResult> GetPointsTable(IEnumerable<Race> races)
        {            
            var resultDict = new Dictionary<int, GenericResult>();

            foreach (var race in races)
            {
                if (race.Entries != null)
                {
                    foreach (var entry in race.Entries)
                    {
                        if (!resultDict.ContainsKey(entry.Entrant.Driver.Id))
                        {
                            resultDict.Add(entry.Entrant.Driver.Id,
                                           new GenericResult { KeyId = entry.Entrant.Driver.Id, Name = entry.Entrant.Driver.Name, Result = "0" });
                        }
                        var result = resultDict[entry.Entrant.Driver.Id];
                        result.Position += (int)entry.Points;
                        result.Result = result.Position.ToString();
                    }
                }
            }

            return resultDict.Values.OrderByDescending(g => g.Position).ToList();
        }

        protected IList<GenericResult> GetDriversTableRankedBy(Func<Race, IEnumerable<Result>> filter, IEnumerable<Season> seasons)
        {
            if (seasons.Count() == 0)
                return new List<GenericResult>();
           
            IDictionary<int, IAverager<Driver, int>> driverResults = new Dictionary<int, IAverager<Driver, int>>();

            foreach (var result in                
                from s in seasons
                where s != null
                from race in s.Races 
                from result in filter(race) select result)
            {
                if (!driverResults.ContainsKey(result.Entrant.Driver.Id))
                {
                    driverResults.Add(result.Entrant.Driver.Id, new IntAverager<Driver>(result.Entrant.Driver));
                }
                driverResults[result.Entrant.Driver.Id].Add(result.Position);
            }

            var averages = driverResults.Values;
            var orderedAverages = averages.OrderBy(x => x.Average);

            var position = 1;
            return orderedAverages.Select(item => new GenericResult() { KeyId = item.Entity.Id, Name = item.Entity.Name, Position = position++, Result = item.Average.ToString("0.00") }).ToList();
        }

    }
}
