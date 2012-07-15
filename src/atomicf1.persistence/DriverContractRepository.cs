using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using NHibernate.Criterion;

namespace atomicf1.persistence
{
    public class DriverContractRepository : AbstractRepository<DriverContract, int>, IDriverContractRepository
    {
        public IEnumerable<DriverContract> GetAllForDriver(Driver driver)
        {
            using (var session = GetSession())
            {
                var criteria = session.CreateCriteria<DriverContract>();
                criteria.Add(Restrictions.Eq("DriverId", driver.Id));
                var contracts = criteria.List<DriverContract>();
                return contracts;
            }
        }        
    }
}
