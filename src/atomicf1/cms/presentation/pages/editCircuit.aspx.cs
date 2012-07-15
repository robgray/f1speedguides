using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BasePages;
using umbraco.DataLayer;

namespace atomicf1.cms.presentation.pages
{
    public partial class editCircuit : BasePage
    {
        private ICircuitRepository _repository;        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);

                LoadRecord(id);
            }
        }

        protected void LoadRecord(int id)
        {
            var circuit = _repository.GetById(id);
            if (circuit != null) {

                CircuitNameTextBox.Text = circuit.Name;
                LocationTextBox.Text = circuit.Location;
                CountryTextBox.Text = circuit.Country;
                ImageUri.Text = circuit.ImageUri;
                UrlTextBox.Text = circuit.Url;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _repository = new CircuitRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var circuit = _repository.GetById(int.Parse(Request["id"]));
                if (circuit != null) {

                    circuit.Name = CircuitNameTextBox.Text;
                    circuit.Location = LocationTextBox.Text;
                    circuit.Country = CountryTextBox.Text;
                    circuit.ImageUri = ImageUri.Text;
                    circuit.Url = UrlTextBox.Text;

                    _repository.Save(circuit);

                    BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved", "Circuit details have been saved.");
                }


                
                                                              
            }
            
        }
    }
}