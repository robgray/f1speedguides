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
    public partial class CircuitList : System.Web.UI.UserControl
    {
        private ICircuitRepository _circuitRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var allCircuits = _circuitRepository.GetAll();

                CircuitListRepeater.DataSource = allCircuits;
                CircuitListRepeater.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _circuitRepository = new CircuitRepository();
        }
    }
}