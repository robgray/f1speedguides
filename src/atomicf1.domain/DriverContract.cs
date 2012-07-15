using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class DriverContract : DomainObject<int>
    {
        public virtual Driver Driver { get; set; }

        public virtual Team Team { get; set; }

        public virtual Season Season { get; set; }

        public virtual bool IsReserve { get; set; }
        
        public virtual DateTime SignedDate { get; set; }

        public virtual DateTime? TerminatedDate { get; set; }

        public virtual bool IsActive 
        {
            get { return !TerminatedDate.HasValue; }
        }

        public virtual bool HasRacedThisSeason
        {
            get
            {
                return Season.Races.Any(r => r.Entries.Any(e => e.Entrant.Id == this.Id));
            }
        }       
    }
}
