using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class Champions : System.Web.UI.UserControl
    {
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChampionsList.DataSource = _statistician.GetChampions().OrderBy(x => x.Season);
                ChampionsList.DataBind();

            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _statistician = new CachedStatistician();
        }
    }
}