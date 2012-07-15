using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public interface ILinkable
    {
        string Name { get; set; }
        string Url { get; set; }
    }
}
