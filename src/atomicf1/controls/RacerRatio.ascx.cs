using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class RacerRatio : System.Web.UI.UserControl
    {
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _statistician = new CachedStatistician();

                var model = _statistician.GetRacerTable();

                var position = 1;
                foreach (var item in model)
                {
                    item.Position = position++;
                }

                RacerRepeater.DataSource = model;
                RacerRepeater.DataBind();
            }
        }
    }
}