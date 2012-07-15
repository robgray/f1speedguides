using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.controls
{
    public partial class DriverList : System.Web.UI.UserControl
    {
        private IDriverRepository _driverRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var allDrivers = _driverRepository.GetAll().OrderBy(x => x.Name);

                DriverListRepeater.DataSource = allDrivers;
                DriverListRepeater.DataBind();

            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _driverRepository = new DriverRepository();
        }
    }
}