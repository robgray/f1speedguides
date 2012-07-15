using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using atomicf1.domain;

namespace atomicf1.persistence.Mappings
{
    public class SeasonMap : ClassMap<Season>
    {
        public SeasonMap()
        {
            Id(x => x.Id).Column("SeasonId");            
            Map(x => x.Year);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.Url).Length(255);
            Map(x => x.IsCurrent);
            Map(x => x.PointsSystemTypeName).Column("PointsSystemType");
            HasMany(x => x.Races).KeyColumn("SeasonId")
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.Entrants).KeyColumn("SeasonId")
                .Cascade.AllDeleteOrphan();
        }
    }
}
