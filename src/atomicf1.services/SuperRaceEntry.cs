using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public class SuperRaceEntry
    {
        private int _totalRacePositions;
        private int _numberOfRaces;

        public SuperRaceEntry()
        {
            _totalRacePositions = 0;
            _numberOfRaces = 0;
        }

        public int Entries { get { return _numberOfRaces; } }

        public Driver Driver { get; set; }

        public decimal Position
        {
            get { return (decimal)_totalRacePositions / (decimal)_numberOfRaces; }
        }

        public void AddRacePosition(int position)
        {
            _totalRacePositions += position;
            _numberOfRaces += 1;
        }
    }
}
