using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public interface IRateable
    {
        void Rate(int rating);
        decimal GetRating(IVoter voter);
    }
}
