using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;
using atomicf1.domain;

namespace atomicf1.services
{
    public class SuperGridEntry
    {
        private decimal _poleLapTime = decimal.MaxValue;
        private decimal _totalLapTime;
        private decimal _totalPercent;
        private int _entries;

        public Driver Driver { get; set; }
        public string LapTime
        {
            get
            {
                var rank = _totalLapTime/(decimal) _entries;
                return rank.ToLapTime(); 
            }
        }

        public string CalculatedLapTime
        {
            get { return (_poleLapTime*Rank).ToLapTime(); }
        }

        public int Entries { get { return _entries;  } }

        public decimal Rank 
        { 
            get { return ((decimal) (_totalPercent/(decimal) _entries)); }
        }
        
        public void AddLapTime(decimal poleLapTime, decimal lapTime, decimal percent)
        {
            if (poleLapTime < _poleLapTime) _poleLapTime = poleLapTime;
            _totalLapTime += lapTime;
            _totalPercent += percent;
            _entries += 1;
        }
    }
}
