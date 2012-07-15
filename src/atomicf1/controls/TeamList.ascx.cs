using System;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.controls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private ITeamRepository _teamRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var allTeams= _teamRepository.GetAll();
                
                TeamListRepeater.DataSource = allTeams;
                TeamListRepeater.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _teamRepository = new TeamRepository();
        }
    }
}