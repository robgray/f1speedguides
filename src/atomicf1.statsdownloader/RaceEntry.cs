using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.statsdownloader
{
    public class RaceEntry
    {
        public RaceEntry(int position, string driver, string team, int laps, string time, int grid)
        {
            Position = position;
            Driver = driver;
            Team = team;
            Laps = laps;
            Time = time;
            Grid = grid;
        }

        public string PositionString { get; set; }
        public int Position { get; private set; }
        public string Driver { get; private set; }
        public string Team { get; private set; }
        public int Laps { get; private set; }
        public string Time { get; private set; }
        public int Grid { get; private set; }

        public string FastestLapTime { get; set; }

        public string QualifyingTime1 { get; set; }
        public string QualifyingTime2 { get; set; }
        public string QualifyingTime3 { get; set; }

        public string QualifyingPosition { get; set; }
    }
}
