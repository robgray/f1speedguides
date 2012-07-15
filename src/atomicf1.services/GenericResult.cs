using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.services
{
    public class GenericResult
    {
        public int KeyId { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }
    }
}
