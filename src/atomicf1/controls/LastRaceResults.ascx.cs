using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.controls
{
    public partial class LastRaceResults : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var season = _seasonRepository.GetCurrent();

                var race = season.Races.Where(r => r.StartDate <= DateTime.Today.AddDays(1)).OrderByDescending(d => d.StartDate).Take(1).FirstOrDefault();

                if (race != null) {

                    RaceName = race.Circuit.Name;

                    LastRaceRepeater.DataSource = race.GetRaceResults();
                    LastRaceRepeater.DataBind();
                }
            }
        }

        public string RaceName { get; set; }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
        }
    }
}