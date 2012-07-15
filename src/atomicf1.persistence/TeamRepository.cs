using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain.Repositories;
using atomicf1.domain;
using NHibernate;

namespace atomicf1.persistence
{
    public class TeamRepository : AbstractRepository<Team, int>, ITeamRepository
    {        
        
    }
}
