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
    public partial class RaceCircuitDetails : System.Web.UI.UserControl
    {
        private IRaceRepository _raceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckDependancies();

                var race = _raceRepository.GetById(RaceId);
                CircuitImageUrl = race.Circuit.ImageUri;
                Location = race.Circuit.Location;
                Name = race.Circuit.Name;
                Country = race.Circuit.Country;
                CircuitUrl = race.Circuit.Url;
                Distance = race.PercentLength + "%";
            }
        }

        public int RaceId { get; set; }
        public string CircuitImageUrl { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string CircuitUrl { get; set; }
        public string Distance { get; set; }

        private void CheckDependancies()
        {
            if (_raceRepository == null) _raceRepository = new RaceRepository();
        }
    }
}