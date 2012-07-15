using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using FluentNHibernate.Mapping;

namespace atomicf1.persistence.Mappings
{
    public class RaceEntryMap : ClassMap<RaceEntry>
    {
        public RaceEntryMap()
        {
            Table("RaceEntry");
            Id(x => x.Id, "RaceEntryId");
            Map(x => x.QualifyingTime);
            Map(x => x.QualifyingTime2);
            Map(x => x.QualifyingTime3);
            Map(x => x.RaceTime);
            Map(x => x.RacePlace);
            Map(x => x.DidNotFinish);
            Map(x => x.DidNotStart);
            Map(x => x.DidNotQualify);
            Map(x => x.FastestLap);
            Map(x => x.IsDisqualified, "Disqualified");
            Map(x => x.QualifyingPosition);
            Map(x => x.GridPosition);
            Map(x => x.GridPenalty);
            
            References(x => x.Race, "RaceId");
            References(x => x.Entrant, "DriverContractId");
        }
    }
}
