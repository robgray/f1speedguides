﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public abstract class DomainObject<T> 
    {
        public virtual T Id { get; set; }        
    }
}
