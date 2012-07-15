using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Team : DomainObject<int>
    {
        protected IList<DriverContract> _contracts;

        public Team()
        {
            _contracts = new List<DriverContract>();
        }

        public virtual string ImageUri { get; set; }

        public virtual string Name { get; set; }

        public virtual IEnumerable<Driver> Drivers
        {
            get
            {
                var currentDrivers = (from d in _contracts
                                     where d.IsActive
                                     select d.Driver).ToList();

                return currentDrivers;
            }            
        }    
    }
}
