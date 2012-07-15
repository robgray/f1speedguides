using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.common
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string this[string key]
        {
            get { return System.Configuration.ConfigurationManager.AppSettings[key];  }
        }
    }
}
