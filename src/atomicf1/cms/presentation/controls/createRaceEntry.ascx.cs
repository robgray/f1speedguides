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

namespace atomicf1.cms.presentation.controls
{
    public partial class createRaceEntry : System.Web.UI.UserControl
    {
        private IRaceRepository _raceRepository;
        private IDriverContractRepository _driverContractRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {                
                LoadDrivers(RaceId);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _raceRepository = new RaceRepository();
            _driverContractRepository = new DriverContractRepository();
        }

        private int RaceId
        {
            get { return int.Parse(umbraco.presentation.UmbracoContext.Current.Request["nodeId"]); }
        }

        private void LoadDrivers(int raceId)
        {
            var race = _raceRepository.GetById(raceId);
            var entries = race.Season.Entrants.Select(x => new {x.Driver.Name, x.Id});

            DriversList.DataSource = entries;
            DriversList.DataTextField = "Name";
            DriversList.DataValueField = "Id";
            DriversList.DataBind();
        }

        protected void sbmt_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var race = _raceRepository.GetById(RaceId);
                var contract = _driverContractRepository.GetById(int.Parse(DriversList.SelectedValue));

                race.Enter(contract);
                _raceRepository.Save(race);
  
                BasePage.Current.ClientTools.ReloadActionNode(false, true);
                BasePage.Current.ClientTools.CloseModalWindow();
                BasePage.Current.ClientTools.ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "Driver Entry has been saved");
            }
        }
    }

    public class DriverContractEqualityComparer : EqualityComparer<DriverContract>
    {
        public override bool Equals(DriverContract x, DriverContract y)
        {
            return x.Id == y.Id;
        }

        public override int GetHashCode(DriverContract obj)
        {
            return obj.GetHashCode();
        }
    }

}