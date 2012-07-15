using System;
using System.Collections.Generic;
using System.Linq;
using atomicf1.common;

namespace atomicf1.web
{
    public class StaticFileParallelization
    {
        private string[] _staticHosts;
        private string[] _excludePaths;

        private IConfigurationManager _configurationManager;

        public StaticFileParallelization() : this(new ConfigurationManager()) { }
        
        public StaticFileParallelization(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }
        
        public string[] StaticHosts
        {
            get
            {
                if (_staticHosts == null)
                {
                    var staticHostsString = string.IsNullOrEmpty(_configurationManager["StaticHosts"])
                        ? "www.atomicf1.com"
                        : _configurationManager["StaticHosts"];

                    _staticHosts = staticHostsString.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }

                return _staticHosts;
            }
        }
        
        public bool UseStaticParallelization
        {
            get
            {
                return bool.Parse(string.IsNullOrEmpty(_configurationManager["UseStaticParallelization"])
                    ? "false"
                    : _configurationManager["UseStaticParallelization"]);
            }
        }

        public string[] ExcludePaths
        {
            get
            {
                if (_excludePaths == null)
                {
                    var excludePaths = string.IsNullOrEmpty(_configurationManager["ExcludePaths"])
                        ? "/umbraco/"
                        : _configurationManager["ExcludePaths"];

                    _excludePaths = excludePaths.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);                                                                   
                }

                return _excludePaths;
            }
        }

        public string GetStaticUrl(string relativeUrl)
        {
            if (!UseStaticParallelization)
                return relativeUrl;

            if (relativeUrl.StartsWith("http"))
                return relativeUrl;

            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;

            if (relativeUrl.ContainsAnyOf(ExcludePaths))
                return relativeUrl;

            var hostNumber = Math.Abs(relativeUrl.GetHashCode()) % StaticHosts.Length;
            return string.Format("http://{0}{1}", StaticHosts[hostNumber], relativeUrl.StartsWith("/") ? relativeUrl : "/" + relativeUrl);
        }        
    }
}