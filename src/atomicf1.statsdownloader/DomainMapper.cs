using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.persistence;
using atomicf1.common;

namespace atomicf1.statsdownloader
{
    public static class DomainMapper
    {
        private static CircuitRepository circuitRepository;
        private static DriverContractRepository contractRepository;

        static DomainMapper()
        {
            circuitRepository = new CircuitRepository();
            contractRepository = new DriverContractRepository();
        }

        public static atomicf1.domain.Race MapDomainRace(this Race race, domain.Circuit circuit)
        {
            var f1Race = new domain.Race()
                             {
                                 StartDate = race.Date,
                                 EndDate = race.Date,
                                 PercentLength = 100,
                                 Name = race.Name,
                                 Circuit = circuit
                             };

            return f1Race;
        }

        public static void MapDomainRaceEntry(this RaceEntry entry, domain.RaceEntry f1Entry)
        {            
            
            f1Entry.RacePlace = entry.Position;
            
            f1Entry.DidNotStart = entry.PositionString == "DNS" || entry.PositionString == "DNQ";
            f1Entry.DidNotFinish = entry.PositionString == "Ret";
            f1Entry.FastestLap = entry.FastestLapTime.ConvertToDecimalLapTime() ?? 0;
            f1Entry.GridPosition = entry.Grid;
            f1Entry.RaceTime = entry.Time;

            f1Entry.DidNotQualify = entry.QualifyingPosition == "DNQ";
            f1Entry.QualifyingTime = entry.QualifyingTime1.ConvertToDecimalLapTime() ?? 0;
            f1Entry.QualifyingTime2 = entry.QualifyingTime2.ConvertToDecimalLapTime();
            f1Entry.QualifyingTime3 = entry.QualifyingTime3.ConvertToDecimalLapTime();

            int qualifyingPosition;
            if (int.TryParse(entry.QualifyingPosition, out qualifyingPosition))
                f1Entry.QualifyingPosition = qualifyingPosition;
            else
                f1Entry.QualifyingPosition = 0;
        }

        
    }
}
