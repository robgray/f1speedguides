using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.controls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.datatypes
{
    public partial class RacesDataType : UserControl, umbraco.editorControls.userControlGrapper.IUsercontrolDataEditor
    {
        private IRaceRepository _raceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                _raceRepository = new RaceRepository();

                var races = _raceRepository.GetAll();

                RaceList.DataSource = races;
                RaceList.DataValueField = "Id";
                RaceList.DataTextField = "Name";
                RaceList.DataBind();

                var item = RaceList.Items.FindByValue(_raceId);
                if (item != null) item.Selected = true;

            }
        }

        private string _raceId;
        public object value
        {
            get { return RaceList.SelectedValue; }
            set { _raceId = value.ToString(); }
        }
    }    
}