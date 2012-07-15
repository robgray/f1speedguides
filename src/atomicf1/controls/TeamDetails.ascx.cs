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
    public partial class TeamDetails : System.Web.UI.UserControl
    {
        private ITeamRepository _teamRepository;
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckDependancies();

                var team = _teamRepository.GetById(TeamId);
                PopulateTeamDetail(team);
            }
        }

        private void PopulateTeamDetail(Team team)
        {
            if (team == null)
            {
                Response.Redirect("~/notfound");
            }

            var stat = _statistician.GetTeamStatistics(team);

            IList<EntrantStatisticsViewModel> models = new List<EntrantStatisticsViewModel>
                                                       {
                                                           BuildTeamDetailsViewModel(team, stat)
                                                       };

            TeamDetail.DataSource = models;
            TeamDetail.DataBind();

            AveragesRepeater.DataSource = stat.SeasonAverageStatistics.OrderBy(s => s.Name);
            AveragesRepeater.DataBind();
        }


        public int TeamId { get; set; }

        private void CheckDependancies()
        {
            if (_statistician == null) _statistician = new CachedStatistician();
            if (_teamRepository == null) _teamRepository = new TeamRepository();
        }

        private static EntrantStatisticsViewModel BuildTeamDetailsViewModel(Team team, Statistics statistic)
        {
            return new EntrantStatisticsViewModel
            {
                Name = team.Name,                                
                Races = statistic.Entered,
                Points = statistic.Points,
                PointsPerRace = statistic.PointsPerRace,
                Wins = statistic.Wins,
                WinsPercent = statistic.WinsPercent,
                Poles = statistic.Poles,
                PolesPercent = statistic.PolesPercent,
                Podiums = statistic.Podiums,
                PodiumsPercent = statistic.PodiumsPercent,
                Finishes = statistic.Finished,
                FinishesPercent = statistic.FinishedPercent,
                Seasons = statistic.Seasons,
                BestQualifyingResult = statistic.BestQualifyingResult,
                BestRaceResult = statistic.BestRaceResult,
                BestChampionshipResult = statistic.BestChampionshipResult
            };
        }
    }
}