using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BasePages;
using atomicf1.domain;

namespace atomicf1.cms.presentation.controls
{
    public partial class createSeasonRace : UserControl
    {
        private ICircuitRepository _circuitRepository;
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadCircuits();              
        }

        private void LoadCircuits()
        {
            var allCircuits = _circuitRepository.GetAll();

            CircuitsList.DataSource = allCircuits;
            CircuitsList.DataTextField = "Name";
            CircuitsList.DataValueField = "Id";
            CircuitsList.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _circuitRepository = new CircuitRepository();
            _seasonRepository = new SeasonRepository();            
        }

        protected int SeasonId
        {
            get { return int.Parse(umbraco.presentation.UmbracoContext.Current.Request["nodeId"]); }
        }

        protected void sbmt_Click(object sender, EventArgs e)
        {            
            var season = _seasonRepository.GetById(SeasonId);

            season.AddRace(new Race
                               {
                                   Circuit = _circuitRepository.GetById(int.Parse(CircuitsList.SelectedValue)),
                                   StartDate = DateTime.Parse(RaceDateBox.Text),
                                   PercentLength = int.Parse(PercentLength.Text)
                               });

            _seasonRepository.Save(season);            
            
            BasePage.Current.ClientTools.ReloadActionNode(false, true);
            BasePage.Current.ClientTools.CloseModalWindow();
            BasePage.Current.ClientTools.ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "A new Race for this season has been created");
        }
    }
}