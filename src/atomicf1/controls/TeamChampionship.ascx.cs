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
    public partial class TeamChampionship : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                var season = _seasonRepository.GetCurrent();
                var champResults = season.GetTeamStandings();

                if (champResults.Any())
                {
                    TeamStandings.DataSource = champResults;
                    TeamStandings.DataBind();
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
        }

    }
}