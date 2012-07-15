using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using atomicf1.domain;
using FluentNHibernate;

namespace atomicf1.persistence.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.Id, "TeamId");
            Map(x => x.Name);
            Map(x => x.Url).Length(255);
            HasMany<DriverContract>(Reveal.Member<Team>("_contracts")).KeyColumn("TeamId");
        }
    }
}
