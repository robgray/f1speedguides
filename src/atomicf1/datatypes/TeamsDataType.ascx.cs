using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.datatypes
{
    public partial class TeamsDataType : System.Web.UI.UserControl, umbraco.editorControls.userControlGrapper.IUsercontrolDataEditor
    {
        private ITeamRepository _teamRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                
                _teamRepository = new TeamRepository();
                var teams = _teamRepository.GetAll();

                TeamList.DataSource = teams;
                TeamList.DataValueField = "Id";
                TeamList.DataTextField = "Name";
                TeamList.DataBind();

                var item = TeamList.Items.FindByValue(_teamId);
                if (item != null) item.Selected = true;               
            }
        }

        private string _teamId;
        public object value
        {
            get { return TeamList.SelectedValue; }
            set { _teamId = value.ToString(); }
        }  
    }
}