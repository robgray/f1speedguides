using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public enum PlaceMetric
    {
        Position,
        Time
    };

    public interface IStatistician
    {
        CircuitStatistics GetCircuitStatistics(Circuit circuit);

        IList<QualifiyingStatistic> GetTopQualifiersForCurrentSeason(PlaceMetric metric);        
        
        IList<Champion> GetChampions();

        Statistics GetDriverStatistics(Driver driver);

        Statistics GetTeamStatistics(Team team);

        IList<SuperGridEntry> GetSuperGrid(Circuit circuit);

        IList<SuperRaceEntry> GetSuperRace(Circuit circuit);

        IList<GenericResult> GetWinsTable();

        IList<GenericResult> GetRacerTable();

        IList<GenericResult> GetPolesTable();

        IList<GenericResult> GetPodiumsTable();

        IList<GenericResult> GetPointsTable();

        IList<GenericResult> GetFastestLapsTable();

        DataTable GetDetailedDriverChampionshipTable(Season season);

        DataTable GetDetailedTeamChampionshipTable(Season season);

        DataTable GetDetailedQualifyingTable(Season season);

        IList<GenericResult> GetDriversTableRankedByAverageRacePlace();

        IList<GenericResult> GetDriversTableRankedByAverageRacePlace(Season season);

        IList<GenericResult> GetDriversTableRankedByAverageGridPlace();        

        IList<GenericResult> GetDriversTableRankedByAverageGridPlace(Season season);

        IList<GenericResult> GetMostDriverWinsInASeason();
    }
}
