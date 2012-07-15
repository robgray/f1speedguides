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
    public partial class createCircuit : System.Web.UI.UserControl
    {
        private ICircuitRepository _repository;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _repository = new CircuitRepository();
        }

        protected void sbmt_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {

                var circuit = new Circuit
                                  {
                                      Name = rename.Text,
                                      Location = location.Text,
                                      Country = country.Text
                                  };

                _repository.Save(circuit);
                
                BasePage.Current.ClientTools.ReloadActionNode(false, true);                
                BasePage.Current.ClientTools.CloseModalWindow();
                BasePage.Current.ClientTools.ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "Circuit has been saved");
            }
        }
    }
}