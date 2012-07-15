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
    public partial class DriversAverageTable : System.Web.UI.UserControl
    {
        private IStatistician _statistician;
        private ISeasonRepository _seasonRepository;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckDependancies();
            AverageType = TypeList.SelectedValue;

            if (!IsPostBack)
            {
                var seasons = _seasonRepository.GetAll().OrderBy(x => x.Name).ToList();
                seasons.Add(new Season() {Name = "All"});
                SeasonList.DataSource = seasons.OrderBy(x => x.Name);
                SeasonList.DataTextField = "Name";
                SeasonList.DataValueField = "Id";
                SeasonList.DataBind();

                GetAverage();
            }
        }

        public string AverageType { get; set; }

        private void CheckDependancies()
        {
            if (_statistician == null) _statistician = new CachedStatistician();
            if (_seasonRepository == null) _seasonRepository = new SeasonRepository();
        }

        protected void SeasonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAverage();
        }

        protected void ShowResultsButton_Click(object sender, EventArgs e)
        {
            GetAverage();
        }

        private void GetAverage()
        {
            var season = _seasonRepository.GetById(int.Parse(SeasonList.SelectedValue));

            AverageTable.DataSource = AverageType == "Race"
                    ? _statistician.GetDriversTableRankedByAverageRacePlace(season)
                    : _statistician.GetDriversTableRankedByAverageGridPlace(season);

            AverageTable.DataBind();                
        }
    }
}