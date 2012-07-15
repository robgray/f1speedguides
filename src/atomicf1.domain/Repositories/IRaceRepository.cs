using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Repositories
{
    public interface IRaceRepository : IRepository<Race, int>
    {
        IEnumerable<Race> GetRacesAllAtCircuit(Circuit circuit);
    }
}
