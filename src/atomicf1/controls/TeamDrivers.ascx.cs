using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.domain;

namespace atomicf1.controls
{
    public partial class TeamDrivers : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Func<Season,IEnumerable<DriverContract>> driversContracts = s => s.Entrants.Where(contract => contract.Team.Id == TeamId);

                CurrentDriversRepeater.DataSource = driversContracts(_seasonRepository.GetCurrent());
                CurrentDriversRepeater.DataBind();

                // Previous drivers
                var previousSeasons = _seasonRepository.GetAll().Where(s => !s.IsCurrent).OrderByDescending(s => s.Year);
                var previousDrivers = new List<DriverContract>();
                foreach (var season in previousSeasons)
                {
                    var drivers = driversContracts(season);
                    previousDrivers.AddRange(drivers.ToList());
                }

                PastDriversRepeater.DataSource = previousDrivers;
                PastDriversRepeater.DataBind();

            }
        }

        public int TeamId { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
        }

    }

    public class DriverSeasonsViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Season  { get; set; }
    }
}