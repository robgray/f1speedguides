using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class ChampionshipTable : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;
        private IStatistician _statistician;

        protected Season Season { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var season = _seasonRepository.GetById(SeasonId);
                if (season == null)
                    season = _seasonRepository.GetCurrent();

                var table = _statistician.GetDetailedDriverChampionshipTable(season);

                ChampionshipTableGridView.RowDataBound += new GridViewRowEventHandler(ChampionshipTableGridView_RowDataBound);

                ChampionshipTableGridView.DataSource = table;                
                ChampionshipTableGridView.DataBind();
            }
        }

        void ChampionshipTableGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Text = Server.HtmlDecode(cell.Text);
            }           
        }

        public int SeasonId { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
            _statistician = new CachedStatistician();            
        }
    }
}