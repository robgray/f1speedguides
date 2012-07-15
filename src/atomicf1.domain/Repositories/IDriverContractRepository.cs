using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Repositories
{
    public interface IDriverContractRepository : IRepository<DriverContract, int>
    {
        IEnumerable<DriverContract> GetAllForDriver(Driver driver);
    }
}
