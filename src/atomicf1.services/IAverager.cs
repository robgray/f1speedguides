using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.services
{
    public interface IAverager<TEntity, TType> 
    {
        TEntity Entity { get; }

        void Add(TType value);

        double Average { get; }
    }
}
