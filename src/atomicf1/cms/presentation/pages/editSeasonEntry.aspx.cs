using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using umbraco.BasePages;
using umbraco.DataLayer;
using atomicf1.persistence;

namespace atomicf1.cms.presentation.pages
{
    public partial class editSeasonEntry : BasePage
    {
        private ITeamRepository _teamRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);

                LoadCircuits();
                LoadRecord(id);
            }
        }

        protected void LoadCircuits()
        {
            var teams = _teamRepository.GetAll();

            TeamList.DataSource = teams;
            TeamList.DataTextField = "Name";
            TeamList.DataValueField = "Id";
            TeamList.DataBind();

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _teamRepository = new TeamRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);
        }

        protected void LoadRecord(int id)
        {
            IRecordsReader reader =
                    umbraco.BusinessLogic.Application.SqlHelper.ExecuteReader(
                        @"SELECT D.Name AS 'Name', T.Name AS 'TeamName',
                            DC.DateCommenced, DC.DateTerminated, DC.IsReserve
                            FROM drivercontract dc INNER JOIN driver d ON dc.driverid=d.driverid
                            INNER JOIN team t ON dc.teamid=t.teamid
                            WHERE DriverContractId = @id",
                        umbraco.BusinessLogic.Application.SqlHelper.CreateParameter("@id", id));

            while (reader.Read())
            {
                DriverName.Text = reader.GetString("Name");
                
                var teamItem = TeamList.Items.FindByText(reader.GetString("TeamName"));
                if (teamItem != null) teamItem.Selected = true;
                ReserveDriverCheckbox.Checked = reader.IsNull("IsReserve") ? false : reader.GetBoolean("IsReserve");
                ContractSigned.Text = reader.GetDateTime("DateCommenced").ToString("dd MMM yyyy");
                if (reader.IsNull("DateTerminated"))
                {
                    PropertyPanel1.Visible = false;
                }
                else
                {
                    ContractTerminated.Text = reader.GetDateTime("DateTerminated").ToString("dd MMM yyyy");
                }
            }
        }

        private int TeamId
        {
            get { return int.Parse(TeamList.SelectedValue); }
        }

        private int ContractId
        {
            get { return int.Parse(Request["id"]); }
        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                var repo = new DriverContractRepository();
                var contract = repo.GetById(ContractId);
                if (contract == null) return;

                contract.IsReserve = ReserveDriverCheckbox.Checked;
                contract.Team = _teamRepository.GetById(TeamId);

                repo.Save(contract);

                BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved",
                                                              "Season Entry has been updated.");

            }
        }
    }
}