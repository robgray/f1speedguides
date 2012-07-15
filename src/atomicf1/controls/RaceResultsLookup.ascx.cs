using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.persistence;

namespace atomicf1.controls
{
    public partial class RaceResultsLookup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var seasonRepository = new SeasonRepository();
                var seasons = seasonRepository.GetAll();

                SeasonList.DataSource = seasons;
                SeasonList.DataValueField = "Id";
                SeasonList.DataTextField = "Name";
                SeasonList.DataBind();

                var currentSeason = seasonRepository.GetCurrent();
                SeasonList.SelectedValue = currentSeason.Id.ToString();

                var races = currentSeason.Races;
                
                RaceList.DataSource = races;
                RaceList.DataValueField = "Id";
                RaceList.DataTextField = "Name";
                RaceList.DataBind();
            } 
        }

        protected void SeasonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seasonRepository = new SeasonRepository();
            var races = seasonRepository.GetById(int.Parse(SeasonList.SelectedValue)).Races;

            RaceList.DataSource = races;
            RaceList.DataValueField = "Id";
            RaceList.DataTextField = "Name";
            RaceList.DataBind();
        }
      
        protected void ShowResultsButton_Click(object sender, EventArgs e)
        {
            ResultsPanel.Visible = true;
            ResultDisplay.SetData(int.Parse(RaceList.SelectedValue), TypeList.SelectedValue);            
        }
    }
}