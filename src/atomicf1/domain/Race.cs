using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Race : DomainObject<int>
    {
      
        public Race()
        {
            
        }

        public virtual Circuit Circuit { get; set; }

        public virtual Season Season { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual int PercentLength { get; set; }
      
    }
}
