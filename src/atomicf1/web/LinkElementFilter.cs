using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1.web
{
    public class LinkElementFilter : ElementFilter
    {
        protected override string AttributeToken { get { return "href="; } }
        protected override string ElementToken { get { return "<link "; } }
        protected override string ElementEndToken { get { return "/>"; } }
    }
}