using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using FluentNHibernate.Mapping;

namespace atomicf1.persistence.Mappings
{
    public class DriverContractMap : ClassMap<DriverContract>
    {
        public DriverContractMap()
        {
            Id(x => x.Id, "DriverContractId");
            Map(x => x.SignedDate, "DateCommenced");
            Map(x => x.IsReserve, "IsReserve");
            Map(x => x.TerminatedDate, "DateTerminated");
            References(x => x.Team, "TeamId");
            References(x => x.Driver, "DriverId");
            References(x => x.Season, "SeasonId");
        }
    }
}
