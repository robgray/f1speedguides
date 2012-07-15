using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using NHibernate.Criterion;

namespace atomicf1.persistence
{
    public class RaceRepository : AbstractRepository<Race, int>, IRaceRepository
    {
        public IEnumerable<Race> GetRacesAllAtCircuit(Circuit circuit)
        {
            using (var session = GetSession()) {
                var criteria = session.CreateCriteria<Race>();
                criteria.Add(Restrictions.Eq("Circuit", circuit));
                return criteria.List<Race>();
            }
        }
    }
}
