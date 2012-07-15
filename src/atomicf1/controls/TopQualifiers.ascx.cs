using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class TopQualifiers : System.Web.UI.UserControl
    {        
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var qualifiersPosition = _statistician.GetTopQualifiersForCurrentSeason(PlaceMetric.Position).Take(5);
                if (qualifiersPosition.Any())
                {
                    QualifiersListPosition.DataSource = qualifiersPosition;
                    QualifiersListPosition.DataBind();
                }

                var qualifiersTime = _statistician.GetTopQualifiersForCurrentSeason(PlaceMetric.Time).Take(5);
                if (qualifiersTime.Any())
                {
                    HasData = true;
                    QualifiersListTime.DataSource = qualifiersTime;
                    QualifiersListTime.DataBind();
                }
            }
        }

        protected bool HasData { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _statistician = new CachedStatistician();
        }
    }
}