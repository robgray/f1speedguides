using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Driver : DomainObject<int>
    {
        public virtual string Name { get; set; }

        public virtual string Nationality { get; set; }

        public virtual string ImageUri { get; set; }

        public virtual Team CurrentTeam { get; set; }       
    }
}
