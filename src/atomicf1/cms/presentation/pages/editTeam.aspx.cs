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
    public partial class editTeam : BasePage
    {
        private ITeamRepository _repository;

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
            var team = _repository.GetById(int.Parse(Request["id"]));
            if (team != null) {
                TeamNameTextBox.Text = team.Name;
                UrlTextBox.Text = team.Url;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _repository = new TeamRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var team = _repository.GetById(int.Parse(Request["id"]));
                if (team != null) {
                    team.Name = TeamNameTextBox.Text;
                    team.Url = UrlTextBox.Text;

                    _repository.Save(team);

                    BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved",
                                                              "Team details have been saved.");
                }                
            }
        }
    }
}