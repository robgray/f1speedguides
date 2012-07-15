using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.common;
using atomicf1.domain.achievements;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class InlineRaceGrid : System.Web.UI.UserControl
    {
        private IRaceRepository _raceRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

               SetData(RaceId, Type);
            }
        }
        
        public int RaceId { get; set; }
        public string Type { get; set; }

        public void SetData(int raceId, string type)
        {
            Type = type;
            RaceId = raceId;
            _raceRepository = new RaceRepository();
            var race = _raceRepository.GetById(raceId);

            var model = new List<ResultViewModel>();

            if (race != null)
            {                     
                if (type == "Race")
                {
                    model.AddRange(from result in race.GetRaceResults()
                                   let qualiResult = race.GetQualifyingResult(result.Entry)
                                   select new ResultViewModel
                                              {
                                                  Name = result.Entrant.Driver.Name, Time = result.Entry.FastestLap.ToLapTime(true), Position = result.GetPositionString(true), 
                                                  Points = result.Points.ToString(), GridPosition = qualiResult.Position.ToString(), 
                                                  TotalPoints = (result.Points + qualiResult.Points).ToString(), HasQualifyingPoints = result.Entry.PointsSystem.GivesPointsForQualifying, 
                                                  HasFastestLap = race.GotFastestLap(result.Entrant.Driver),
                                                  RaceTime = result.Entry.RaceTime
                                              });
                }
                else
                {
                    model.AddRange(race.GetQualificationResults().Select(result => new ResultViewModel
                                                                                       {
                                                                                           Name = result.Entrant.Driver.Name, Time = result.LapTime.ToLapTime(true), 
                                                                                           Position = result.GetQualifyingPositionString(true), Points = result.Points.ToString(), 
                                                                                           HasQualifyingPoints = result.Entry.PointsSystem.GivesPointsForQualifying
                                                                                       }));
                }
            }

            InlineResultRepeater.DataSource = model;
            InlineResultRepeater.DataBind();      
        }

        public class ResultViewModel
        {
            public string Position { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
            public string GridPosition { get; set; }
            public string Points { get; set; }
            public string TotalPoints { get; set; }
            public bool HasQualifyingPoints { get; set; }
            public bool HasFastestLap { get; set; }
            public string RaceTime { get; set; }
            public string FormattedTime
            {
                get { return (HasFastestLap ? "<strong>" : "") + Time + (HasFastestLap ? "</strong>" : ""); }
            }
        }

        protected void InlineResultRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Type == "Race")
            {
                var achievementHolder = e.Item.FindControl("achievementsHolder") as PlaceHolder;
                if (achievementHolder != null)
                {
                    var achievementManager = new AchievementManager();
                    var race = _raceRepository.GetById(RaceId);
                    if (race != null)
                    {
                        var driverName = DataBinder.Eval(e.Item.DataItem, "Name").ToString();

                        IList<Achievement> achievements =
                            achievementManager.GetAchievementsForRaceEntry(
                                race.Entries.FirstOrDefault(ent => ent.Entrant.Driver.Name == driverName));

                        foreach (var achievement in achievements)
                        {
                            var img = new System.Web.UI.WebControls.Image();
                            img.CssClass = "achievement";
                            img.ImageUrl = "/css/atomicf1/medal_gold_3.png";
                            img.AlternateText = achievement.Description;
                            img.ToolTip = achievement.Description;

                            achievementHolder.Controls.Add(img);
                        }
                    }
                }
            }
        }
    }
}