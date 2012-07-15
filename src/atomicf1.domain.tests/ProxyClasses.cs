using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Tests
{
    public class TeamProxy : Team
    {
        public TeamProxy(IList<DriverContract> contracts)
        {
            _contracts = contracts;
            foreach (var contract in _contracts) {
                contract.Team = this;
            }
        }
    }
    
    public class RaceProxy : Race
    {
        public RaceProxy(IList<RaceEntry> entries)
        {
            _entries = entries;
            foreach (var entry in entries) {
                entry.Race = this;
            }
        }
    }
}
