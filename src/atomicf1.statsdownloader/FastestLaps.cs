using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace atomicf1.statsdownloader
{
    public class FastestLaps
    {
        protected string baseUrlFormat = "http://www.formula1.com{0}";
        private List<FastestLap> fastestLaps;

        public IEnumerable<FastestLap> FastestLapData
        {
            get { return fastestLaps; }   
        }

        public FastestLaps(string url)
        {
            Url = url;
            fastestLaps = new List<FastestLap>();
        }

        public string Url { get; private set; }

        public void GetData()
        {
            var web = new HtmlWeb();
            var doc = web.Load(string.Format(baseUrlFormat, Url));

            // select the main node.
            var races = doc.DocumentNode.SelectSingleNode("//table [@class='raceResults']");
            if (races == null)
                return;

            fastestLaps.Clear();
            foreach (var row in races.Descendants("tr").Skip(1))
            {
                var columns = row.Descendants("td");                
                var driver = columns.Skip(2).Take(1).First().Descendants("a").First().InnerText;
                var time = columns.Skip(7).Take(1).First().InnerText;

                var entry = new FastestLap() {LapTime = time, Name = driver};

                fastestLaps.Add(entry);
            }
        }
    }
}
