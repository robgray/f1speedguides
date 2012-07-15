using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using atomicf1.common;
using atomicf1.domain;

namespace atomicf1.services
{
    public class CachedStatistician : Statistician
    {
        public override IList<Champion> GetChampions()
        {
            const string key = "Champions";
            return CacheHelper.Get<IList<Champion>>(key, base.GetChampions());
        }

        public override CircuitStatistics GetCircuitStatistics(Circuit circuit)
        {
            var key = string.Format("CircuitStats-{0}", circuit.Id);            
            return CacheHelper.Get<CircuitStatistics>(key, base.GetCircuitStatistics(circuit));
        }

        public override DataTable GetDetailedDriverChampionshipTable(Season season)
        {
            var key = string.Format("DetailedChampTable-{0}", season == null ? 0 : season.Id);
            return CacheHelper.Get<DataTable>(key, base.GetDetailedDriverChampionshipTable(season));
        }

        public override DataTable GetDetailedTeamChampionshipTable(Season season)
        {
            var key = string.Format("DetailedChampTeamTable-{0}", season == null ? 0 : season.Id);
            return CacheHelper.Get<DataTable>(key, base.GetDetailedTeamChampionshipTable(season));
        }

        public override DataTable GetDetailedQualifyingTable(Season season)
        {
            var key = string.Format("DetailedQualiTable-{0}", season == null ? 0 : season.Id);
            return CacheHelper.Get<DataTable>(key, base.GetDetailedQualifyingTable(season));
        }

        public override IList<GenericResult> GetDriversTableRankedByAverageGridPlace()
        {
            const string key = "DriversByAverageGridPlace";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetDriversTableRankedByAverageGridPlace());
        }

        public override IList<GenericResult> GetFastestLapsTable()
        {
            const string key = "FastestLapsTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetFastestLapsTable());
        }

        public override IList<GenericResult> GetDriversTableRankedByAverageGridPlace(Season season)
        {
            var key = string.Format("DriversRankedAverageGridPlace-{0}", season == null ? 0 : season.Id);
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetDriversTableRankedByAverageGridPlace(season));
        }

        public override IList<GenericResult> GetDriversTableRankedByAverageRacePlace()
        {
            const string key = "DriversRankedAverageRacePlace";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetDriversTableRankedByAverageRacePlace());
        }

        public override Statistics GetDriverStatistics(Driver driver)
        {
            var key = string.Format("DriverStats-{0}", driver.Id);
            return CacheHelper.Get<Statistics>(key, base.GetDriverStatistics(driver));
        }

        public override IList<GenericResult> GetDriversTableRankedByAverageRacePlace(Season season)
        {
            var key = string.Format("DriversRankedAverageRacePlace-{0}", season == null ? 0 : season.Id );
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetDriversTableRankedByAverageRacePlace(season));
        }

        public override IList<GenericResult> GetPodiumsTable()
        {
            const string key = "PodiumsTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetPodiumsTable());
        }

        public override IList<GenericResult> GetPointsTable()
        {
            const string key = "PointsTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetPointsTable());
        }

        public override IList<GenericResult> GetPolesTable()
        {
            const string key = "PolesTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetPolesTable());
        }

        public override IList<GenericResult> GetRacerTable()
        {
            const string key = "RacerTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetRacerTable());
        }

        public override IList<SuperGridEntry> GetSuperGrid(Circuit circuit)
        {
            var key = string.Format("Supergrid-{0}", circuit.Id);
            return CacheHelper.Get<IList<SuperGridEntry>>(key, base.GetSuperGrid(circuit));
        }

        public override Statistics GetTeamStatistics(Team team)
        {
            var key = string.Format("TeamStats-{0}", team.Id);
            return CacheHelper.Get<Statistics>(key, base.GetTeamStatistics(team));
        }

        public override IList<GenericResult> GetWinsTable()
        {
            const string key = "WinsTable";
            return CacheHelper.Get<IList<GenericResult>>(key,base.GetWinsTable());
        }

        public override IList<QualifiyingStatistic> GetTopQualifiersForCurrentSeason(PlaceMetric metric)
        {
            const string key = "TopSeasonQualifiers";
            return CacheHelper.Get<IList<QualifiyingStatistic>>(key, base.GetTopQualifiersForCurrentSeason(metric));
        }

        public override IList<GenericResult> GetMostDriverWinsInASeason()
        {
            const string key = "MostWinsInASeasonTable";
            return CacheHelper.Get<IList<GenericResult>>(key, base.GetMostDriverWinsInASeason());
        }

    }
}
