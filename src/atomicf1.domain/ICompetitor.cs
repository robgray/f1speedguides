using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public interface ICompetitor
    {
        string Name { get; set; }
        int Id { get; set; }
    }
}
