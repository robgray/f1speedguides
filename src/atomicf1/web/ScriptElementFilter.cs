using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1.web
{
    public class ScriptElementFilter : ElementFilter
    {
        protected override string AttributeToken { get { return "src="; } }
        protected override string ElementToken { get { return "<script "; } }
        protected override string ElementEndToken { get { return ">"; } }
    }
}