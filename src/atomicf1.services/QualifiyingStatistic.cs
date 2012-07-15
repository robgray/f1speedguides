using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public class QualifiyingStatistic
    {
        private int _totalPositions;
        private int _totalQualifyingSessions;
        private int _totalQualifyingSessionsWithTime;
        private decimal _totalTime;
        private decimal _totalGap;
        private decimal _bestLap;
        
        private decimal? _averageLapTime;

        public QualifiyingStatistic(DriverContract entrant)
        {
            _totalPositions = 0;
            _totalQualifyingSessions = 0;
            _totalQualifyingSessionsWithTime = 0;
            _totalTime = 0;
            _bestLap = Decimal.MaxValue;

            Entrant = entrant;
        }
        
        public DriverContract Entrant { get; private set; }

        public decimal AveragePosition 
        {
            get {
                if (_totalQualifyingSessions == 0) return 1000;
                return _totalPositions/(decimal)_totalQualifyingSessions; 
            }
        }

        public decimal BestLap { get { return _bestLap; } } 

        public decimal AveragePercentBack
        {
            get {                
                if (_totalQualifyingSessionsWithTime == 0) return 1000; 
                return _totalGap / (decimal)_totalQualifyingSessionsWithTime; 
            }
        }

        public decimal AverageLapTime
        {
            get
            {
                if (_averageLapTime.HasValue)
                {
                    return _averageLapTime.Value;
                }
                else
                {
                    if (_totalQualifyingSessionsWithTime == 0) return 1000;
                    return _totalTime / (decimal)_totalQualifyingSessionsWithTime;
                }
            }
        }

        public void RegisterResult(int position, decimal lapTime, decimal poleTime)
        {
            _totalQualifyingSessions++;
            _totalPositions += position;

            if (lapTime > 0 && poleTime > 0) {
                _totalTime += lapTime;
                _totalGap += (lapTime / poleTime);
                _totalQualifyingSessionsWithTime++;

                if (lapTime < _bestLap) _bestLap = lapTime;
            }
        }

        public void SetAverageLapTime(decimal fastestAverageLapTime)
        {
            _averageLapTime = fastestAverageLapTime * AveragePercentBack;
        }
    }
}
