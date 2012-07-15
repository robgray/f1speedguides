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
    public partial class CircuitDetails : System.Web.UI.UserControl
    {
        private IStatistician _statistician;
        private ICircuitRepository _circuitRepository;
        private IRaceRepository _raceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                CheckDependancies();

                var uniqueCircuit = Request["circuit"];
                if (!string.IsNullOrEmpty(uniqueCircuit)) {

                    var circuit = _circuitRepository.GetByUniqueUrl(uniqueCircuit);
                    PopulateCircuitDetail(circuit);
                } else {
                    var circuit = _circuitRepository.GetById(CircuitId);
                    if (circuit == null)
                    {
                        var race = _raceRepository.GetById(RaceId);
                        circuit = race.Circuit;
                    }
                    PopulateCircuitDetail(circuit);
                }
            }
        }
        
        private static CircuitDetailViewModel BuildCircuitDetailViewModel(CircuitStatistics stat)
        {
            return new CircuitDetailViewModel
                       {
                           CircuitImageUri = ("/images/circuits/" + stat.Circuit.ImageUri),
                           CircuitLocation = stat.Circuit.Location + ", " + stat.Circuit.Country,
                           CircuitName = stat.Circuit.Name,
                           PreviousWinner = stat.PreviousWinner.Driver.Name,
                           QualifyingRecord = stat.QualifyingRecord,
                           PreviousWinnerUri = stat.PreviousWinner.Driver.Url,
                           QualifyingRecordHolderUri = stat.QualifyingRecordHolder.Driver.Url,
                           QualifyingRecordHolder = stat.QualifyingRecordHolder.Driver.Name
                       };
        }


        public int CircuitId { get; set; }
        public int RaceId { get; set; }
   
        private void CheckDependancies()
        {
            if (_statistician == null) _statistician = new CachedStatistician();
            if (_circuitRepository == null) _circuitRepository = new CircuitRepository();
            if (_raceRepository == null) _raceRepository = new RaceRepository();
        }

        private void PopulateCircuitDetail(Circuit circuit)
        {
            if (circuit == null)
            {
                Response.Redirect("~/notfound");
            }

            var stat = _statistician.GetCircuitStatistics(circuit);

            IList<CircuitDetailViewModel> detail = new List<CircuitDetailViewModel>()
                                                               {
                                                                   BuildCircuitDetailViewModel(stat)
                                                               };

            CircuitDetail.DataSource = detail;
            CircuitDetail.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            CheckDependancies();
        }

    }

    public class CircuitDetailViewModel
    {
        public string CircuitImageUri { get; set; }
        public string CircuitName { get; set; }
        public string CircuitLocation { get; set;  }
        public string PreviousWinner { get; set; }
        public string QualifyingRecord { get; set; }        
        public string PreviousWinnerUri { get; set; }
        public string QualifyingRecordHolderUri { get; set; }
        public string QualifyingRecordHolder { get; set; }
    }
}