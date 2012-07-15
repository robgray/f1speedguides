using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using atomicf1.domain;

namespace atomicf1.persistence.Mappings
{
    public class DriverMap : ClassMap<Driver>
    {
        public DriverMap()
        {
            Id(x => x.Id, "DriverId");
            Map(x => x.Name).Length(40).Not.Nullable();
            Map(x => x.Nationality).Length(40);
            Map(x => x.ImageUri).Length(255);
            Map(x => x.Url).Length(255);
            Map(x => x.AtomicName).Length(50);
            Map(x => x.AtomicUserId);
            HasMany<DriverContract>(Reveal.Member<Driver>("_contracts")).KeyColumn("DriverId");
        }
    }
}
