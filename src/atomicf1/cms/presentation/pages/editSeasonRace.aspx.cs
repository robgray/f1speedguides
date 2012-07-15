using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BasePages;
using umbraco.DataLayer;

namespace atomicf1.cms.presentation.pages
{
    public partial class editSeasonRace : BasePage
    {
        private ICircuitRepository _circuitRepository;
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                int id = int.Parse(Request["id"]);
                int seasonid = int.Parse(Request["seasonid"]);

                LoadCircuits();
                LoadRecord(RaceId, SeasonId);
            }

        }

        private void LoadCircuits()
        {
            var allCircuits = _circuitRepository.GetAll();

            CircuitsList.DataSource = allCircuits;
            CircuitsList.DataTextField = "Name";
            CircuitsList.DataValueField = "Id";
            CircuitsList.DataBind();                        
        }

        protected void LoadRecord(int id, int seasonId)
        {
            var season = _seasonRepository.GetById(seasonId);

            var race = season.Races.FirstOrDefault(r => r.Id == id);

            if (race != null)
            {
                var listItem = CircuitsList.Items.FindByText(race.Circuit.Name);
                if (listItem != null) listItem.Selected = true;
                RaceIdLabel.Text = race.Id.ToString();
                RaceDate.Text = race.StartDate.ToString();
                PercentLength.Text = race.PercentLength.ToString();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _circuitRepository = new CircuitRepository();
            _seasonRepository = new SeasonRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        private int SeasonId
        {
            get { return int.Parse(Request["seasonid"]);  }
        }

        private int RaceId
        {
            get { return int.Parse(Request["id"]); }
        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var season = _seasonRepository.GetById(SeasonId);
                var race = season.Races.FirstOrDefault(r => r.Id == RaceId);
                if (race != null) {
                    var circuit = _circuitRepository.GetById(int.Parse(CircuitsList.SelectedValue));
                    race.Circuit = circuit;
                    race.StartDate = DateTime.Parse(RaceDate.Text);
                    race.PercentLength = int.Parse(PercentLength.Text);

                    _seasonRepository.Save(season);

                    BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved",
                                                              "Race schedule has been saved.");
                }               
            }
        }
    }
}