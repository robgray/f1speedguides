using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace atomicf1.domain
{
    public class Driver : LinkableObject<int>, ICompetitor
    {
        protected virtual IList<DriverContract> _contracts { get; set; }

        public Driver()
        {
            _contracts = new List<DriverContract>();
        }

        public virtual string Nationality { get; set; }

        public virtual string ImageUri { get; set; }

        public virtual string AtomicName { get; set; }

        public virtual int AtomicUserId { get; set; }        
                        
        public virtual Statistics Statistics { get; set; }

        public virtual IEnumerable<DriverContract> Contracts 
        {
            get { return _contracts; }          
        }    

        public virtual void SignContract(DriverContract contract)
        {
            if (_contracts.Any(c => c.Id == contract.Id))
                return;

            _contracts.Add(contract);
        }

        public Team CurrentTeam 
        { 
            get { 
                var currentContract = _contracts.FirstOrDefault(c => c.Season.IsCurrent);
                return currentContract != null ? currentContract.Team : null; 
            }
        }
    }
}
