using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class SuperRace : System.Web.UI.UserControl
    {
        private IStatistician _statistician;
        private ICircuitRepository _circuitRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                
                CheckDependancies();

                var circuit = _circuitRepository.GetById(CircuitId);
                PopulateSuperGrid(circuit);
            }
        }

        private void CheckDependancies()
        {
            if (_statistician == null) _statistician = new CachedStatistician();
            if (_circuitRepository == null) _circuitRepository = new CircuitRepository();
        }

        public int CircuitId { get; set; }

        private void PopulateSuperGrid(Circuit circuit)
        {            
            var superRace = (from race in _statistician.GetSuperRace(circuit)
                            orderby race.Position
                            select new SuperRaceViewModel
                                       {                                         
                                           Name = race.Driver.Name,
                                           Entries = race.Entries,
                                           Position = race.Position
                                       }).ToList();

            var position = 1;
            superRace.ForEach(x => x.Rank = position++);

            SuperRaceRepeater.DataSource = superRace;
            SuperRaceRepeater.DataBind();
        }

        public class SuperRaceViewModel
        {
            public decimal Position { get; set; }
            public string Name { get; set; }
            public int Entries { get; set; }
            public int Rank { get; set; }                           
        }
    }
}