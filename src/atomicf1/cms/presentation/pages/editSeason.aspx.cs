using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.DataLayer;
using umbraco.BasePages;

namespace atomicf1.cms.presentation.pages
{
    public partial class editSeason : BasePage
    {
        private ISeasonRepository _repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);

                LoadPointsSystems();
                LoadRecord(id);
            }
        }

        protected void LoadPointsSystems()
        {
            var baseType = typeof (PointsSystem);            
            var types = baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(PointsSystem))).ToList();
                                                
            PointsSystemList.DataSource = types;
            PointsSystemList.DataTextField = "Name";
            PointsSystemList.DataValueField = "FullName";
            PointsSystemList.DataBind();

        }

        protected void LoadRecord(int id)
        {            
            var season = _repository.GetById(id);
            if (season != null)
            {
                SeasonIdLabel.Text = season.Id.ToString();
                SeasonNameTextBox.Text = season.Name;
                DescriptionTextBox.Text = season.Description;
                YearTextBox.Text = season.Year.ToString();
                IsCurrent.Checked = season.IsCurrent;
                UrlTextBox.Text = season.Url;
                var item = PointsSystemList.Items.FindByValue(season.PointsSystemTypeName);
                if (item != null) item.Selected = true;
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _repository = new SeasonRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var season = _repository.GetById(int.Parse(Request["Id"]));
                if (season != null) {
                    season.Name = SeasonNameTextBox.Text;
                    season.Description = DescriptionTextBox.Text;
                    season.Year = int.Parse(YearTextBox.Text);
                    season.IsCurrent = IsCurrent.Checked;
                    season.Url = UrlTextBox.Text;
                    season.PointsSystemTypeName = PointsSystemList.SelectedValue;

                    _repository.Save(season);

                    BasePage.Current.ClientTools.ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved",
                                                              "Season has been saved.");
                }                
            }
        }
    }
}