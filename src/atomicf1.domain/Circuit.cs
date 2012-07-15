using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;

namespace atomicf1.domain
{ 
    public class Circuit : LinkableObject<int>
    {        
        public virtual string Location { get; set; }

        public virtual string ImageUri { get; set; }

        public virtual string Country { get; set; }

        public override string ToString()
        {
            return Name + ", " + Country;
        }
    }
}
