using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using atomicf1.services;

namespace atomicf1.controls
{
    public partial class AchievementsList : System.Web.UI.UserControl
    {
        private IDriverRepository _driverRepository;
        private IAchievementManager _achievementManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                
                CheckDependancies();

                var driver = _driverRepository.GetById(DriverId);
                if (driver != null) {

                    var achievements = _achievementManager.GetAchievements(driver);

                    IList<AchievementsViewModel> achievementsView = new List<AchievementsViewModel>();
                    foreach (var achievement in achievements)
                    {
                        achievementsView.Add(new AchievementsViewModel {
                                                    CssClass = achievement.CssClass,
                                                    Name = achievement.Name + (achievement.TimesAchieved(driver) > 1 ? string.Format(" (x{0})",achievement.TimesAchieved(driver)) : "")
                                                });
                    }

                    AchievementsRepeater.DataSource = achievementsView;
                    AchievementsRepeater.DataBind();
                }                
            }
        }

        public int DriverId { get; set; }

        private void CheckDependancies()
        {            
            if (_driverRepository == null) _driverRepository = new DriverRepository();
            if (_achievementManager == null) _achievementManager = new AchievementManager();
        }
    }

    public class AchievementsViewModel
    {
        public string CssClass { get; set; }
        public string Name { get; set; }
        public int Occurrences { get; set; }
    }
}