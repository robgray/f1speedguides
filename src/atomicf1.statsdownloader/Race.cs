using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace atomicf1.statsdownloader
{
    public class Race
    {
        protected string baseUrlFormat = "http://www.formula1.com{0}";

        private List<RaceEntry> entries;

        public Race(string url, string name, DateTime raceDate)
        {
            this.Url = url;
            this.Name = name;
            entries = new List<RaceEntry>();
            this.Date = raceDate;
        }

        public string Url { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        
        public void GetData()
        {
            var web = new HtmlWeb();
            var doc = web.Load(string.Format(baseUrlFormat, Url));

            // select the main node.
            var races = doc.DocumentNode.SelectSingleNode("//table [@class='raceResults']");
            if (races == null)
                return;
            entries.Clear();
            int actualPosition = 1;  // even if all field retires, the top of the list is still 1st.
            foreach (var row in races.Descendants("tr").Skip(1))
            {
                var columns = row.Descendants("td");
                int position;

                if (int.TryParse(columns.First().InnerText.Trim(), NumberStyles.Integer, null, out position))
                {
                    actualPosition = position;
                }
                else
                {
                    actualPosition += 1;
                }
                
                var driver = columns.Skip(2).Take(1).First().Descendants("a").First().InnerText.Trim().Replace("  ", " ");
                var team = columns.Skip(3).Take(1).First().Descendants("a").First().InnerText.Trim().Replace("  ", " ");
                if (team.IndexOf("-") >= 0) team = team.Remove(team.IndexOf("-")).Trim();
                int lapOut;
                var laps = -1;
                if (int.TryParse(columns.Skip(4).Take(1).First().InnerText.Trim(), out lapOut))
                    laps = lapOut;
                var time = columns.Skip(5).Take(1).First().InnerText.Trim();
                int gridOut;
                var grid = -1;
                if (int.TryParse(columns.Skip(6).Take(1).First().InnerText.Trim(), out gridOut))
                    grid = gridOut;

                var entry = new RaceEntry(actualPosition, driver, team, laps, time, grid);
                // Default Quali position to Grid position (earlier records don't have quali info) -- possibly due to random starts.
                entry.QualifyingPosition = grid.ToString();
                entry.PositionString = columns.First().InnerText.Trim();
                
                entries.Add(entry);
            }         

            // Get session bar
            // Hosts fastest laps etc.
            var tertiaryNavItem = doc.DocumentNode.SelectSingleNode("//div [@class='tertiaryNavItem']");
            if (tertiaryNavItem == null)
                return;

            var fastestLapLink = tertiaryNavItem.SelectNodes(".//a").Where(x => x.InnerText == "FASTEST LAPS").FirstOrDefault();
            if (fastestLapLink != null)
            {
                var fastestLapsData = new FastestLaps(fastestLapLink.Attributes["href"].Value);
                fastestLapsData.GetData();
                
                foreach (var fastestLap in fastestLapsData.FastestLapData)
                {
                    var raceEntry = Entries.SingleOrDefault(x => x.Driver == fastestLap.Name);
                    if (raceEntry != null)
                        raceEntry.FastestLapTime = fastestLap.LapTime;
                }
            }

            // There are multiple qualifying links in some seasons
            var qualifyingLink = tertiaryNavItem.SelectNodes(".//a").Where(x => x.InnerText == "QUALIFYING").FirstOrDefault();
            if (qualifyingLink == null)
                qualifyingLink = tertiaryNavItem.SelectNodes(".//a").Where(x => x.InnerText == "SATURDAY QUALIFYING").FirstOrDefault();

            if (qualifyingLink != null)
            {
                var qualifyingSession = new QualifyingSession(qualifyingLink.Attributes["href"].Value);
                qualifyingSession.GetData();

                foreach(var qualifying in qualifyingSession.Qualifiers)
                {
                    var raceEntry = Entries.SingleOrDefault(x => x.Driver == qualifying.Driver);
                    if (raceEntry != null)
                    {
                        raceEntry.QualifyingPosition = qualifying.Position;
                        raceEntry.QualifyingTime1 = qualifying.QualifyingTime1;
                        raceEntry.QualifyingTime2 = qualifying.QualifyingTime2;
                        raceEntry.QualifyingTime3 = qualifying.QualifyingTime3;
                    }
                }
            }

        }

        public IEnumerable<RaceEntry> Entries { get { return entries; } }

    }
}
