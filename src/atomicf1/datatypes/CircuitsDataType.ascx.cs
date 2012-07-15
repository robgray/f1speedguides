using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.datatypes
{
    public partial class CircuitsDataType : System.Web.UI.UserControl, umbraco.editorControls.userControlGrapper.IUsercontrolDataEditor
    {
        private ICircuitRepository _circuitRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                _circuitRepository = new CircuitRepository();

                var circuits = _circuitRepository.GetAll();
                
                CircuitList.DataSource = circuits;
                CircuitList.DataValueField = "Id";
                CircuitList.DataTextField = "Name";
                CircuitList.DataBind();
                
                var item = CircuitList.Items.FindByValue(_circuitId);
                if (item != null) item.Selected = true;
            }
        }
        
        private string _circuitId;
        public object value
        {
            get { return CircuitList.SelectedValue; }
            set { _circuitId = value.ToString(); }
        }        
    }
}