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
    public partial class DriversDataType : System.Web.UI.UserControl, umbraco.editorControls.userControlGrapper.IUsercontrolDataEditor
    {    
        private IDriverRepository _driverRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _driverRepository = new DriverRepository();
                var circuits = _driverRepository.GetAll();

                DriverList.DataSource = circuits;
                DriverList.DataValueField = "Id";
                DriverList.DataTextField = "Name";
                DriverList.DataBind();

                var item = DriverList.Items.FindByValue(_driverId);
                if (item != null) item.Selected = true;
            }
        }

        private string _driverId;
        public object value
        {
            get { return DriverList.SelectedValue; }
            set { _driverId = value.ToString(); }
        }  
    }
}