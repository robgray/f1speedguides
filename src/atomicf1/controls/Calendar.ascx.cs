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
    public partial class Calendar : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var calendar = _seasonRepository.GetCurrent().GetCalendar();
                if (calendar == null) return;

                Name = calendar.Name;
                CalendarRepeater.DataSource = calendar.Events;
                CalendarRepeater.DataBind();
            }
        }

        protected string Name { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
        }
    }
}