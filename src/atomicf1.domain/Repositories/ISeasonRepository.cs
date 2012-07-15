using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Repositories
{
    public interface ISeasonRepository : IRepository<Season, int>
    {
        IEnumerable<Season> GetByYear(int year);

        Season GetSeasonWithRaceId(int raceId);

        void SaveRace(Race entity);

        Season GetCurrent();
    }
}
