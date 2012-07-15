using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using atomicf1.persistence;
using System.IO;
using umbraco;
using atomicf1.domain;

namespace atomicf1.extensions
{
    public class XslHelper
    {
        public static XPathNodeIterator GetDriver(int driverId)
        {
            var driverRepository = new DriverRepository();
            var driver = driverRepository.GetById(driverId);

            return DriverToXml(driver);
        }

        public static XPathNodeIterator GetTeam(int teamId)
        {
            var teamRepository = new TeamRepository();
            var team = teamRepository.GetById(teamId);

            return TeamToXml(team);
        }

        public static XPathNodeIterator GetCircuit(int circuitId)
        {
            var circuitRepository = new CircuitRepository();
            var circuit = circuitRepository.GetById(circuitId);

            return CircuitToXml(circuit);
        }

        private static XPathNodeIterator DriverToXml(Driver driver)
        {
            var xd = new XmlDocument();
            var x = xmlHelper.addTextNode(xd, "drivers", "");

            if (driver != null)
            {
                XmlNode c = xd.CreateElement("driver");

                c.AppendChild(xmlHelper.addCDataNode(xd, "id", driver.Id.ToString()));
                c.AppendChild(xmlHelper.addCDataNode(xd, "name", driver.Name));
                c.AppendChild(xmlHelper.addCDataNode(xd, "atomicname", driver.AtomicName));
                c.AppendChild(xmlHelper.addCDataNode(xd, "atomicid", driver.AtomicUserId.ToString()));
                c.AppendChild(xmlHelper.addCDataNode(xd, "nationality", driver.Nationality));

                x.AppendChild(c);
            }

            xd.AppendChild(x);
            return xd.CreateNavigator().Select(".");
        }

        private static XPathNodeIterator TeamToXml(Team team)
        {
            var xd = new XmlDocument();
            var x = xmlHelper.addTextNode(xd, "teams", "");

            if (team != null)
            {
                XmlNode c = xd.CreateElement("team");

                c.AppendChild(xmlHelper.addCDataNode(xd, "id", team.Id.ToString()));
                c.AppendChild(xmlHelper.addCDataNode(xd, "name", team.Name));
                c.AppendChild(xmlHelper.addCDataNode(xd, "imageuri", team.ImageUri));
               
                x.AppendChild(c);
            }

            xd.AppendChild(x);
            return xd.CreateNavigator().Select(".");
        }

        private static XPathNodeIterator CircuitToXml(Circuit circuit)
        {
            var xd = new XmlDocument();
            var x = xmlHelper.addTextNode(xd, "circuits", "");

            if (circuit != null)
            {
                XmlNode c = xd.CreateElement("circuit");

                c.AppendChild(xmlHelper.addCDataNode(xd, "id", circuit.Id.ToString()));
                c.AppendChild(xmlHelper.addCDataNode(xd, "name", circuit.Name));
                c.AppendChild(xmlHelper.addCDataNode(xd, "imageuri", circuit.ImageUri));
                c.AppendChild(xmlHelper.addCDataNode(xd, "country", circuit.Country));
                c.AppendChild(xmlHelper.addCDataNode(xd, "location", circuit.Location));

                x.AppendChild(c);
            }

            xd.AppendChild(x);
            return xd.CreateNavigator().Select(".");
        }

        public static string GetUtcDate(string dateTime)
        {
            var time = DateTime.Parse(dateTime);

            // All dates are entered in Sydney Time
            TimeZoneInfo sydneyTimeZone = TimeZoneInfo.GetSystemTimeZones().First(zone => zone.StandardName == "AUS Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeToUtc(time, sydneyTimeZone).ToString("ddd MMM dd yyyy HH:mm:ss");
        }
    }
}
