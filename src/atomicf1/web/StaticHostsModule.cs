using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1.web
{
    /// <summary>
    /// Scans outgoing pages and updates the url to include full path, selecting server from random server list    
    /// </summary>
    public class StaticHostsModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequestHandler;
        }

        void BeginRequestHandler(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            if (new StaticFileParallelization().UseStaticParallelization)
                application.Response.Filter = new StaticHostsFilter(application.Response.Filter);                                   
        }
    }
}