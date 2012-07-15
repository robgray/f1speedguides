using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace atomicf1.extensions
{
    public static class Statistics
    {
        public static XPathNodeIterator DriversChampionshipList(int season)
        {
            var xd = new XmlDocument();
            xd.LoadXml("<championship />");

            return xd.CreateNavigator().Select(".");
        }

     
    }
}
