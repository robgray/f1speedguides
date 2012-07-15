using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1.web
{
    public class ImageElementFilter : ElementFilter
    {
        protected override string AttributeToken { get { return "src="; } }
        protected override string ElementToken { get { return "<img "; } }
        protected override string ElementEndToken { get { return ">";  } }
    }
}