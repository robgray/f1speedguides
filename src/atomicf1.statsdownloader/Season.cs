using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace atomicf1.statsdownloader
{
    public class Season
    {
        protected string baseUrlFormat = "http://www.formula1.com/results/season/{0}/";
        private int year;

        private List<Race> races;

        public Season(int year)
        {
            this.year = year;            
        }

        public void GetData()
        {
            var web = new HtmlWeb();
            var doc = web.Load(string.Format(baseUrlFormat, year));

            // select the main node.
            var racesDoc = doc.DocumentNode.SelectSingleNode("//table [@class='raceResults']");
            races = new List<Race>();
            foreach (var row in racesDoc.Descendants("tr").Skip(1))
            {
                var raceLink = row.Descendants("td").First().Descendants("a").First();
                var raceDateNode = row.Descendants("td").Skip(1).Take(1).Single();
                
                var race = new Race(raceLink.Attributes["href"].Value, raceLink.InnerText.Trim(), DateTime.Parse(raceDateNode.InnerText.Trim()));                                
                races.Add(race);
            }
        }

        public IEnumerable<Race> Races
        {
            get { return races; }
        }        
        
        public IEnumerable<string> CircuitNames
        {
            get { return races.Select(x => x.Name); }
        }
    }
}
