using System;
using System.Collections.Generic;
using umbraco.BasePages;
using atomicf1.domain;

namespace atomicf1.cms.presentation.controls
{
    public partial class createSeasonEntry : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var reader = umbraco.BusinessLogic.Application.SqlHelper.ExecuteReader(
                    @"
                    SELECT D.* 
                    FROM Driver D 
                    WHERE NOT EXISTS (SELECT * FROM DriverContract DC WHERE DC.DriverId=D.DriverId AND DC.SeasonId=@seasonId)",
                    umbraco.BusinessLogic.Application.SqlHelper.CreateParameter("@seasonId", SeasonId));

                var allDrivers = new List<Driver>();
                while (reader.Read()) {
                    var driver = new Driver()
                                     {
                                         Id = reader.GetInt("driverid"),
                                         Name = reader.GetString("name")
                                     };

                    allDrivers.Add(driver);
                }

                reader = umbraco.BusinessLogic.Application.SqlHelper.ExecuteReader(
                    @"
                        SELECT * 
                        FROM Team");

                var allTeams = new List<Team>();
                while (reader.Read()) {
                    var team = new Team()
                                   {
                                       Id = reader.GetInt("teamid"),
                                       Name = reader.GetString("name")

                                   };

                    allTeams.Add(team);
                }
                
                DriverList.DataSource = allDrivers;
                DriverList.DataTextField = "Name";
                DriverList.DataValueField = "Id";
                DriverList.DataBind();
                TeamList.DataSource = allTeams;
                TeamList.DataTextField = "Name";
                TeamList.DataValueField = "Id";
                TeamList.DataBind();
            }
        }

        private int SeasonId
        {
            get { return int.Parse(umbraco.presentation.UmbracoContext.Current.Request["nodeId"]); }
        }

        protected void sbmt_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                                
                // get it from the parent. but how?                
                var seasonId = umbraco.presentation.UmbracoContext.Current.Request["nodeId"];

                const string insertStatement =
                    @"insert into drivercontract (datecommenced, dateterminated, teamid, driverid, seasonid)  
                    values(getdate(), null, @teamid, @driverid, @seasonid)";

                umbraco.BusinessLogic.Application.SqlHelper.ExecuteNonQuery(
                    insertStatement,
                    umbraco.BusinessLogic.Application.SqlHelper.CreateParameter(
                        "@driverid", int.Parse(DriverList.SelectedValue)),
                    umbraco.BusinessLogic.Application.SqlHelper.CreateParameter(
                        "@teamid", int.Parse(TeamList.SelectedValue)),
                    umbraco.BusinessLogic.Application.SqlHelper.CreateParameter(
                        "@seasonid", int.Parse(seasonId)));

                BasePage.Current.ClientTools.ReloadActionNode(false, true);
                BasePage.Current.ClientTools.CloseModalWindow();
                BasePage.Current.ClientTools.ShowSpeechBubble(BasePage.speechBubbleIcon.save, "Saved", "Driver Contract for this season has been created");
            }
        }
    }
}