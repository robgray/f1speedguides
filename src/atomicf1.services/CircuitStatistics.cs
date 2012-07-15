using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.common;

namespace atomicf1.services
{
    public class CircuitStatistics
    {        
        private decimal _qualifyingRecord;

        public CircuitStatistics(Circuit circuit, DriverContract previousWinner, decimal qualifyingRecord, DriverContract qualifyingRecordHolder)
        {
            Circuit = circuit;
            PreviousWinner = previousWinner;
            _qualifyingRecord = qualifyingRecord;
            QualifyingRecordHolder = qualifyingRecordHolder;
        }

        public Circuit Circuit { get; private set; }
        public DriverContract PreviousWinner { get; private set; }
        public DriverContract QualifyingRecordHolder { get; set; }
        public string QualifyingRecord 
        { 
            get { return _qualifyingRecord.ToLapTime(); }
        }

    }
}
