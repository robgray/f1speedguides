using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BasePages;

namespace atomicf1.cms.presentation.pages
{
    public partial class editRaceEntry : BasePage
    {
        private IRaceRepository _raceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord(RaceEntryId, RaceId);
            }
        }

        private int RaceId
        {
            get { return int.Parse(Request["raceid"]);  }
        }

        private int RaceEntryId
        {
            get { return int.Parse(Request["id"]);  }
        }

        protected void LoadRecord(int id, int raceid)
        {
            var race = _raceRepository.GetById(raceid);
            if (race != null)
            {
                var entry = race.Entries.First(e => e.Id == id);
                if (entry != null)
                {

                    Driver.Text = entry.Entrant.Driver.Name;
                    QualifyingPosition.Text = entry.QualifyingPosition.ToString();
                    QualifyingTime.Text = entry.QualifyingTime.ToString();
                    QualifyingTime2.Text = entry.QualifyingTime2.ToString();
                    QualifyingTime3.Text = entry.QualifyingTime3.ToString();
                    FastestLap.Text = entry.FastestLap.ToString();
                    RacePlace.Text = entry.RacePlace.ToString();
                    RaceTime.Text = entry.RaceTime;
                    DidNotStart.Checked = entry.DidNotStart;
                    DidNotFinish.Checked = entry.DidNotFinish;
                    DidNotQualify.Checked = entry.DidNotQualify;
                    Disqualified.Checked = entry.IsDisqualified;
                    GridPosition.Text = entry.GridPosition.ToString();
                }
            }      
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _raceRepository = new RaceRepository();

            ImageButton save = Panel1.Menu.NewImageButton();
            save.ImageUrl = umbraco.GlobalSettings.Path + "/images/editor/save.gif";
            save.AlternateText = "Save";
            save.Click += new ImageClickEventHandler(SaveRecord);

        }

        void SaveRecord(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid) {

                var race = _raceRepository.GetById(RaceId);
                var entry = race.Entries.FirstOrDefault(et => et.Id == RaceEntryId);
                if (entry != null)
                {
                    entry.QualifyingPosition = int.Parse(QualifyingPosition.Text);
                    entry.QualifyingTime = decimal.Parse(QualifyingTime.Text);
                    entry.QualifyingTime2 = decimal.Parse(QualifyingTime2.Text);
                    entry.QualifyingTime3 = decimal.Parse(QualifyingTime3.Text);
                    entry.FastestLap = decimal.Parse(FastestLap.Text);
                    entry.RacePlace = int.Parse(RacePlace.Text);
                    entry.RaceTime = RaceTime.Text;
                    entry.DidNotStart = DidNotStart.Checked;
                    entry.DidNotFinish = DidNotFinish.Checked;
                    entry.DidNotQualify = DidNotQualify.Checked;
                    entry.IsDisqualified = Disqualified.Checked;
                    entry.GridPosition = int.Parse(GridPosition.Text);

                    _raceRepository.Save(race);
                }


                BasePage.Current.ClientTools.ShowSpeechBubble(speechBubbleIcon.save, "Saved",
                                                              "Qualifying result has been saved.");
            }
        }
    }
}