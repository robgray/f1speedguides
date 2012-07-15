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
        
        public virtual DateTime SignedDate { get; set; }

        public virtual DateTime? TerminatedDate { get; set; }

        public virtual bool IsActive 
        {
            get { return !TerminatedDate.HasValue; }
        }
    }
}
