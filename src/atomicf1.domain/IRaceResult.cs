using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public interface IRaceResult
    {
        DriverContract Entrant { get; }
        
        decimal Points { get; }
        
        int RacePlace { get; }
    }
}
