using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using atomicf1.domain;

namespace atomicf1.persistence.Mappings
{
    public class RaceMap : ClassMap<Race>
    {
        public RaceMap()
        {
            Id(x => x.Id).Column("RaceId");
            Map(x => x.StartDate, "RaceDate");
            Map(x => x.PercentLength);
            Map(x => x.Url).Length(255);
            References(x => x.Circuit, "CircuitId").Not.Nullable().Cascade.None();
            References(x => x.Season, "SeasonId");

            HasMany(x => x.Entries).KeyColumn("RaceId").Cascade.AllDeleteOrphan();
        }
    }
}
