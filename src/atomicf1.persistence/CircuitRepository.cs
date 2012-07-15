using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using NHibernate.Criterion;

namespace atomicf1.persistence
{
    public class CircuitRepository : AbstractRepository<Circuit, int>, ICircuitRepository
    {
        public Circuit GetByUniqueUrl(string uniqueUrl)
        {
            using (var session = GetSession()) {

                var criteria = session.CreateCriteria<Circuit>();
                criteria.Add(Restrictions.Eq("Url", uniqueUrl));
                var circuits = criteria.List<Circuit>();
                return circuits.Count > 0 ? circuits[0] : null;
            }
        }
    }
}
