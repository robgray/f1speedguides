using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.cms.membership;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class NextEvent : System.Web.UI.UserControl
    {
        private ISeasonRepository _seasonRepository;
        private IRaceService _raceService;
        private IStatistician _statistician;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                var season = _seasonRepository.GetCurrent();
                var nextRaces = season.Races.Where(x => x.StartDate >= DateTime.Now).Take(1).OrderBy(x => x.StartDate);

                IList<NextEventViewModel> nextEvents = (from race in nextRaces
                                                        let stats = _statistician.GetCircuitStatistics(race.Circuit)
                                                        select new NextEventViewModel
                                                                   {
                                                                       RaceId = race.Id,
                                                                       CircuitImageUri =
                                                                           ("/images/circuits/" + race.Circuit.ImageUri),
                                                                       CircuitUri = race.Circuit.Url,
                                                                       Location =
                                                                           race.Circuit.Location + ", " +
                                                                           race.Circuit.Country,
                                                                       CircuitName = race.Circuit.Name,
                                                                       PreviousWinner = stats.PreviousWinner.Driver.Name,
                                                                       QualifyingRecord = stats.QualifyingRecord,
                                                                       RaceDate = race.StartDate,
                                                                       PreviousWinnerUri =
                                                                           stats.PreviousWinner.Driver.Url,
                                                                       RaceLength = race.PercentLength + "%"
                                                                   }).ToList();

                if (nextEvents.Any())
                {
                    NextEventRepeater.DataSource = nextEvents;
                    NextEventRepeater.DataBind();
                }
                                
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _seasonRepository = new SeasonRepository();
            _statistician = new CachedStatistician();
            _raceService = new RaceService();
        }

        protected void NextEventRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{                                
            //    var viewEntries = e.Item.FindControl("ViewEntriesButton") as LinkButton;
            //    var confirmEntryButton = e.Item.FindControl("ConfirmEntryButton") as LinkButton;
            //    var withdrawButton = e.Item.FindControl("WithdrawEntryButton") as LinkButton;

            //    var viewModel = e.Item.DataItem as NextEventViewModel;
            //    if (viewModel == null) return;

            //    _raceService.GetRaceRegistrations(viewModel.RaceId);

            //    var user = Membership.GetUser();
            //    if (user == null)
            //    {
            //        viewEntries.CommandName = "RaceId";
            //        viewEntries.CommandArgument = viewModel.RaceId.ToString();
            //        confirmEntryButton.Visible = false;
            //        withdrawButton.Visible = false;
            //        return;
            //    }

            //    confirmEntryButton.CommandName = "RaceId";
            //    confirmEntryButton.CommandArgument = viewModel.RaceId.ToString();
            //    withdrawButton.CommandName = "RaceId";
            //    withdrawButton.CommandArgument = viewModel.RaceId.ToString();

            //    var profile = DriverProfile.GetDriverProfile(user.UserName);
            //    if (profile == null || profile.Driver == null)
            //    {
            //        confirmEntryButton.Visible = false;
            //        withdrawButton.Visible = false;
            //        return;
            //    }

            //    confirmEntryButton.Visible = true;
            //    withdrawButton.Visible = true;
            //    confirmEntryButton.Command += new CommandEventHandler(confirmEntryButton_Command);
            //    viewEntries.Command += new CommandEventHandler(viewEntries_Command);
            //    withdrawButton.Command += new CommandEventHandler(withdrawButton_Command);

            //}
        }

        void withdrawButton_Command(object sender, CommandEventArgs e)
        {
            var driverId = DriverProfile.GetDriverProfile().Driver.Id;
            _raceService.WithdrawFromRace((int)e.CommandArgument, driverId);            
        }

        void confirmEntryButton_Command(object sender, CommandEventArgs e)
        {
            var driverId = DriverProfile.GetDriverProfile().Driver.Id;
            _raceService.ConfirmRace((int)e.CommandArgument, driverId);


        }        

        void viewEntries_Command(object sender, CommandEventArgs e)
        {
            
        }

        
    }

    public class NextEventViewModel
    {
        public int RaceId { get; set; }
        public string CircuitImageUri { get; set; }
        public string CircuitName { get; set; }
        public string Location { get; set; }
        public DateTime RaceDate { get; set; }        
        public string PreviousWinner { get; set; }
        public string QualifyingRecord { get; set; }
        public string CircuitUri { get; set; }
        public string PreviousWinnerUri { get; set; }
        public string RaceLength { get; set; }
        public string RaceDateUtc 
        {
            get
            {
                TimeZoneInfo sydneyTimeZone = TimeZoneInfo.GetSystemTimeZones().First(zone => zone.StandardName == "AUS Eastern Standard Time");
                return TimeZoneInfo.ConvertTimeToUtc(RaceDate, sydneyTimeZone).ToString("ddd MMM dd yyyy HH:mm:ss");
            }
        }
    }
}