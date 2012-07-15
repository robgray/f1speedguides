using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.cms.membership;
using atomicf1.persistence;
using umbraco.cms.businesslogic.web;

namespace atomicf1.controls
{
    public partial class ModifyProfile : System.Web.UI.UserControl
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/");
            }

            Messages.Clear();
            

            if (!IsPostBack)
            {
                var profile = DriverProfile.GetDriverProfile();                

                if (profile == null)
                {
                    DataHolder.Visible = false;
                }
                else
                {
                    if (profile.Driver == null)
                    {
                        Messages.SetInformation("Your login has not yet been assigned to a driver. Please check back soon.");
                        DataHolder.Visible = false;
                        return;
                    }

                    DataHolder.Visible = true;
                    GamerTagTextBox.Text = profile.Driver.Name;
                    AtomicUsernameTextBox.Text = profile.Driver.AtomicName;
                    AtomicUserIdTextBox.Text = profile.Driver.AtomicUserId.ToString();

                    var driverDoc = GetDriverDocument(profile.Driver.Id);
                    if (driverDoc != null)
                    {
                        ControllerTextBox.Text = driverDoc.ControllerMethod;
                        PCSpecTextBox.Text = driverDoc.PCSpec;
                        FavouriteTracksTextBox.Text = driverDoc.FavouriteTracks;
                        DislikedTracks.Text = driverDoc.DislikedTracks;
                        AboutTextBox.Text = driverDoc.About;
                        RacingViewTextBox.Text = driverDoc.RacingView;
                    }                    
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                ((umbraco.UmbracoDefault) this.Page).ValidateRequest = false;

                AssignScript(Controls);
            } catch {}            
        }

        protected void AssignScript(ControlCollection controls)
        {
            var clientId = Messages.ClientID;
            var script = "$('#" + clientId + "').hide()";

            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Attributes.Add("onkeypress", script);
                }
                else
                {

                    if (ctrl.Controls.Count > 0)
                        AssignScript(ctrl.Controls);
                }
            }
        }

        protected DriverDocument GetDriverDocument(int driverId)
        {
            var docType = DocumentType.GetByAlias("Driver");
            var driverDocs = Document.GetDocumentsOfDocumentType(docType.Id);

            foreach (var driverDoc in driverDocs)
            {
                if ((int)driverDoc.getProperty("driverId").Value == driverId)
                {
                    return new DriverDocument(driverDoc);
                }
            }

            return null;
        }

        protected void UpdateProfileButton_Click(object sender, EventArgs e)
        {
            var driverRepo = new DriverRepository();
            var profile = DriverProfile.GetDriverProfile();
            var driver = driverRepo.GetById(profile.Driver.Id);

            driver.Name = GamerTagTextBox.Text;
            driver.AtomicName = AtomicUsernameTextBox.Text;
            
            if (!string.IsNullOrEmpty(AtomicUsernameTextBox.Text))            
                driver.AtomicUserId = int.Parse(AtomicUserIdTextBox.Text);
            driverRepo.Save(driver);

            var doc = GetDriverDocument(driver.Id);
            doc.ControllerMethod = ControllerTextBox.Text;
            doc.DislikedTracks = DislikedTracks.Text;
            doc.FavouriteTracks = FavouriteTracksTextBox.Text;
            doc.RacingView = RacingViewTextBox.Text;
            doc.About = AboutTextBox.Text;
            doc.PCSpec = PCSpecTextBox.Text;

            doc.Save();

            Messages.SetSuccess("Updated Profile");

        }
    }
}