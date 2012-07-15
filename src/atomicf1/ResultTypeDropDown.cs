using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using umbraco.interfaces;

namespace atomicf1
{
    public class ResultTypeDropDown : DropDownList, IMacroGuiRendering
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Items.Count == 0)
            {
                this.Items.Add(new ListItem("Race", "Race"));
                this.Items.Add(new ListItem("Qualifying", "Qualifying"));
            }
        }

        #region IMacroGuiRendering Members

        public bool ShowCaption
        {
            get { return true; }
        }

        public string Value
        {
            get { return this.SelectedValue; }
            set { this.SelectedValue = value; }
        }

        #endregion
    }
}