using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{    
    public class Team : LinkableObject<int>, ICompetitor
    {
        protected virtual IList<DriverContract> _contracts { get; set; }

        public Team()
        {
            _contracts = new List<DriverContract>();
        }

        public virtual string ImageUri { get; set; }
                
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

        public virtual IEnumerable<DriverContract> Contracts
        {
            get { return _contracts; }
        }

        public virtual IEnumerable<DriverContract> ActiveContracts
        {
            get { return _contracts.Where(c => c.IsActive); }
        }
        
        public virtual Statistics Statistics { get; private set; }

        public virtual DriverContract SignDriver(Driver driver, Season season)
        {
            if (IsDriverUnderContract(driver, season))
                throw new DriverAlreadyContractedException();

            var contract = new DriverContract
                               {
                                   Driver = driver,
                                   SignedDate = DateTime.Now,
                                   Season = season,
                                   Team = this
                               };

            _contracts.Add(contract);
            return contract;
        }

        public virtual void FireDriver(Driver driver)
        {
            var contract = _contracts.FirstOrDefault(c => c.Driver == driver && c.IsActive);
            if (contract != null) {
                contract.TerminatedDate = DateTime.Now;
                //driver.CurrentTeam = null;
               // _contracts.Remove(contract);
            }
        }

        protected bool IsDriverUnderContract(Driver driver, Season season)
        {
            return _contracts.Any(c => c.Driver.Id == driver.Id && c.Season.Id == season.Id && c.IsActive);
        }
    }

    public class DriverAlreadyContractedException : Exception
    {
        public DriverAlreadyContractedException() : base("Driver is already contracted to this team") { }

        public DriverAlreadyContractedException(string message) : base(message) { } 

        public DriverAlreadyContractedException(string message, Exception ex) : base(message, ex) { } 
    }
}
