using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace atomicf1.statsdownloader
{
    public class QualifyingSession
    {
        protected string baseUrlFormat = "http://www.formula1.com{0}";

        public string Url { get; private set; }
        public QualifyingSession(string url)
        {
            Url = url;
            qualifiers = new List<QualifyingLap>();
        }

        protected List<QualifyingLap> qualifiers;

        public IEnumerable<QualifyingLap> Qualifiers
        {
            get { return qualifiers; }
        }

        public void GetData()
        {
            var web = new HtmlWeb();
            var doc = web.Load(string.Format(baseUrlFormat, Url));

            

            // select the main node.
            var races = doc.DocumentNode.SelectSingleNode("//table [@class='raceResults']");
            
            if (races == null)
                return;
            qualifiers.Clear();
            // use header row to see how many quali sessions.
            var headerRow = races.Descendants("tr").Take(1).Single();
            var hasMultipleQualifying = true;
            var headerColumns = headerRow.Descendants("th");            
            if (headerColumns.Skip(4).Take(1).First().InnerText.Trim() == "Time/Retired")
                hasMultipleQualifying = false;

            foreach (var row in races.Descendants("tr").Skip(1))
            {
                var columns = row.Descendants("td");
                var position = columns.First().InnerText;
                if (string.IsNullOrEmpty(position))
                    continue;
                var driver = columns.Skip(2).Take(1).First().Descendants("a").First().InnerText;
                var q1 = columns.Skip(4).Take(1).First().InnerText.Trim();
                var q2 = hasMultipleQualifying ? columns.Skip(5).Take(1).First().InnerText.Trim() : "";
                var q3 = hasMultipleQualifying ? columns.Skip(6).Take(1).First().InnerText.Trim() : "";

                var qualifyingLap = new QualifyingLap()
                                        {
                                            Driver = driver,
                                            Position = position,
                                            QualifyingTime1 = q1,
                                            QualifyingTime2 = q2,
                                            QualifyingTime3 = q3
                                        };

                qualifiers.Add(qualifyingLap);
            }
        }
    }
}
