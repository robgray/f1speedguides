using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain.Repositories;
using atomicf1.domain;
using NHibernate.Criterion;

namespace atomicf1.persistence
{
    public class SeasonRepository : AbstractRepository<Season, int>, ISeasonRepository
    {

        #region ISeasonRepository Members

        public IEnumerable<Season> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Season GetSeasonWithRaceId(int raceId)
        {
            using (var session = GetSession()) {
                var race = session.Get<Race>(raceId);
                if (race == null) return null;
                return race.Season;
            }
        }

        public void SaveRace(Race entity)
        {
            throw new NotImplementedException();
        }


        public Season GetCurrent()
        {
            using (var session = GetSession()) {
                var criteria = session.CreateCriteria<Season>()
                    .Add(Restrictions.Eq("IsCurrent", true));

                var results = criteria.List<Season>();
                if (results != null && results.Count > 0) return results.First();                
                return GetAll().OrderByDescending(x => x.Name).FirstOrDefault();                
            }
        }

        #endregion
    }
}
