using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using FluentNHibernate.Mapping;

namespace atomicf1.persistence.Mappings
{
    public class CircuitMap : ClassMap<Circuit>
    {
        public CircuitMap()
        {
            Id(x => x.Id, "CircuitId");
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Location).Length(50);
            Map(x => x.Country).Length(50);
            Map(x => x.Url).Length(255);           
            Map(x => x.ImageUri, "CircuitMapUri").Length(255);
        }
    }
}
