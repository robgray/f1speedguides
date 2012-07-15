using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Repositories
{
    public interface ICircuitRepository : IRepository<Circuit, int>
    {
        Circuit GetByUniqueUrl(string uniqueUrl);

    }
}
