using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Statistics
    {
        public Statistics()
        {
            SeasonAverageStatistics = new List<SeasonAverageStatistic>();
            BestChampionshipResult = int.MaxValue;
        }

        public virtual int Entered { get; set; }

        // Fastest Laps only became available in F1 2011 onwards.
        public virtual int FastestLapsEntered { get; set; }

        public virtual int Wins { get; set; }

        public virtual double WinsPercent
        {
            get { return Entered > 0 ? Wins/(double) Entered * 100 : 0; }
        }

        public virtual int Poles { get; set; }

        public virtual double PolesPercent { get { return Entered > 0 ? Poles/(double) Entered*100 : 0; } }

        public virtual int Points { get; set; }

        public virtual double PointsPerRace { get { return Entered > 0 ? Points/(double) Entered : 0; }  }

        public virtual int Podiums { get; set; }

        public virtual double PodiumsPercent { get { return Entered > 0 ? Podiums/(double) Entered*100 : 0; } }

        public virtual int FastestLaps { get; set; }

        public virtual double FastestLapsPercent { get { return FastestLapsEntered > 0 ? FastestLaps / (double)FastestLapsEntered * 100 : 0; } }

        public virtual int Finished { get; set; }

        public virtual double FinishedPercent { get { return Entered > 0 ? Finished / (double)Entered*100 : 0; } }

        public virtual int Seasons { get; set; }

        public virtual double RacerRatio { get; set; }

        public virtual int BestQualifyingResult 
        {
            get
            {
                return SeasonAverageStatistics.Min(s => s.BestQualifyingResult);
            }
        }

        public virtual int BestRaceResult 
        {
            get
            {
                return SeasonAverageStatistics.Min(s => s.BestRaceResult);
            }
        }

        public virtual int BestChampionshipResult { get; set; }

        public virtual IList<SeasonAverageStatistic> SeasonAverageStatistics { get; private set; }

        public virtual SeasonAverageStatistic NewSeasonAverageStatistic(string name)
        {
            var average = new SeasonAverageStatistic {Name = name};
            
            SeasonAverageStatistics.Add(average);

            return average;
        }
       
        public class SeasonAverageStatistic
        {
            private int _races;
            private int _qualifies;
            private int _qualifyPosition;
            private int _racePosition;

            public SeasonAverageStatistic()
            {
                BestRaceResult = int.MaxValue;
                BestQualifyingResult = int.MaxValue;
            }
            
            public virtual string Name { get; set; }
            
            public virtual decimal AverageQualifying
            {
                get 
                {
                    if (_qualifies == 0) return 0;
                    return ((decimal)_qualifyPosition) / _qualifies; 
                }
            }

            public virtual decimal AverageRace 
            { 
                get
                {
                    if (_races == 0) return 0;
                    return ((decimal) _racePosition)/_races;
                }
            }

            public virtual void AddRaceResult(int racePosition)
            {
                if (racePosition < BestRaceResult)
                    BestRaceResult = racePosition;

                _races += 1;                
                _racePosition += racePosition;                
            }

            public virtual void AddQualifyingResult(int qualifyingPosition)
            {
                if (qualifyingPosition < BestQualifyingResult)
                    BestQualifyingResult = qualifyingPosition;

                _qualifies += 1;
                _qualifyPosition += qualifyingPosition;                
            }

            public virtual int BestRaceResult { get; private set; }

            public virtual int BestQualifyingResult { get; private set; }
        }
        
    }
}
