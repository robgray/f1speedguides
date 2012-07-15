using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class PointsTable : System.Web.UI.UserControl
    {
        

        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                _statistician = new CachedStatistician();

                var model = _statistician.GetPointsTable();
                if (NumberToDisplay > 0)
                    model = model.Take(NumberToDisplay).ToList();

                var position = 1;
                foreach (var item in model)
                {
                    item.Position = position++;
                }

                PointsRepeater.DataSource = model;
                PointsRepeater.DataBind();
            }
        }

        public int NumberToDisplay { get; set; }
    }
}