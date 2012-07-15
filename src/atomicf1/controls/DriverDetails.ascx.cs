using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class DriverDetails : System.Web.UI.UserControl
    {
        private IDriverRepository _driverRepository;
        private ISeasonRepository _seasonRepository;
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                
                CheckDependancies();

                var driver = _driverRepository.GetById(DriverId);
                PopulateDriverDetail(driver);
            }
        }

        public int DriverId { get; set; }
    
        private void CheckDependancies()
        {
            if (_statistician == null) _statistician = new CachedStatistician();
            if (_driverRepository == null) _driverRepository = new DriverRepository();
            if (_seasonRepository == null) _seasonRepository = new SeasonRepository();
        }

        private void PopulateDriverDetail(Driver driver)
        {
            if (driver == null) {
                Response.Redirect("~/notfound");                
            }

            var stat = _statistician.GetDriverStatistics(driver);

            IList<DriverDetailsViewModel> models = new List<DriverDetailsViewModel>
                                                       {
                                                           BuildDriverDetailsViewModel(driver, stat)
                                                       };

            DriverDetail.DataSource = models;
            DriverDetail.DataBind();

            AveragesRepeater.DataSource = stat.SeasonAverageStatistics.OrderBy(s => s.Name);
            AveragesRepeater.DataBind();
        }

        private DriverDetailsViewModel BuildDriverDetailsViewModel(Driver driver, Statistics statistic)
        {
            return new DriverDetailsViewModel
                        {
                            Name = driver.Name,
                            CurrentTeam = driver.CurrentTeam != null ? driver.CurrentTeam.Name : "* Not Contracted *",
                            AtomicName = driver.AtomicName,
                            BestQualifyingResult = statistic.BestQualifyingResult,
                            BestRaceResult = statistic.BestRaceResult,
                            BestChampionshipResult = statistic.BestChampionshipResult,
                            RacerRatio = statistic.RacerRatio,
                            Races = statistic.Entered,                            
                            Points = statistic.Points,
                            PointsPerRace = statistic.PointsPerRace,
                            Wins = statistic.Wins,
                            WinsPercent = statistic.WinsPercent,
                            Poles = statistic.Poles,
                            PolesPercent = statistic.PolesPercent,
                            Podiums = statistic.Podiums,
                            PodiumsPercent = statistic.PodiumsPercent,
                            FastestLaps = statistic.FastestLaps,
                            FastestLapsPercent = statistic.FastestLapsPercent,
                            Finishes = statistic.Finished,
                            FinishesPercent = statistic.FinishedPercent,
                            Seasons = statistic.Seasons
                        };
        }
    }

    public class DriverDetailsViewModel : EntrantStatisticsViewModel
    {        
        public string AtomicName { get; set; }
        public string CurrentTeam { get; set; }
        public double RacerRatio { get; set; }
    }

    public class EntrantStatisticsViewModel : StatisticsViewModel
    {
        public string Name { get; set; }
    }

    public class StatisticsViewModel
    {
        public int Races { get; set; }
        public int Points { get; set; }
        public double RacerRatio { get; set; }
        public double PointsPerRace { get; set; }
        public int Wins { get; set; }
        public double WinsPercent { get; set; }
        public int Poles { get; set; }
        public double PolesPercent { get; set; }
        public int Podiums { get; set; }
        public double PodiumsPercent { get; set; }
        public int FastestLaps { get; set; }
        public double FastestLapsPercent { get; set; }
        public int Finishes { get; set; }
        public double FinishesPercent { get; set; }
        public int Seasons { get; set; }
        public int BestQualifyingResult { get; set; }
        public int BestRaceResult { get; set; }
        public int BestChampionshipResult { get; set; }
        public string BestQualifyingResultString 
        {
            get { return BestQualifyingResult == int.MaxValue ? "N/A" : BestQualifyingResult.ToString(); }
        }
        public string BestRaceResultString 
        {
            get { return BestRaceResult == int.MaxValue ? "N/A" : BestRaceResult.ToString(); }
        }
    }
}