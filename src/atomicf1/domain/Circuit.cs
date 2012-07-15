using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Circuit : DomainObject<int>
    {
        public virtual string Location { get; set; }

        public virtual string Name { get; set; }

        public virtual string ImageUri { get; set; }

        public virtual string Country { get; set; }
    }
}
