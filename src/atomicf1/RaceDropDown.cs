using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.interfaces;

namespace atomicf1
{    
    public class RaceDropDown : DropDownList, IMacroGuiRendering
    {
        private IRaceRepository _raceRepository;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Items.Count == 0) {

                _raceRepository = new RaceRepository();

                var races = _raceRepository.GetAll();

                DataSource = races;
                DataValueField = "Id";
                DataTextField = "Name";
                DataBind();

                //var item = Items.FindByValue(_raceId);
                //if (item != null) item.Selected = true;
            }
        }

        #region IMacroGuiRendering Members

        public bool ShowCaption
        {
            get { return true; }
        }

        //private string _raceId;
        public string Value
        {
            get { return this.SelectedValue; }
            set { SelectedValue = value; }
        }

        #endregion
    }
}