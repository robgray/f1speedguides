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
    public partial class SeasonDataType : System.Web.UI.UserControl, umbraco.editorControls.userControlGrapper.IUsercontrolDataEditor
    {
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _seasonRepository = new SeasonRepository();

                var seasons = _seasonRepository.GetAll();

                SeasonList.DataSource = seasons;
                SeasonList.DataValueField = "Id";
                SeasonList.DataTextField = "Name";
                SeasonList.DataBind();

                var item = SeasonList.Items.FindByValue(_seasonId);
                if (item != null) item.Selected = true;

            }
        }

        private string _seasonId;
        public object value
        {
            get { return SeasonList.SelectedValue; }
            set { _seasonId = value.ToString(); }
        }        
    }
}