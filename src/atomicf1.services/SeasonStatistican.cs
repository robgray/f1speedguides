using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    /// <summary>
    /// Provides statistics for a season
    /// </summary>
    public class SeasonStatistician : StatisticianBase
    {
        private Season _season;

        public SeasonStatistician(Season season)
        {
            _season = season;
        }

        public virtual DataTable GetDetailedDriverChampionshipTable()
        {
            // Make data table
            var table = new DataTable("ChampionshipTable");

            table.Columns.Add("Driver", typeof(String));
            table.Columns.Add("Total Points", typeof(Int32));

            var dct = new DetailedDriverChampionshipTable(_season);

            var raceNumber = 1;
            foreach (var race in _season.Races)
            {
                var results = race.GetRaceResults();
                foreach (var result in results)
                {
                    var points = result.Entry.Points;
                    dct.AddResult(raceNumber, result);
                }
                raceNumber++;
            }

            for (var i = 1; i <= dct.Races; i++)
            {
                table.Columns.Add(string.Format("Rnd {0}", i), typeof(String));
            }

            foreach (var result in dct.Results)
            {
                var row = table.NewRow();
                row[0] = result.Competitor.Name;
                row["Total Points"] = result.TotalPoints;
                for (var race = 0; race < result.Results.Length; race++)
                {
                    row[race + 2] = result.Results[race].GetPositionString();
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public virtual DataTable GetDetailedTeamChampionshipTable()
        {
            // Make data table
            var table = new DataTable("ChampionshipTable");

            table.Columns.Add("Team", typeof(String));
            table.Columns.Add("Total Points", typeof(Int32));

            var dct = new DetailedTeamChampionshipTable(_season);

            var raceNumber = 1;
            foreach (var race in _season.Races)
            {
                var results = race.GetTeamResults();
                foreach (var result in results)
                {
                    var points = result.Points;
                    dct.AddResult(raceNumber, result);
                }
                raceNumber++;
            }

            for (var i = 1; i <= dct.Races; i++)
            {
                table.Columns.Add(string.Format("Rnd {0}", i), typeof(String));
            }

            foreach (var result in dct.Results)
            {
                var row = table.NewRow();
                row[0] = result.Competitor.Name;
                row["Total Points"] = result.TotalPoints;
                for (var race = 0; race < result.Results.Length; race++)
                {
                    row[race + 2] = result.Results[race].GetPositionString();
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public virtual DataTable GetDetailedQualifyingTable()
        {
            // Make data table
            var table = new DataTable("QualifyingTable");

            table.Columns.Add("Driver", typeof(String));
            var dct = new DetailedQualifyingTable(_season);

            var raceNumber = 1;
            foreach (var race in _season.Races)
            {
                var results = race.GetRaceResults();
                foreach (var result in results)
                {
                    var points = result.Entry.Points;
                    dct.AddResult(raceNumber, result);
                }
                raceNumber++;
            }

            for (var i = 1; i <= dct.Races; i++)
            {
                table.Columns.Add(string.Format("Rnd {0}", i), typeof(String));
            }

            foreach (var result in dct.Results)
            {
                var row = table.NewRow();
                row[0] = result.Competitor.Name;
                for (var race = 0; race < result.Results.Length; race++)
                {
                    row[race + 1] = result.Results[race].GetQualifyingPositionString(false);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public virtual IList<GenericResult> GetDriversTableRankedByAverageGridPlace()
        {
            return base.GetDriversTableRankedBy(r => r.GetQualificationResults(), new List<Season> { _season });
        }

        public virtual IList<GenericResult> GetDriversTableRankedByAverageRacePlace()
        {
            return base.GetDriversTableRankedBy(r => r.GetRaceResults(), new List<Season> { _season });
        }
        

        public virtual IList<QualifiyingStatistic> GetTopQualifiers(PlaceMetric metric)
        {
            IList<QualifiyingStatistic> drivers = new List<QualifiyingStatistic>();

            foreach (var race in _season.Races)
            {
                var qualiResults = race.GetQualificationResults();
                var poleResult = qualiResults.FirstOrDefault(x => x.Position == 1);

                foreach (var result in qualiResults)
                {
                    var driver = drivers.FirstOrDefault(x => x.Entrant.Driver.Id == result.Entrant.Driver.Id);
                    if (driver == null)
                    {
                        driver = new QualifiyingStatistic(result.Entrant);
                        drivers.Add(driver);
                    }
                    driver.RegisterResult(result.Position, result.LapTime, poleResult.LapTime);
                }
            }

            if (metric == PlaceMetric.Position)
                return drivers.OrderBy(x => x.AveragePosition).ToList();
            else
            {
                var sorted = drivers.OrderBy(x => x.AveragePercentBack).ToList();
                var fastest = sorted.Take(1).FirstOrDefault();
                if (fastest != null)
                {
                    foreach (var result in sorted.Skip(1))
                    {
                        result.SetAverageLapTime(fastest.AverageLapTime);
                    }
                }
                return sorted;
            }
        }

        public virtual IList<GenericResult> GetPointsTable()
        {
            return base.GetPointsTable(_season.Races);
        }

        public virtual IList<GenericResult> GetWinsTable()
        {            
            return base.GetWinsTable(_season.Races);
        }

        public virtual IList<GenericResult> GetPolesTable()
        {
            return base.GetPolesTable(_season.Races);
        }

        public virtual IList<GenericResult> GetFastestLapsTable()
        {
            return base.GetFastestLapsTable(_season.Races);
        }

        public virtual IList<GenericResult> GetPodiumsTable()
        {
            return base.GetPodiumsTable(_season.Races);
        }
    }
}
