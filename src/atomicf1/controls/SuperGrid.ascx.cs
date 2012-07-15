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
    public partial class SuperGrid : System.Web.UI.UserControl
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
            var position = 1;
            var superGrid = from grid in _statistician.GetSuperGrid(circuit)
                            orderby grid.Rank
                            select new SuperGridViewModel
                                       {
                                           Position = position++,
                                           Name = grid.Driver.Name,
                                           Entries = grid.Entries,
                                           LapTime = grid.LapTime,
                                           CalculatedLapTime = grid.CalculatedLapTime,
                                           Rank = grid.Rank
                                       };
            
            SuperGridRepeater.DataSource = superGrid;
            SuperGridRepeater.DataBind();
        }

        public class SuperGridViewModel
        {
            public int Position { get; set; }
            public string Name { get; set; }
            public int Entries { get; set; }
            public string LapTime { get; set; }
            public string CalculatedLapTime { get; set; }
            public decimal Rank { get; set; }          
        }
    }
}