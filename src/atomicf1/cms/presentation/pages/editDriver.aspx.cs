using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.cms.membership;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BasePages;

namespace atomicf1.cms.presentation.pages
{
    public partial class editDriver : BasePage
    {
        private IDriverRepository _repository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);

                LoadRecord(id);
                LoadMembers(id);
            }
        }

        protected void LoadMembers(int driverId)
        {
            var users = Membership.GetAllUsers();
            var members = new List<string>() {"(None)"};
            foreach (MembershipUser user in users)
            {
                members.Add(user.UserName);
            }
            MemberList.DataSource = members;            
            MemberList.DataBind();

            var profile = DriverProfile.GetByDriverId(driverId);
            if (profile != null)
            {
                var item = MemberList.Items.FindByValue(profile.UserName);
                if (item != null) item.Selected = true;                
            }
        }

        protected void LoadRecord(int id)
        {
            var driver = _repository.GetById(id);
            if (driver != null) {
                DriverNameTextBox.Text = driver.Name;
                NationalityTextBox.Text = driver.Nationality;
                AtomicName.Text = driver.AtomicName;
                AtomicUserId.Text = driver.AtomicUserId.ToString();
                UrlTextBox.Text = driver.Url;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _repository = new DriverRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var driver = _repository.GetById(int.Parse(Request["id"]));
                if (driver != null) {
                    driver.Name = DriverNameTextBox.Text;
                    driver.Nationality = NationalityTextBox.Text;
                    driver.AtomicName = AtomicName.Text;
                    driver.AtomicUserId = int.Parse(AtomicUserId.Text);
                    driver.Url = UrlTextBox.Text;

                    _repository.Save(driver);

                    if (MemberList.SelectedValue != "")
                    {
                        var user = Membership.GetUser(MemberList.SelectedValue);
                        if (user != null)
                        {
                            var profile = DriverProfile.GetDriverProfile(MemberList.SelectedValue);
                            if (profile != null)
                            {
                                profile.Driver = driver;
                                profile.Save();
                            }
                        }
                    }
                }

                BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved",
                                                              "Driver details have been saved.");
            }
        }
    }
}